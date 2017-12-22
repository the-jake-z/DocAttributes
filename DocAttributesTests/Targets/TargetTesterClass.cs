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
        public const string METHOD_TARGET_SUMMARY = "Method target summary";
        public const string METHOD_TARGET_RETURNS = "Method target returns";
        
        public int Add(int a, int b)
        {
            return a + b;
        }
            
        public int SomeProperty { get; set; }
        public int SomeSecondField;

        [Summary(METHOD_TARGET_SUMMARY)]
        [Returns(METHOD_TARGET_RETURNS)]
        [AvailableSince("as")]
        public string SomeGenericMethod<[Summary("g1")] T1,
            [Summary("g2")] T2>([Summary("p1")] T1 obj1, [Summary("p2")] T2 obj2)
        {
            return string.Empty;
        }
    }
}