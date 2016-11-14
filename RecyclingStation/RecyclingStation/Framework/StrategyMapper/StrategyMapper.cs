namespace RecyclingStation.Framework.StrategyMapper
{
    using System;
    using System.Collections.Generic;
    using Attributes.GarbageAttributes;
    using GarbageDisposalStrategies;
    using Providers.TypeProvider;
    using StrategyHolder;

    public class StrategyMapper : IStrategyMapper
    {
        private readonly IStrategyHolder strategyHolder;

        private readonly ITypeProvider typeProvider;

        public StrategyMapper(IStrategyHolder strategyHolder, ITypeProvider typeProvider)
        {
            this.strategyHolder = strategyHolder;
            this.typeProvider = typeProvider;
        }

        public void Map()
        {
            var allGarbageAttributeTypes =
                this.typeProvider.GetSubClasses(typeof(DisposableAttribute));
            foreach (var garbageAttributeType in allGarbageAttributeTypes)
            {
                var garbageType = this.typeProvider.GetFirstClassByAttrribute(garbageAttributeType);
                if (garbageType == null)
                {
                    throw new Exception("No class has this GarbageAttribute!");
                }

                var attributes = garbageType.GetCustomAttributes(false);
                var mappingString = this.GetMappingString(attributes);

                var strategyAttributeClassType = this.typeProvider.GetClassByName(mappingString);
                if (strategyAttributeClassType == null)
                {
                    throw new Exception("No StrategyAttribute class has this name!");
                }

                var strategyClassType = this.typeProvider.GetFirstClassByAttrribute(strategyAttributeClassType);
                var strategy = (IGarbageDisposalStrategy)Activator.CreateInstance(strategyClassType);

                this.strategyHolder.AddStrategy(garbageAttributeType, strategy);
            }
        }

        private string GetMappingString(IEnumerable<object> attributes)
        {
            var mappingString = string.Empty;
            foreach (object t in attributes)
            {
                var attr = t as DisposableAttribute;
                if (attr == null)
                {
                    continue;
                }

                mappingString = attr.StragyAttrName + "Attribute";
                break;
            }

            if (string.IsNullOrWhiteSpace(mappingString))
            {
                throw new Exception("Incorrect attribute assignment!");
            }

            return mappingString;
        }
    }
}