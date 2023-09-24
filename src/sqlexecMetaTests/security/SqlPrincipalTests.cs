using Sorling.SqlExecMeta.security;

namespace sqlexecMetaTests.security;

[TestClass]
public class SqlPrincipalTests
{
   [TestMethod]
   public void ListPrincipals() {
      IEnumerable<SqlPrincipalListItem> pi
         = TestsInitialize.SqlMetadataProvider.GetSqlPrincipalsAsync(null).Result;
      Assert.IsTrue(pi.Any());
   }

   [TestMethod]
   public void GetPrincipalPrevNxt() {
      SqlPrincipalPrevNxt? pn = TestsInitialize.SqlMetadataProvider.GetSqlPrincipalPrevNxtAsync("SqlUsers.INFORMATION_SCHEMA", null).Result;
      Assert.IsTrue(pn != null);
      pn = TestsInitialize.SqlMetadataProvider.GetSqlPrincipalPrevNxtAsync("SqlUsers.INFORMATION_SCHEMA", "SqlUsers").Result;
      Assert.IsTrue(pn != null);
   }

   [TestMethod]
   public void GetSqlPrincipal() {
      SqlPrincipalListItem? pr
         = TestsInitialize.SqlMetadataProvider.GetSqlPrincipalAsync("SqlUsers", "INFORMATION_SCHEMA").Result;
      Assert.IsTrue(pr is not null);
   }

   [TestMethod]
   public void ListPrincipalGroups() {
      IEnumerable<SqlPrincipalGroupListItem> gr
         = TestsInitialize.SqlMetadataProvider.GetPrincipalGroupsAsync().Result;
      Assert.IsTrue(gr.Any());
   }
}
