using System;

namespace DocAttributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class AvailableSinceAttribute: Attribute
    {
        private string Version { get; set; }
        public AvailableSinceAttribute(string version)
        {
            Version = version;
        }

        public override string ToString()
        {
            return Version;
        }
    }
}