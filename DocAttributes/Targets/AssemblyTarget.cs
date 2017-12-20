using System.Collections.Generic;
using System.Reflection;

namespace DocAttributes.Targets
{
    public class AssemblyTarget : Target
    {
        public ICollection<TypeTarget> Types { get; protected set; }
        
        public AssemblyTarget(Assembly assembly)
        {
            Name = assembly.FullName;
            Summary = assembly.GetCustomAttribute<SummaryAttribute>().ToString();
            Types = new List<TypeTarget>();

            foreach (var type in assembly.GetTypes())
            {
                Types.Add(new TypeTarget(type));
            }
        }
    }

}