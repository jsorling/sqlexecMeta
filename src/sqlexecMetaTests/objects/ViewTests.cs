using Sorling.SqlExecMeta.objects.views;

namespace sqlexecMetaTests.objects;

[TestClass]
public class ViewTests
{
   [TestMethod]
   public void GetView() {
      IEnumerable<SqlViewDefCmd.Result>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlViewAsync("sqmtest", "view1").Result;
      Assert.IsTrue(res?.Any());
   }
}
