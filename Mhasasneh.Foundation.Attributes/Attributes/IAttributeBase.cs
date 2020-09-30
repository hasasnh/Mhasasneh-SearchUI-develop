namespace Mhasasneh.Foundation.Core.Attributes
{
    public interface IAttributeBase
    {
        string Name { get; set; }
        string Param { get; set; }
        string ParentTemplateID { get; set; }
        string ChildrenTemplateID { get; set; }
    }
}
