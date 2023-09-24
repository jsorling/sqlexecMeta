using Sorling.SqlExecMeta.objects.tabletypes;

namespace sqlexecMetaTests.objects;

[TestClass]
public class TableTypeTests
{
   [TestMethod]
   public void GetTableType() {
      IEnumerable<SqlTableTypeDefCmd.Result>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlTableTypeAsync("sqmtest.tabletype1").Result;
      Assert.IsTrue(res?.Any());
   }
}
