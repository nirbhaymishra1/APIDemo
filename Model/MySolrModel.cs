using SolrNet.Attributes;

namespace MSComercial.Model
{
    public class MySolrModel
    {
        [SolrField("_language")] public string? Language { get; set; }
        [SolrField("_fullpath")] public string? FullPath { get; set; }
        [SolrField("_templatename")] public string? templatename { get; set; }
        [SolrField("page_body_t")] public string? Pagebody { get; set; }
        [SolrField("page_description_t")] public string? Pagedescription { get; set; }
        [SolrField("page_title_t")] public string? Pagetitle { get; set; }
    }
}
