using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MemeGame.DB.Test
{
    [TestClass]
    public class CardTest
    {
        [TestMethod]
        public void AddCard()
        {
            Tools tools = new Tools(true);
            tools.RelocateImage();
        }
    }
}
