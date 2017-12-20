using System;
using System.Reflection;

namespace DocAttributes.Targets
{
    [Summary("Used for field, events, properties, and parameters")]
    public class FieldTarget : Target
    {
        public Type Type { get; protected internal set; }
        public bool MustSet { get; protected internal set; }
        public FieldTarget(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            Type = propertyInfo.PropertyType;
            MustSet = propertyInfo.GetCustomAttribute<MustSetAttribute>() != null;
        }

        public FieldTarget(ParameterInfo parameterInfo) : base()
        {
            Type = parameterInfo.ParameterType;
            Name = parameterInfo.Name;
        }

        public FieldTarget(EventInfo eventInfo) : base(eventInfo)
        {
            Type = eventInfo.EventHandlerType;
        }

        public FieldTarget(FieldInfo fieldInfo) : base(fieldInfo)
        {
            Type = fieldInfo.FieldType;
        }
    }
}