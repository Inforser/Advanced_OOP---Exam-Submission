namespace RecyclingStation.Providers.TypeProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class TypeProvider : ITypeProvider
    {
        private readonly Assembly assembly;

        private readonly List<Type> classes;

        private readonly IDictionary<Type, IEnumerable<Type>> classesByAttribute;

        public TypeProvider(Assembly assembly)
        {
            this.assembly = assembly;
            this.classes = new List<Type>();
            this.InitialiseClasses();
            this.classesByAttribute = new Dictionary<Type, IEnumerable<Type>>();
        }

        public Type GetClassByName(string className)
        {
            return this.classes.FirstOrDefault(c => c.Name == className);
        }

        public Type GetFirstClassByAttrribute(Type attributeType)
        {
            return this.classes.FirstOrDefault(c => c.IsDefined(attributeType));
        }

        public IEnumerable<Type> GetClassesByAttribute(Type attributeType)
        {
            if (this.classesByAttribute.ContainsKey(attributeType))
            {
                return this.classesByAttribute[attributeType];
            }

            var result = this.classes.Where(c => c.IsDefined(attributeType));

            this.classesByAttribute[attributeType] = result;

            return result;
        }

        public IEnumerable<Type> GetSubClasses(Type superType)
        {
            var result = this.classes.Where(c => superType.IsAssignableFrom(c) && superType != c);

            return result;
        }

        private void InitialiseClasses()
        {
            var assemblyClasses = this.assembly.GetTypes();
            this.classes.AddRange(assemblyClasses);
        }
    }
}
