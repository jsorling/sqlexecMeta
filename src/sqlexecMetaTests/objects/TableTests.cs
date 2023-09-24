using Sorling.SqlExecMeta.objects.tables;

namespace sqlexecMetaTests.objects;

[TestClass]
public class TableTests
{
   [TestMethod]
   public void GetTable() {
      IEnumerable<TableDefCmd.Result>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlTableAsync("sqmtest", "table1").Result;
      Assert.IsTrue(res?.Any());
   }
}
