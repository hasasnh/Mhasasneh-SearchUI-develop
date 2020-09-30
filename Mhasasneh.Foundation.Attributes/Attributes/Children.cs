using System;

namespace Mhasasneh.Foundation.Core.Attributes
{
    public sealed class Children : Attribute, IAttributeBase
    {
        public Children(string name, string parentTemplateID, string childrenTemplateID="" , string fileds = "")
        {
            Name = name;
            Param = fileds;
            ParentTemplateID = parentTemplateID;
            ChildrenTemplateID = childrenTemplateID;
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

        public string ParentTemplateID
        {
            get;
            set;
        }

        public string ChildrenTemplateID
        {
            get;
            set;
        }
    }
}
