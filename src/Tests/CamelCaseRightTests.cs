namespace Tests
{
    using CamelCase;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CamelCaseRightTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("building", CamelCaseConverter.ToCamelCaseRight("BUILDING"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("building Property", CamelCaseConverter.ToCamelCaseRight("BUILDING Property"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("building Property", CamelCaseConverter.ToCamelCaseRight("Building Property"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("building PROPERTY", CamelCaseConverter.ToCamelCaseRight("BUILDING PROPERTY"));
        }
    }
}