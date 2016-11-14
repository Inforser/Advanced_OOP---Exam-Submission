namespace RecyclingStation.Framework.Attributes.GarbageAttributes
{
    public class RecyclableGarbageAttribute : DisposableAttribute
    {
        public RecyclableGarbageAttribute(string stragyAttrName) 
            : base(stragyAttrName)
        {
        }
    }
}
