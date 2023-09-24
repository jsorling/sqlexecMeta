using Sorling.SqlExecMeta.constraints;
using Sorling.SqlExecMeta.objects;
using Sorling.SqlExecMeta.objects.functions;
using Sorling.SqlExecMeta.objects.storedprocedures;
using Sorling.SqlExecMeta.objects.tables;
using Sorling.SqlExecMeta.objects.tabletypes;
using Sorling.SqlExecMeta.objects.triggers;
using Sorling.SqlExecMeta.objects.views;
using Sorling.SqlExecMeta.security;
using Sorling.SqlExecMeta.types;

namespace Sorling.SqlExecMeta;
public interface ISqlMetadataProvider
{
   public Task<IEnumerable<SqlObjectListItem>> GetSqlObjectsAsync(SqlGroupFlags filter = SqlGroupFlags.Objects
      , string? schema = null);

   public Task<string> GetSqlObjectTextAsync(string objectName);

   public Task<IEnumerable<string>> GetSqlSchemasAsync();

   public Task<IEnumerable<SqlFunctionDefCmd.Result>> GetSqlFunctionAsync(string schema, string objectName);

   public Task<IEnumerable<SqlStoredProcedureDefCmd.Result>> GetSqlStoredProcedureAsync(string schema, string objectName);

   public Task<IEnumerable<SqlViewDefCmd.Result>> GetSqlViewAsync(string schema, string objectName);

   public Task<IEnumerable<TableDefCmd.Result>> GetSqlTableAsync(string schemaName, string objectName);

   public Task<IEnumerable<SqlTableTypeDefCmd.Result>> GetSqlTableTypeAsync(string objectName);

   public Task<SqlObjectPrevNxt?> GetSqlObjectPrevNxtAsync(string currentName, string currentType, string? schema = null
      , SqlGroupFlags filter = SqlGroupFlags.Objects);

   public Task<IEnumerable<SqlScriptDescribUndeclaredParamsCmd.Result>> GetSqlUndeclaredParamsAsync(string tSql);

   public Task<IEnumerable<SqlDefaultConstraintListItem>> GetDefaultContraintsAsync(string? schema);

   public Task<IEnumerable<SqlCheckConstraintListItem>> GetCheckContraintsAsync(string? schema);

   public Task<IEnumerable<SqlTypeListItem>> GetSqlTypesAsync(string? schema);

   public Task<SqlTypeListItem?> GetSqlTypeAsync(string schema, string name);

   public Task<SqlDefaultConstraintListItem?> GetSqlDefaultConstraintAsync(string schema, string name);

   public Task<SqlTypePrevNxt?> GetSqlTypePrevNxtAsync(string current, string? schema);

   public Task<SqlDefaultConstraintPrevNxt?> GetSqlDefaultConstraintPrevNxtAsync(string current, string? schema);

   public Task<SqlCheckConstraintPrevNxt?> GetSqlCheckConstraintPrevNxtAsync(string current, string? schema);

   public Task<SqlCheckConstraintListItem?> GetSqlCheckConstraintAsync(string schema, string name);

   public Task<IEnumerable<SqlPrincipalListItem>> GetSqlPrincipalsAsync(string? typetext);

   public Task<SqlPrincipalPrevNxt?> GetSqlPrincipalPrevNxtAsync(string current, string? type);

   public Task<SqlPrincipalListItem?> GetSqlPrincipalAsync(string typetext, string name);

   public Task<IEnumerable<SqlPrincipalGroupListItem>> GetPrincipalGroupsAsync();

   public Task<IEnumerable<SqlTriggerListItem>> GetTriggersAsync(string? schema);

   public Task<SqlTriggerItem?> GetTriggerAsync(string schema, string name);

   public Task<SqlTriggerPrevNxt?> GetTriggerPrevNxtAsync(string current, string? schema);
}
