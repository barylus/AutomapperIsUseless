using FuckAutomapper.TypeMap.Cache;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FuckAutomapper.TypeMap
{
    public static class TypeAdapter
    {
        public static TargetType Adapt<TargetType, OriginType>(OriginType originObject) where TargetType : class, new() where OriginType : class
        {
            return AdapterRepository.GetAdapter(typeof(OriginType)).Adapt<OriginType,TargetType>(originObject);
        }

        public static IEnumerable<TargetType> Adapt<TargetType, OriginType>(IEnumerable<OriginType> originList)
            where TargetType : class, new() where OriginType : class
        {
            var addaptedList = new List<TargetType>(originList.Count());

            var typeAdapter = AdapterRepository.GetAdapter(typeof(OriginType));

            foreach (var originListElement in originList)
            {
                addaptedList.Add(typeAdapter.Adapt<OriginType, TargetType>(originListElement));
            }
            return addaptedList;
        }

        public static TargetType Adapt<TargetType, OriginType>(OriginType originObject, Func<OriginType, TargetType> mappingFunction)
            where TargetType : class, new() where OriginType : class
        {
            return mappingFunction(originObject);
        }

        public static IEnumerable<TargetType> Adapt<TargetType, OriginType>(IEnumerable<OriginType> originList, Func<OriginType, TargetType> mappingFunction)
            where TargetType : class, new() where OriginType : class
        {
            var addaptedList = new List<TargetType>(originList.Count());
            foreach(var originListElement in originList)
            {
                addaptedList.Add(mappingFunction(originListElement));
            }
            return addaptedList;
        }

        public static void RegisterAdapterMappingFunction<TargetType, OriginType>(Func<OriginType, TargetType> mappingFunction) where TargetType : class where OriginType : class
        {
            AdapterRepository.GetAdapter(typeof(OriginType)).RegisterMappingFunction(typeof(TargetType),mappingFunction);
        }
    }
}
