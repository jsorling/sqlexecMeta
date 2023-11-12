using Sorling.SqlExecMeta;

namespace sqlexecMetaTests;

[TestClass]
public class SqlGroupFlagTests
{
   [TestMethod]
   public void TopLevel() {
      SqlGroupFlags tl = SqlGroupFlags.TopLevel;
      Assert.IsTrue(tl.HasFlag(SqlGroupFlags.Tables));
   }
}
