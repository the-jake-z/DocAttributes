using System;
using System.Collections.Generic;
using System.Reflection;

namespace DocAttributes.Targets
{
    [Summary("Used for constructors, methods, and delegates")]
    [SeeAlso(typeof(ConstructorInfo), typeof(MethodInfo))]
    public class MethodTarget : Target
    {
        [Summary("Used to designate the type of the object returned by calling attributed method.")]
        public Type ReturnType { get; protected internal set; }
        [Summary("The parameters used by attributed method and their descriptions.")]
        public ICollection<FieldTarget> Parameters { get; protected internal set; }
        [Summary("Used to designate the meaning of the value returned by calling attributed method.")]
        public string ReturnDescription { get; protected internal set; }
        [Summary("Used to describe the generic arguments of this method.")]
        public ICollection<FieldTarget> Generics { get; protected internal set; }

        [Summary("Constructs a MethodTarget object based on a method.")]
        public MethodTarget(MethodInfo methodInfo) : base(methodInfo)
        {
            ReturnType = methodInfo.ReturnType;
            ReturnDescription = methodInfo.GetCustomAttribute<ReturnsAttribute>()?.Description ?? string.Empty;
            Generics = new List<FieldTarget>();

            foreach (var genericArgument in methodInfo.GetGenericArguments())
            {
                Generics.Add(new FieldTarget(genericArgument));
            }
            
            AddAllParameters(methodInfo.GetParameters());
        }

        [Summary("Constructs a MethodTarget object based on a constructor.")]
        public MethodTarget(ConstructorInfo constructorInfo) : base(constructorInfo)
        {
            // Note: no need for generics here.
            ReturnType = constructorInfo.DeclaringType;
            AddAllParameters(constructorInfo.GetParameters());
        }

        [Summary("Adds a parameter to the field target")]
        public void AddParameter(FieldTarget fieldTarget)
        {
            if(Parameters == null) Parameters = new List<FieldTarget>();

            Parameters.Add(fieldTarget);
        }

        [Summary("Adds all the parameters from caller to the parameters of this target.")]
        private void AddAllParameters(IEnumerable<ParameterInfo> parameters)
        {
            foreach (var parameter in parameters)
            {
                AddParameter(new FieldTarget(parameter)
                {
                    MustSet = !parameter.IsOptional,
                });
            }
        }
    }
    
}