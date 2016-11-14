namespace RecyclingStation.Framework.Attributes.GarbageAttributes
{
    public class StorableGarbageAttribute : DisposableAttribute
    {
        public StorableGarbageAttribute(string stragyAttrName) 
            : base(stragyAttrName)
        {
        }
    }
}
