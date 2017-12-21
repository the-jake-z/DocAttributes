using System;

namespace DocAttributes
{
    [Summary("Marks whether a field target needs to be set in order to process normal operations.")]
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Event, Inherited = true)]
    public class MustSetAttribute: Attribute
    {

    }
}