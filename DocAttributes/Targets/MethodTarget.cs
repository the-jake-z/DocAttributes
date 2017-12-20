using System;
using System.Collections.Generic;
using System.Reflection;

namespace DocAttributes.Targets
{
    [Summary("Used for constructors, methods, and delegates")]
    public class MethodTarget : Target
    {
        public Type ReturnType { get; protected set; }
        public ICollection<FieldTarget> Parameters;

        public MethodTarget(MethodInfo methodInfo) : base(methodInfo)
        {
            ReturnType = methodInfo.ReturnType;
            AddAllParameters(methodInfo.GetParameters());
        }

        public MethodTarget(ConstructorInfo constructorInfo) : base(constructorInfo)
        {
            ReturnType = constructorInfo.DeclaringType;
            AddAllParameters(constructorInfo.GetParameters());
        }

        public void AddParameter(FieldTarget fieldTarget)
        {
            if(Parameters == null) Parameters = new List<FieldTarget>();

            Parameters.Add(fieldTarget);
        }

        private void AddAllParameters(IEnumerable<ParameterInfo> parameters)
        {
            foreach (var parameter in parameters)
            {
                AddParameter(new FieldTarget(parameter));
            }
        }
    }
    
}