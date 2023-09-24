using Sorling.SqlExecMeta.helpers;

namespace sqlexecMetaTests.helpers;

[TestClass]
public class SqlIdentifierHelperTests
{
   [TestMethod]
   public void GetSchemaNName() {
      (string? schema, string? name) = SqlIdentifierHelper.GetSchemaNName("sys.int");
      Assert.IsTrue(schema == "sys" && name == "int");
      (schema, name) = SqlIdentifierHelper.GetSchemaNName("db.sys.int");
      Assert.IsTrue(schema == "sys" && name == "int");
      (schema, name) = SqlIdentifierHelper.GetSchemaNName("int");
      Assert.IsTrue(schema is null && name == "int");
   }

   [TestMethod]
   public void GetSchemaOrName() {
      Assert.IsTrue(SqlIdentifierHelper.GetName("sys.int") == "int");
      Assert.IsTrue(SqlIdentifierHelper.GetSchema("sys.int") == "sys");
   }
}
