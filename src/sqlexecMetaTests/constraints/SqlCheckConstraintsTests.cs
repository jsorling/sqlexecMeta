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

   [TestMethod]
   public void ListCheckConstraintsForObject() {
      IEnumerable<SqlCheckConstraintListItem> cc
         = TestsInitialize.SqlMetadataProvider.GetCheckContraintsForObjectAsync("sqmtest.table2").Result;
      Assert.IsTrue(cc.Any());
   }
}
