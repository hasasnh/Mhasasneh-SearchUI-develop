using Sitecore.Pipelines;

namespace TripleM.Web
{
    public class ClearDictionaryCache
    {
        //This pipeline will clear the Sitecore dictionary cache on application start
        public void Process(PipelineArgs args)
        {
            Sitecore.Globalization.Translate.ResetCache(true);
        }

    }
}