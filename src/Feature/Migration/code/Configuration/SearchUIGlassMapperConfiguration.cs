using Glass.Mapper.Sc.Configuration.Fluent;

namespace TripleM.Feature.SearchUI.Configuration
{
    public static class SearchUIGlassMapperConfiguration
    {
        public static SitecoreFluentConfigurationLoader LoadGlassMapperModels(SitecoreFluentConfigurationLoader fluentLoader)
        {
            fluentLoader.Add(TripleM.Feature.SearchUI.Models.SearchUI.Load());
            return fluentLoader;
        }
    }
}