using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MSComercial.Model;
using SolrNet;
using System.Text;
using System.Text.Json;

namespace MSComercial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Microsoft.AspNetCore.Cors.EnableCors()]
    public class HomePageData : ControllerBase
    {
      
        private readonly ISolrReadOnlyOperations<HomePageModel> _solr;
        private readonly IDistributedCache _cache;
        //constructor with parameter injection
        public HomePageData(ISolrReadOnlyOperations<HomePageModel> solr, IDistributedCache cache)
        {
            _solr = solr;
            _cache = cache;
        }
        
        [HttpGet,Authorize]
        public async Task<ActionResult<IEnumerable<HomePageModel>>?> Get()
        {
            string cacheKey = "DemoData";
            byte[] cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                var solrResult1 = JsonSerializer.Deserialize<List<HomePageModel>>(cachedDataString);
                if (solrResult1 != null)
                    return solrResult1;
                return null;
            }
            else
            {
                var solrResult = (await _solr.QueryAsync(new SolrMultipleCriteriaQuery(new ISolrQuery[]
                {
                 new SolrQueryByField("_language", "en"),
                 new SolrQueryByField("_customname_ls", cacheKey),
               },
                             SolrMultipleCriteriaQuery.Operator.AND)
                                 ))
               .ToList();
                string cachedDataString = JsonSerializer.Serialize(solrResult);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                // Setting up the cache options
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));
                // Add the data into the cache
                await _cache.SetAsync(cacheKey, dataToCache, options);
                if (solrResult != null)
                {
                    return solrResult;
                }
                return null;
            }
        }

    }
}
