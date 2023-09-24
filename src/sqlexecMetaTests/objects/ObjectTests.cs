using Sorling.SqlExecMeta.objects;

namespace sqlexecMetaTests.objects;

[TestClass]
public class ObjectTests
{
   [TestMethod]
   public void GetSchemas() {
      IEnumerable<string>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlSchemasAsync().Result;
      Assert.IsTrue(res?.Any());
   }

   [TestMethod]
   public void GetPrevNxt() {
      SqlObjectPrevNxt? res = TestsInitialize.SqlMetadataProvider.GetSqlObjectPrevNxtAsync(
         "sqmtest.table1", "tables").Result;
      Assert.IsTrue(res is not null);
   }
}
