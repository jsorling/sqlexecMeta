using Sorling.SqlExecMeta.objects.triggers;

namespace sqlexecMetaTests.objects;

[TestClass]
public class TriggerTests
{
   [TestMethod]
   public void GetTriggers() {
      IEnumerable<SqlTriggerListItem> res = TestsInitialize.SqlMetadataProvider.GetTriggersAsync(null).Result;
      Assert.IsTrue(res?.Any());

      res = TestsInitialize.SqlMetadataProvider.GetTriggersAsync("sqmtest").Result;
      Assert.IsTrue(res?.Any());

      res = TestsInitialize.SqlMetadataProvider.GetTriggersAsync("xsqmtestx").Result;
      Assert.IsFalse(res?.Any());
   }

   [TestMethod]
   public void GetTrigger() {
      SqlTriggerItem? tr = TestsInitialize.SqlMetadataProvider.GetTriggerAsync("sqmtest", "triggertable1").Result;
      Assert.IsNotNull(tr);
   }

   [TestMethod]
   public void GetTriggersPrevNxt() {
      SqlTriggerPrevNxt? pn = TestsInitialize.SqlMetadataProvider.GetTriggerPrevNxtAsync("sqmtest.triggertable1", null).Result;
      Assert.IsNotNull(pn);
   }
}
