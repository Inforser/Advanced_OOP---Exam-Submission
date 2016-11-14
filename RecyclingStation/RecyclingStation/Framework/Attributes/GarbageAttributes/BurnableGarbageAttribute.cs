namespace RecyclingStation.Framework.Attributes.GarbageAttributes
{
    public class BurnableGarbageAttribute : DisposableAttribute
    {
        public BurnableGarbageAttribute(string stragyAttrName) 
            : base(stragyAttrName)
        {
        }
    }
}
