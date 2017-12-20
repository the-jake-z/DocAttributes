using System;

namespace DocAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Event, Inherited = true)]
    public class MustSetAttribute: Attribute
    {
        
    }
}