using Sorling.SqlExecMeta.objects.functions;

namespace sqlexecMetaTests.objects;

[TestClass]
public class FunctionTests
{
   [TestMethod]
   public void GetFunction() {
      IEnumerable<SqlFunctionDefCmd.Result>? res
         = TestsInitialize.SqlMetadataProvider.GetSqlFunctionAsync("sqmtest", "FunctionB").Result;
      Assert.IsTrue(res?.Any());

      res = TestsInitialize.SqlMetadataProvider.GetSqlFunctionAsync("sqmtest", "FunctionA").Result;
      Assert.IsTrue(res?.Any());
   }
}
