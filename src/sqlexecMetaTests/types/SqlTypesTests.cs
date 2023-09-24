using Sorling.SqlExecMeta.types;

namespace sqlexecMetaTests.types;

[TestClass]
public class SqlTypeTests
{
   [TestMethod]
   public void ListTypes() {
      IEnumerable<SqlTypeListItem> ty
         = TestsInitialize.SqlMetadataProvider.GetSqlTypesAsync(null).Result;
      Assert.IsTrue(ty.Any());
   }

   [TestMethod]
   public void GetTypesPrevNxt() {
      SqlTypePrevNxt? pn = TestsInitialize.SqlMetadataProvider.GetSqlTypePrevNxtAsync("sys.varchar", null).Result;
      Assert.IsTrue(pn != null);
   }

   [TestMethod]
   public void GetSqlType() {
      SqlTypeListItem? ty
         = TestsInitialize.SqlMetadataProvider.GetSqlTypeAsync("sys", "int").Result;
      Assert.IsTrue(ty is not null);
   }
}
