using Sorling.SqlExecMeta;

namespace sqlexecMetaTests.security;

[TestClass]
public class SqlGroupFlagsTests
{
   [TestMethod]
   public void Principals() {
      SqlGroupFlags p = SqlGroupFlags.Principals;
      Assert.IsTrue(p.HasFlag(SqlGroupFlags.AppRoles)
         && p.HasFlag(SqlGroupFlags.DbRoles)
         && p.HasFlag(SqlGroupFlags.ExtGroupsAzureAD)
         && p.HasFlag(SqlGroupFlags.ExtUsersAzureAD)
         && p.HasFlag(SqlGroupFlags.SqlUsers)
         && p.HasFlag(SqlGroupFlags.UserAsymetricKeys)
         && p.HasFlag(SqlGroupFlags.UserCertificates)
         && p.HasFlag(SqlGroupFlags.WinGroups)
         && p.HasFlag(SqlGroupFlags.WinUsers)
         && !p.HasFlag(SqlGroupFlags.Objects)
         && !p.HasFlag(SqlGroupFlags.Tables));
   }
}
