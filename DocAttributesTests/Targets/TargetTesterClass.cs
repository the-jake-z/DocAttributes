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
        [AvailableSince("1.0")]
        public string SomeGenericMethod<[Summary("The first type")] T1,
            [Summary("The second type parameter")] T2>([Summary("The first parameter")] T1 obj1, [Summary("The second parameter")] T2 obj2)
        {
            return string.Empty;
        }
    }
}