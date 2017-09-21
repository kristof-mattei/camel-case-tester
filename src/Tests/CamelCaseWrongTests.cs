namespace Tests
{
    using CamelCase;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CamelCaseWrongTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("building", CamelCaseConverter.ToCamelCaseWrong("BUILDING"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual("buildinG Property", CamelCaseConverter.ToCamelCaseWrong("BUILDING Property"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual("building Property", CamelCaseConverter.ToCamelCaseWrong("Building Property"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.AreEqual("buildinG PROPERTY", CamelCaseConverter.ToCamelCaseWrong("BUILDING PROPERTY"));
        }
    }
}