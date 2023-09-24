using Sorling.SqlExecMeta;
using Sorling.SqlExecMeta.objects;
using Sorling.SqlExecMeta.objects.storedprocedures;

namespace sqlexecMetaTests.objects;

[TestClass]
public class StoredProcedureTests
{
   [TestMethod]
   public void GetSPs() {
      IEnumerable<SqlObjectListItem>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlObjectsAsync(SqlGroupFlags.StoredProcedures, "sqmtest").Result;
      Assert.IsTrue(res?.Any());
   }

   [TestMethod]
   public void GetSPDetailNoResultNoParameters() {
      IEnumerable<SqlStoredProcedureDefCmd.Result>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlStoredProcedureAsync("sqmtest", "spnoresnopar").Result;
      Assert.IsTrue(res?.Any());
   }

   [TestMethod]
   public void GetText() {
      SqlMetadataProvider sp = new(TestsInitialize.SQLExecRunner);
      string res = sp.GetSqlObjectTextAsync("sqmtest.view1").Result;
      Assert.IsTrue(res?.Any());
   }

}
