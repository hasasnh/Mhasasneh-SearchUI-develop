using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using System;
using System.Runtime.Serialization;

namespace TripleM.Feature.SearchUI.Models
{
    [DataContract]
    [Serializable]
    public class NewsSearchModel : SearchResultItem
    {
        [DataMember]
        [IndexField("Name")]
        public string Name { get; internal set; }

        [DataMember]
        [IndexField("Title")]
        public string Title { get; internal set; }
    }
}