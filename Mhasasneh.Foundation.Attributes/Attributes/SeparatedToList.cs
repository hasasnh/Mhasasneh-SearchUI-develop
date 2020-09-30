using System;

namespace Mhasasneh.Foundation.Core.Attributes
{
    public sealed class SeparatedToList : Attribute, IAttributeBase
    {
        public SeparatedToList(string by, string itemID)
        {
            Name = by;
            Param = itemID;
        }

        public string Name
        {
            get;
            set;
        }

        public string Param
        {
            get;
            set;
        }

        public string ParentTemplateID { get; set; }
        public string ChildrenTemplateID { get; set; }
    }
}
