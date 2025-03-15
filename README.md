# sqlexecMeta
SQL Server objects
## Nuget source
https://pkgs.dev.azure.com/sorling/PublicFeed/_packaging/PublicFeed/nuget/v3/index.json
## Objects
```C#
public class SqlMetadataProvider(ISqlExecRunner sqlExecRunner) : ISqlMetadataProvider

public async Task<IEnumerable<SqlObjectListItem>> GetSqlObjectsAsync(
      SqlGroupFlags filter = SqlGroupFlags.Objects, string? schema = null) =>
      await _sqlExecRunner.QueryAsync<SqlObjectListItem, SqlObjectListCmd>(new(schema, filter));
``` 
## SQLGroupFlags
```C#
public enum SqlGroupFlags : long
{
   Tables = 1,
   Views = 2,
   StoredProcedures = 4,
   Functions = 8,
   TableTypes = 16,
   ResultSet = 32,
   Types = 64,
   DefaultConstraints = 128,
   CheckConstraints = 256,
   DbRoles = 512,
   AppRoles = 1024,
   UserCertificates = 2048,
   ExtUsersAzureAD = 4096,
   WinGroups = 8192,
   UserAsymetricKeys = 16384,
   SqlUsers = 32768,
   WinUsers = 65536,
   ExtGroupsAzureAD = 131072,
   Triggers = 262144,
   Schemas = 524288,
   Scripts = 1048576,
   PrimaryKeys = 2097152,
   ForeignKeys = 4194304,
   UniqueKeys = 8388608,
   Principals = DbRoles
      | AppRoles
      | ExtUsersAzureAD
      | UserCertificates
      | WinGroups
      | UserAsymetricKeys
      | SqlUsers
      | WinUsers
      | ExtGroupsAzureAD,
   TopLevel = Tables
      | Views
      | StoredProcedures
      | Functions,
   Objects = ~0
}
```