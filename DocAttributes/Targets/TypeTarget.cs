using System;
using System.Collections.Generic;

namespace DocAttributes.Targets
{
    [Summary("Used for modules, classes, structs, enums, and interfaces")]
    public class TypeTarget : Target
    {
        [Summary("The methods that are offered by this particular target.")]
        public ICollection<MethodTarget> Methods { get; protected internal set; }
        [Summary("Public fields and properties that are available for target.")]
        public ICollection<FieldTarget> Fields { get; protected internal set; }
        [Summary("Generic type parameters available for this target.")]
        public ICollection<FieldTarget> Generics { get; protected internal set; }
        [MustSet, Summary("If a derived class, the type of the parent.")]
        public Type Parent { get; protected set; }

        [Summary("Constructs a type target from a given type.")]
        public TypeTarget(Type type, bool includeConstructors = false) : base(type)
        {
            Methods = new List<MethodTarget>();
            Fields = new List<FieldTarget>();
            Generics = new List<FieldTarget>();
            
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
                // Property accessors are technically treated as method calls by .NET. They become
                // special methods that start with 'get_' or 'set_'. Since these are covered by 
                // the field information, we ignore them here so we don't present any duplicates
                // into the documentation generated for this type.
                if (method.IsPublic && !method.IsPropertyAccessor() && method.DeclaringType == type)
                {
                    Methods.Add(new MethodTarget(method));
                }
            }

            foreach (var generic in type.GetGenericArguments())
            {
                Generics.Add(new FieldTarget(generic));
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

        [Summary("Adds a method target to attributed type target.")]
        public void AddMethod(MethodTarget mt)
        {
            Methods.Add(mt);
        }

        [Summary("Adds a field to attributed type target.")]
        public void AddField(FieldTarget ft)
        {
            Fields.Add(ft);
        }
    }
}