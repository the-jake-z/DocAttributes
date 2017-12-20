using System;
using System.Collections.Generic;

namespace DocAttributes.Targets
{
    [Summary("Used for modules, classes, structs, enums, and interfaces")]
    public class TypeTarget : Target
    {
        public ICollection<MethodTarget> Methods { get; protected internal set; }
        public ICollection<FieldTarget> Fields { get; protected internal set; }
        [MustSet]
        public Type Parent { get; protected set; }

        public TypeTarget(Type type, bool includeConstructors = false) : base(type)
        {
            Methods = new List<MethodTarget>();
            Fields = new List<FieldTarget>();
            Parent = type.BaseType;
            Name = type.AssemblyQualifiedName;
                
            foreach (var prop in type.GetProperties())
            {
                Fields.Add(new FieldTarget(prop));
            }

            foreach (var fieldInfo in type.GetFields())
            {
                if (fieldInfo.IsPublic)
                {
                    Fields.Add(new FieldTarget(fieldInfo));
                }
            }
            
            foreach (var eventInfo in type.GetEvents())
            {
                Fields.Add(new FieldTarget(eventInfo));
            }

            foreach (var method in type.GetMethods())
            {
                if (method.IsPublic && !method.IsPropertyAccessor() && method.DeclaringType == type)
                {
                    Methods.Add(new MethodTarget(method));
                }
            }

            if (includeConstructors)
            {
                foreach (var constructor in type.GetConstructors())
                {
                    if (constructor.IsPublic)
                    {
                        Methods.Add(new MethodTarget(constructor));
                    }
                }   
            }
        }

        public void AddMethod(MethodTarget mt)
        {
            Methods.Add(mt);
        }

        public void AddField(FieldTarget ft)
        {
            Fields.Add(ft);
        }
    }
}