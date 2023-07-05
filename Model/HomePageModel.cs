using SolrNet.Attributes;

namespace MSComercial.Model
{
    public class HomePageModel
    {
        [SolrField("_language")]
        public string?  Language { get; set; }
   
        [SolrField("commercial_image_s")]
        public string? Commercial_Image_Path { get; set; }
        [SolrField("image_title_t")]
        public string? Image_Title { get; set; }
        [SolrField("image_description_t")]
        public string? Image_Description { get; set; }
        [SolrField("cta_t")]
        public string? CTA { get; set; }
        [SolrField("sociallogo_t")]
        public string? SocialLogo { get; set; }
        [SolrField("sociallogo_s")]
        public string? SocialLogo_Path { get; set; }
        [SolrField("banner_mob_image _t")]
        public string? Banner_Mob_Image { get; set; }
        [SolrField("banner_mob_image _s")]
        public string? Banner_Mob_Image_Path { get; set; }
        [SolrField("banner_image_t")]
        public string? Banner_Image { get; set; }
        [SolrField("banner_image_s")]
        public string? Banner_Image_Path { get; set; }

        [SolrField("banner_tab_image_t")]
        public string? Banner_Tab_Image { get; set; }
        [SolrField("banner_tab_image_s")]
        public string? Banner_Tab_Image_path { get; set; }
        [SolrField("banner_title_t")]
        public string? Banner_Title { get; set; }
        [SolrField("banner_ctatext1_t")]
        public string? Banner_CTAText1 { get; set; }
        [SolrField("banner_ctatext2_t")]
        public string? Banner_CTAText2 { get; set; }
        [SolrField("banner_ctalink1_t")]
        public string? Banner_CTALink1 { get; set; }
        [SolrField("banner_ctalink2_t")]
        public string? Banner_CTALink2 { get; set; }
        [SolrField("news_image_t")]
        public string? News_Image { get; set; }
        
        [SolrField("latestnews_heading_t")]
        public string? LatestNews_Heading { get; set; }
        [SolrField("latestnews_image_t")]
        public string? LatestNews_Image { get; set; }
        [SolrField("news_title_t")]
        public string? News_Title { get; set; }
        [SolrField("news_description_t")]
        public string? News_Description { get; set; }
        [SolrField("testimonials_title_t")]
        public string? Testimonials_Title { get; set; }
        [SolrField("testimonials_description_t")]
        public string? Testimonials_Description { get; set; }
        [SolrField("testimonials_image_s")]
        public string? Testimonials_Image { get; set; }
        [SolrField("testimonials_videos_t")]
        public string? Testimonials_Videos { get; set; }
        [SolrField("vehicle_name_t")]
        public string? Vehicle_Name { get; set; }
        [SolrField("vehicle_price_t")]
        public string? Vehicle_Price { get; set; }
        [SolrField("vehicle_engine_t")]
        public string? Vehicle_Engine { get; set; }
        [SolrField("vehicle_fuletype_t")]
        public string? Vehicle_FuleType { get; set; }
        [SolrField("vehicle_modelcode_t")]
        public string? Vehicle_ModelCode { get; set; }
        [SolrField("vehicle_image_t")]
        public string? Vehicle_Image { get; set; }
        [SolrField("vehicle_mobileimage_s")]
        public string? Vehicle_MobileImage { get; set; }
        [SolrField("vehicle_logoimage_t")]
        public string? Vehicle_LogoImage { get; set; }
        [SolrField("ctaink_t")]
        public string? CTALink { get; set; }
        [SolrField("cta2_t")]
        public string? CTA2 { get; set; }
        [SolrField("vehicle_title_t")]
        public string? Vehicle_Title { get; set; }
        [SolrField("count1_t")]
        public string? Count1 { get; set; }
        [SolrField("count_description_t")]
        public string? Count_Description { get; set; }
        [SolrField("whowearectatext_t")]
        public string? WhoWeAreCTAText { get; set; }
        [SolrField("whowearectalink_t")]
        public string? WhoWeAreCTALink { get; set; }
        [SolrField("count2_t")]
        public string? Count2 { get; set; }
        [SolrField("count3_t")]
        public string? Count3 { get; set; }
        [SolrField("count2_description_t")]
        public string? Count2_Description { get; set; }
        [SolrField("count3_description_t")]
        public string? Count3_Description { get; set; }





    }
}