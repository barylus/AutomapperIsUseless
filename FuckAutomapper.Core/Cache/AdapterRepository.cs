using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace FuckAutomapper.TypeMap.Cache
{
    internal static class AdapterRepository
    {
        private static Dictionary<Guid, TypeAdapterContainer> _typeAdapterContainerCache = new();

        internal static TypeAdapterContainer GetAdapter(Type originType)
        {
            if (_typeAdapterContainerCache.ContainsKey(originType.GUID))
            {
                return _typeAdapterContainerCache[originType.GUID];
            }

            _typeAdapterContainerCache.Add(originType.GUID, new TypeAdapterContainer(originType));

            return _typeAdapterContainerCache[originType.GUID];
        }
    }
}
