using System;

namespace Mhasasneh.Foundation.Core.Attributes
{
    public sealed class MultiList : Attribute, IAttributeBase
    {
        public MultiList(string name, string itemID)
        {
            Name = name;
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
