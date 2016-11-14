namespace RecyclingStation.Providers.TypeProvider
{
    using System;
    using System.Collections.Generic;

    public interface ITypeProvider
    {
        Type GetClassByName(string className);

        Type GetFirstClassByAttrribute(Type attributeType);

        IEnumerable<Type> GetClassesByAttribute(Type attributeType);

        IEnumerable<Type> GetSubClasses(Type superType);
    }
}
