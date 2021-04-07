using OnTrial.Logger;
using OnTrial.MSTest;
using OnTrial.MSTest.Api;

namespace OnTrial.Api.Test
{
    [TestSuite]
    public class ApiServiceTest : DefaultApiTestBase
    {
        TestService service = new TestService("http://localhost:5000/");
        int itemId = 1;

        public override void TestCaseInitialize()
        {
            base.TestInitialize();
            service.Create(new TestItem() { Id = itemId, Name = "Item1", IsComplete = false });
        }

        public override void TestCaseCleanup()
        {
            base.TestCleanup();
            service.Delete(itemId);
        }

        [TestCase]
        public void Verify_GettingItem()
        {
            Log.Information("Verify_GettingItem");

            //Verify the item exists
            TestItem item = service.Get(itemId).ToObject<TestItem>();
            Assert.AreEqual(item.Name, "Item1");
        }

        [TestCase]
        public void Verify_UpdatingName()
        {
            Log.Information("Verify_UpdatingName");
            service.Update(itemId, new TestItem() { Id = itemId, Name = "testing", IsComplete = false });

            //Verify the item has changed
            TestItem item = service.Get(itemId).ToObject<TestItem>();
            Assert.AreEqual(item.Name, "testing");
        }

        [TestCase]
        //EXPECTED TO FAIL
        public void Verify_UpdatingName_WithNoIdPassedInBody()
        {
            service.Update(itemId, new TestItem() { Name = "testing" });

            //Verify the item has changed
            TestItem item = service.Get(itemId).ToObject<TestItem>();
            Assert.AreEqual(item.Name, "testing");
        }
    }
}