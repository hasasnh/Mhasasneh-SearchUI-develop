using System;

namespace Mhasasneh.Foundation.Core.BaseClasses
{
    // Glass base class
    public abstract class GlassBase
    {
        /// <summary>
        /// Get or set Name property
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Get or set Id property
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Get or Set the Language Property
        /// </summary>
        public virtual string Language { get; set; }

        /// <summary>
        /// Get or set DisplayName property
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// Template Id
        /// </summary>
        public virtual Guid TemplateId { get; set; }
    }

    // Glass parent class
    public class GlassParent
    {
        /// <summary>
        /// Get or set Id property
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}
