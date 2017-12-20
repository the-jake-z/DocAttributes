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
    }
}