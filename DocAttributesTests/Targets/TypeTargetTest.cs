using System.Linq;
using DocAttributes;
using DocAttributes.Targets;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace DocAttributesTests.Targets
{
    [TestFixture]
    public class TypeTargetTest
    {
        [Test]
        public void targetType_ShouldHaveCorrectNumberOfMethods()
        {
            var type = typeof(TypeTarget);
            var methodCount = type.GetMethods()
                .Where(x => x.IsPublic && !x.IsPropertyAccessor() && x.DeclaringType == type)
                .Count();
            
            var tt = new TypeTarget(type);
            
            Assert.AreEqual(methodCount, tt.Methods.Count);
        }

        [Test]
        public void targetTypeTester_shouldHaveCorrectSummary()
        {
            var typeTarget = new TypeTarget(typeof(TypeTargetTesterClass));
            
            Assert.AreEqual(TypeTargetTesterClass.TYPE_TARGET_SUMMARY, typeTarget.Summary);
        }

        [Test]
        public void targetTypeTester_shouldHaveCorrectAvailableSince()
        {
            var typeTarget = new TypeTarget(typeof(TypeTargetTesterClass));
            
            Assert.AreEqual(TypeTargetTesterClass.TYPE_TARGET_VERSION, typeTarget.AvailableVersion);
        }

        [Test]
        public void targetTypeTester_shouldHaveCorrectRelatedTypes()
        {
            var typeTarget = new TypeTarget(typeof(TypeTargetTesterClass));
            
            Assert.AreEqual(1, typeTarget.Related?.Length ?? 0);
            Assert.AreEqual(typeof(TypeTarget), typeTarget.Related?[0]);
        }

        [Test]
        public void targetTypeTester_shouldNotDoubleCountPropertyAccessors()
        {
            var typeTarget = new TypeTarget(typeof(TypeTargetTesterClass));
            
            Assert.AreEqual(2, typeTarget.Methods.Count);
            Assert.AreEqual(6, typeTarget.Fields.Count);
        }

        [Test]
        public void targetTypeTester_summaryShouldHaveNoValue_ifAttributeNotProvided()
        {
            var typeTarget = new TypeTarget(typeof(TypeTargetTest));

            Assert.IsNull(typeTarget.Summary);
        }
    }
}