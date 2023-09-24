using Sorling.SqlExecMeta.constraints;

namespace sqlexecMetaTests.constraints;

[TestClass]
public class SqlCheckConstraintsTests
{
   [TestMethod]
   public void ListCheckConstraints() {
      IEnumerable<SqlCheckConstraintListItem> cc
         = TestsInitialize.SqlMetadataProvider.GetCheckContraintsAsync(null).Result;
      Assert.IsTrue(cc.Any());
   }
}
