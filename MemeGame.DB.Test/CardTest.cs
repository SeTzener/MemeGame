using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemeGame.DB.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void AddCard()
        {
            DbOperations db = new DbOperations(true);

            Assert.IsTrue(db.CreateCard());
        }
    }
}
