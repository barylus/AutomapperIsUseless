using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FuckAutomapper.TypeMap
{
    internal class TypeAdapterContainer
    {
        private Type _sourceType;
        private PropertyInfo[] _sourceTypePropertyInfos;
        private Dictionary<Guid, PropertyInfo[]> _targetTypePropertyInfos;
        private Dictionary<Guid, object> _mappingFunctions;

        public TypeAdapterContainer(Type type)
        {
            _sourceType = type;
            _sourceTypePropertyInfos = _sourceType.GetProperties();
            _targetTypePropertyInfos = new Dictionary<Guid, PropertyInfo[]>();
            _mappingFunctions = new Dictionary<Guid, object>();
        }

        internal void RegisterMappingFunction<TargetType, OriginType>(Type targetType, Func<OriginType, TargetType> mappingFunction)
        {
            if (_mappingFunctions.ContainsKey(targetType.GUID))
                _mappingFunctions[targetType.GUID] = mappingFunction;
            else
                _mappingFunctions.Add(targetType.GUID, mappingFunction);
        }

        internal TargetType Adapt<OriginType, TargetType>(OriginType originObject) where TargetType : class, new() where OriginType : class
        {
            var targetType = typeof(TargetType);
            if (_mappingFunctions.ContainsKey(targetType.GUID))
            {
                return ((Func<OriginType, TargetType>)_mappingFunctions[targetType.GUID]).Invoke(originObject);
            }

            return AdaptFromPropertyInfos<TargetType, OriginType>(originObject);
        }

        private TargetType AdaptFromPropertyInfos<TargetType, OriginType>(OriginType originObject)
            where TargetType : class, new()
            where OriginType : class
        {
            var targetType = typeof(TargetType);
            var adaptedObject = new TargetType();
            PropertyInfo originPropertyInfo;
            PropertyInfo targetPropertyInfo;
            foreach(var property in GetCommonProperties(targetType))
            {
                originPropertyInfo = _sourceType.GetProperty(property.Name);
                targetPropertyInfo = targetType.GetProperty(property.Name);
                targetPropertyInfo.SetValue(adaptedObject, originPropertyInfo.GetValue(originObject));
            }
            return adaptedObject;
        }

        private PropertyInfo[] GetCommonProperties(Type targetType)
        {
            if (!_targetTypePropertyInfos.ContainsKey(targetType.GUID))
            {
                _targetTypePropertyInfos.Add(targetType.GUID, targetType.GetProperties());
            }

            return _sourceTypePropertyInfos.Where(source => _targetTypePropertyInfos[targetType.GUID].Any(target => target.Name == source.Name)).ToArray();
        }
    }
}