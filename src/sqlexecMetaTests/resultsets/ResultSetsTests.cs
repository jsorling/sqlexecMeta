using Sorling.SqlExecMeta.objects;
using Sorling.SqlExecMeta.objects.storedprocedures;

namespace sqlexecMetaTests.resultsets;

[TestClass]
public class ResultSetsTests
{
   [TestMethod]
   public void GetResultSetColumns() {
      SqlResultSets md = new(TestsInitialize.SQLConnectionString);
      Dictionary<int, IEnumerable<SqlResultSetColumn>> cols = md.GetResultSetsAsync("select cast(1 as nvarchar(65)) astring;select cast(1 as int) anint").Result.ResultSets;

      Assert.IsTrue(cols.Count > 0);
   }

   [TestMethod]
   public void GetResultSetColumnsUndec() {
      SqlResultSets md = new(TestsInitialize.SQLConnectionString);
      Dictionary<int, IEnumerable<SqlResultSetColumn>> cols = md.GetResultSetsAsync("select cast(@n1 as nvarchar(65)) astring;select cast(@n2 as int) anint").Result.ResultSets;

      Assert.IsTrue(cols.Count > 0);
   }

   [TestMethod]
   public void GetRSSPNoResultSets() {
      IEnumerable<SqlStoredProcedureDefCmd.Result> res
         = TestsInitialize.SqlMetadataProvider.GetSqlStoredProcedureAsync("sqmtest", "spnoresnopar").Result;

      SqlResultSets md = new(TestsInitialize.SQLConnectionString);
      Dictionary<int, IEnumerable<SqlResultSetColumn>> resultsets = md.GetSPResultSetsAsync("sqmtest.spnoresnopar", res).Result.ResultSets;

      Assert.IsTrue(resultsets.Count == 0);
   }
   [TestMethod]
   public void GetRSSPOneResultSet() {
      IEnumerable<SqlStoredProcedureDefCmd.Result> res
         = TestsInitialize.SqlMetadataProvider.GetSqlStoredProcedureAsync("sqmtest", "sponeresultset").Result;

      SqlResultSets md = new(TestsInitialize.SQLConnectionString);
      Dictionary<int, IEnumerable<SqlResultSetColumn>> resultsets = md.GetSPResultSetsAsync("sqmtest.sponeresultset", res).Result.ResultSets;

      Assert.IsTrue(resultsets.Count == 1);
   }

   [TestMethod]
   public void GetRSSPManyResultSet() {
      IEnumerable<SqlStoredProcedureDefCmd.Result> res
         = TestsInitialize.SqlMetadataProvider.GetSqlStoredProcedureAsync("sqmtest", "spmanyresultset").Result;

      SqlResultSets md = new(TestsInitialize.SQLConnectionString);
      Dictionary<int, IEnumerable<SqlResultSetColumn>> resultsets = md.GetSPResultSetsAsync("sqmtest.spmanyresultset", res).Result.ResultSets;

      Assert.IsTrue(resultsets.Count > 1);
   }

   [TestMethod]
   public void GetUndeclared() {
      IEnumerable<SqlScriptDescribUndeclaredParamsCmd.Result> res = TestsInitialize.SqlMetadataProvider
         .GetSqlUndeclaredParamsAsync("select cast(@name as int)").Result;

      Assert.IsTrue(res.Any());
   }
}
