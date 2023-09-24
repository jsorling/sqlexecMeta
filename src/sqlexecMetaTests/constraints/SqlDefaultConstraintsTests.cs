using Sorling.SqlExecMeta.constraints;

namespace sqlexecMetaTests.constraints;

[TestClass]
public class SqlDefaultConstraintsTests
{
   [TestMethod]
   public void ListDefaultConstraints() {
      IEnumerable<SqlDefaultConstraintListItem> dc
         = TestsInitialize.SqlMetadataProvider.GetDefaultContraintsAsync(null).Result;
      Assert.IsTrue(dc.Any());
   }
}
