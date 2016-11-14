namespace RecyclingStation.Framework.Attributes.GarbageAttributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public abstract class DisposableAttribute : Attribute
    {
        protected DisposableAttribute(string stragyAttrName)
        {
            this.StragyAttrName = stragyAttrName;
        }

        public string StragyAttrName { get; }
    }
}
