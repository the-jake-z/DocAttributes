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

        [Test]
        public void methodTarget_ShouldHaveSomeGenerics()
        {
            Assert.AreNotEqual(0, methodTarget.Generics.Count);
            Assert.AreEqual(2, methodTarget.Generics.Count);
        }

        [Test]
        public void methodTarget_GenericArguments_ShouldHaveSummaryValues()
        {
            Assert.IsNotNull(methodTarget.Generics.ElementAt(0));
            Assert.IsNotNull(methodTarget.Generics.ElementAt(1));
            Assert.AreEqual("g1", methodTarget.Generics.ElementAt(0).Summary);
            Assert.AreEqual("g2", methodTarget.Generics.ElementAt(1).Summary);
        }

        [Test]
        public void methodTarget_ShouldHaveSomeParameters()
        {
            Assert.AreNotEqual(0, methodTarget.Parameters.Count);
            Assert.AreEqual(2, methodTarget.Parameters.Count);
        }

        [Test]
        public void methodTarget_Parameters_ShouldHaveSummaryValues()
        {
            Assert.IsNotNull(methodTarget.Parameters.ElementAt(0));
            Assert.IsNotNull(methodTarget.Parameters.ElementAt(1));
            Assert.AreEqual("p1", methodTarget.Parameters.ElementAt(0).Summary);
            Assert.AreEqual("p2", methodTarget.Parameters.ElementAt(1).Summary);
        }

        [Test]
        public void methodTarget_AvailalabeSince_ShouldHaveCorrectValue()
        {
            Assert.AreEqual("as", methodTarget.AvailableVersion);
        }
    }
}
