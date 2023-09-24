using Microsoft.Extensions.Configuration;
using Sorling.SqlExec.runner;
using Sorling.SqlExecMeta;

namespace sqlexecMetaTests;

[TestClass]
public class TestsInitialize
{
   private static string? _sqlConnectionString;

   private static SqlExecRunner? _sqlExecRunner;

   public static string SQLConnectionString
      => _sqlConnectionString ?? throw new ApplicationException("Failed to load TestSecrets-configuration");

   public static SqlExecRunner SQLExecRunner => _sqlExecRunner ?? throw new ApplicationException("Failed to create SQLExecRunner");

   public static SqlMetadataProvider SqlMetadataProvider => new(SQLExecRunner);

   [AssemblyInitialize]
#pragma warning disable IDE0060 // Remove unused parameter
   public static void AssemblyInitialize(TestContext testContext) {
#pragma warning restore IDE0060 // Remove unused parameter
      IConfigurationSection conf = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json", true, false).AddUserSecrets<TestsInitialize>().Build().GetSection("TestSecrets");

      _sqlConnectionString = conf["SQLConnectionString"];
      _sqlExecRunner = new SqlExecRunner(SQLConnectionString);

      _ = _sqlExecRunner.ExecuteGOScript<TestScriptCommand>(new());
   }
}
