namespace Mhasasneh.Foundation.Core.Settings.Base
{
    public interface IBaseSettings
    {
        /// <summary>
        /// This method It gives you the value of the (public) property by named of the the instance, doesn't use LINQ
        /// </summary>
        /// <typeparam name="TResult">type of property</typeparam>
        /// <param name="propertyName">name of property</param>
        /// <returns>value of the property</returns>
        TResult Get<TResult>(string propertyName);
    }
}
