using System;

namespace Mhasasneh.Foundation.Common.Options
{
    public class CreateOptions
    {
        public object Parent { get; set; }
        public Type Type { get; set; }

        public Type ParentType
        {
            get { return Parent.GetType(); }
        }

        public class CreateByModelOptions : CreateOptions
        {
            public object Model { get; set; }

            public CreateByModelOptions() { }

            public CreateByModelOptions(object model)
            {
                Model = model;
            }
        }
    }
}
