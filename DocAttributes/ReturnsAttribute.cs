using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAttributes
{
    [Summary("Used to describe the meaning of the object returned by calling this method.")]
    [AttributeUsage(AttributeTargets.Method)]
    public class ReturnsAttribute: Attribute
    {
        [Summary("Description of the target's returned by the method target.")]
        public string Description { get; private set; }

        public ReturnsAttribute(string description)
        {
            Description = description;
        }
    }
}
