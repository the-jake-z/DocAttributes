using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAttributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ReturnsAttribute: Attribute
    {
        public string Description { get; private set; }

        public ReturnsAttribute(string description)
        {
            Description = description;
        }
    }
}
