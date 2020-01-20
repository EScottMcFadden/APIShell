using APIShell.ItemCounter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace APIShell.Test
{
    [TestClass]
    public class UnitTest1
    {
       
        [SetItemCounter("TestIncrementor", "TestAPI")]
        [TestMethod]
        public void TestIncrementor()
        {
            Assert.IsTrue(ItemCounter.ItemsCounter.Items.Count() > 0);

        }
    }
}
