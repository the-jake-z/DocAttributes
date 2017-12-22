using System;
using System.Reflection;

namespace DocAttributes.Targets
{
    [Summary("Used for field, events, properties, and parameters")]
    [SeeAlso(typeof(ParameterInfo), typeof(EventInfo), typeof(FieldInfo), typeof(PropertyInfo))]
    public class FieldTarget : Target
    {
        [Summary("The type associated with this field.")]
        public Type Type { get; protected internal set; }
        [Summary("Whether or not this member must be set in order for normal operation.")]
        public bool MustSet { get; protected internal set; }
        
        [Summary("Constructs a FieldTarget based on PropertyInfo")]
        public FieldTarget(PropertyInfo propertyInfo) : base(propertyInfo)
        {
            Type = propertyInfo.PropertyType;
            MustSet = propertyInfo.GetCustomAttribute<MustSetAttribute>() != null;
        }
        
        [Summary("Constructs a FieldTarget based on ParameterInfo")]
        [SeeAlso(typeof(MethodTarget))]
        public FieldTarget(ParameterInfo parameterInfo) : base(parameterInfo)
        {
            Type = parameterInfo.ParameterType;
            Name = parameterInfo.Name;
        }

        [Summary("Constructs a FieldTarget based on EventInfo")]
        public FieldTarget(EventInfo eventInfo) : base(eventInfo)
        {
            Type = eventInfo.EventHandlerType;
        }

        [Summary("Constructs a FieldTarged based on FieldInfo. Sets the Type to be the field's type.")]
        public FieldTarget(FieldInfo fieldInfo) : base(fieldInfo)
        {
            Type = fieldInfo.FieldType;
        }

        
        [Summary("Used for generic type parameters which look more like fields.")]
        public FieldTarget(Type t) : base(t)
        {
            // Stubbed.
        }
    }
}