using DocAttributes;
using DocAttributes.Targets;

namespace DocAttributesTests.Targets
{        
    [Summary(TYPE_TARGET_SUMMARY)]
    [AvailableSince(TYPE_TARGET_VERSION)]
    [SeeAlso(typeof(TypeTarget))]
    public class TypeTargetTesterClass
    {
        public const string TYPE_TARGET_SUMMARY = "Type target summary";
        public const string TYPE_TARGET_VERSION = "Type target version";
        
        public int Add(int a, int b)
        {
            return a + b;
        }
            
        public int SomeProperty { get; set; }
        public int SomeSecondField;
    }
}