using Microsoft.AspNetCore.Cors;
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
    //cors attributes
    [Microsoft.AspNetCore.Cors.EnableCors("AllowOrigin")]
    
    public class SolrGetData : ControllerBase
    {
        
        private readonly ISolrReadOnlyOperations<MySolrModel> _solr;
        private readonly IDistributedCache _cache;
        public SolrGetData(ISolrReadOnlyOperations<MySolrModel> solr, IDistributedCache cache)
        {
            _solr = solr;
            _cache = cache;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MySolrModel>>?> Get()
        {
            string cacheKey = "simplepagedata";
            byte[] cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                var solrResult1 = JsonSerializer.Deserialize<List<MySolrModel>>(cachedDataString);
                if (solrResult1 != null)
                    return solrResult1;
                return null;
            }
            else
            {
                var solrResult = (await _solr.QueryAsync(new SolrMultipleCriteriaQuery(new ISolrQuery[]
               {
                 new SolrQueryByField("_language", "en"),
                 new SolrQueryByField("_templatename", cacheKey),
               },
               SolrMultipleCriteriaQuery.Operator.AND)
              )).Take(20)
               .ToList();
                string cachedDataString = JsonSerializer.Serialize(solrResult);
                var dataToCache = Encoding.UTF8.GetBytes(cachedDataString);

                // Setting up the cache options
                DistributedCacheEntryOptions options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(5))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(3));

                // Add the data into the cache
                await _cache.SetAsync(cacheKey, dataToCache, options);

                if (solrResult != null)
                {
                    return Ok(solrResult);

                }
            }
            return null;

        }
    }
}
