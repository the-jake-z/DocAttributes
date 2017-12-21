using DocAttributes.Targets;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocAttributesTests.Targets
{
    [TestFixture]
    public class MethodTargetTest
    {
        private TypeTarget instance;
        private MethodTarget methodTarget;

        [SetUp]
        public void Setup()
        {
            instance = new TypeTarget(typeof(TypeTargetTesterClass));
            methodTarget = instance.Methods.Where(x => x.Name == "SomeGenericMethod").FirstOrDefault();
        }

        [Test]
        public void classShouldHaveMultipleMethods()
        {
            Assert.GreaterOrEqual(instance.Methods.Count, 1);
        }

        [Test]
        public void methodTarget_shouldNotBeNull()
        {
            Assert.NotNull(methodTarget);
        }

        [Test]
        public void methodTarget_summaryShouldHaveCorrectValue()
        {
            var correctValue = TypeTargetTesterClass.METHOD_TARGET_SUMMARY;
            Assert.AreEqual(correctValue, methodTarget.Summary);
        }

        [Test]
        public void methodTarget_returnsShouldHaveCorrectValue()
        {
            var correctValue = TypeTargetTesterClass.METHOD_TARGET_RETURNS;
            Assert.AreEqual(correctValue, methodTarget.ReturnDescription);
        }

        [Test]
        public void methodTarget_shouldCorrectlyDetermineReturnType()
        {
            Assert.AreEqual(typeof(string), methodTarget.ReturnType);
        }
    }
}
