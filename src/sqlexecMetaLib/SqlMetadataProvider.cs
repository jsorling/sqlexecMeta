using Sorling.SqlExec.runner;
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

public class SqlMetadataProvider : ISqlMetadataProvider
{
   private readonly ISqlExecRunner _sqlExecRunner;

   public SqlMetadataProvider(ISqlExecRunner sqlExecRunner) => _sqlExecRunner = sqlExecRunner;

   public async Task<IEnumerable<SqlFunctionDefCmd.Result>> GetSqlFunctionAsync(string schema, string objectName)
      => await _sqlExecRunner.QueryAsync<SqlFunctionDefCmd.Result, SqlFunctionDefCmd>(new(schema, objectName));

   public async Task<IEnumerable<SqlObjectListItem>> GetSqlObjectsAsync(
      SqlGroupFlags filter = SqlGroupFlags.Objects, string? schema = null) =>
      await _sqlExecRunner.QueryAsync<SqlObjectListItem, SqlObjectListCmd>(new(schema, filter));

   public async Task<string> GetSqlObjectTextAsync(string objectName)
      => string.Join("",
         (await _sqlExecRunner.QueryAsync<SqlObjectTextCmd.Result, SqlObjectTextCmd>(
            new(objectName))).Select(s => s.Line));

   public async Task<IEnumerable<string>> GetSqlSchemasAsync()
      => (await _sqlExecRunner.QueryAsync<SchemasListCmd.Result, SchemasListCmd>(new())).Select(s => s.Name);

   public async Task<IEnumerable<SqlStoredProcedureDefCmd.Result>> GetSqlStoredProcedureAsync(string schema, string objectName)
      => await _sqlExecRunner.QueryAsync<SqlStoredProcedureDefCmd.Result, SqlStoredProcedureDefCmd>(new(schema, objectName));

   public async Task<IEnumerable<SqlViewDefCmd.Result>> GetSqlViewAsync(string schema, string objectName)
      => await _sqlExecRunner.QueryAsync<SqlViewDefCmd.Result, SqlViewDefCmd>(new(schema, objectName));

   public async Task<IEnumerable<TableDefCmd.Result>> GetSqlTableAsync(string schemaName, string objectName)
      => await _sqlExecRunner.QueryAsync<TableDefCmd.Result, TableDefCmd>(new(schemaName, objectName));

   public async Task<IEnumerable<SqlTableTypeDefCmd.Result>> GetSqlTableTypeAsync(string objectName)
      => await _sqlExecRunner.QueryAsync<SqlTableTypeDefCmd.Result, SqlTableTypeDefCmd>(new(objectName));

   public async Task<SqlObjectPrevNxt?> GetSqlObjectPrevNxtAsync(string currentName, SqlGroupFlags currentType, string? schema = null
      , SqlGroupFlags filter = SqlGroupFlags.Objects)
     => await _sqlExecRunner.QueryFirstRowAsync<SqlObjectPrevNxt, SqlObjectPrevNxtCmd>(new(currentName, currentType, schema, filter));

   public async Task<IEnumerable<SqlScriptDescribUndeclaredParamsCmd.Result>> GetSqlUndeclaredParamsAsync(string tSql)
      => await _sqlExecRunner.QueryAsync<SqlScriptDescribUndeclaredParamsCmd.Result, SqlScriptDescribUndeclaredParamsCmd>(new(tSql));

   public async Task<IEnumerable<SqlDefaultConstraintListItem>> GetDefaultContraintsAsync(string? schema)
      => await _sqlExecRunner.QueryAsync<SqlDefaultConstraintListItem, SqlDefaultConstraintListCmd>(new(schema, null));

   public async Task<IEnumerable<SqlCheckConstraintListItem>> GetCheckContraintsAsync(string? schema)
      => await _sqlExecRunner.QueryAsync<SqlCheckConstraintListItem, SqlCheckConstraintListCmd>(new(schema, null));

   public async Task<IEnumerable<SqlTypeListItem>> GetSqlTypesAsync(string? schema)
      => await _sqlExecRunner.QueryAsync<SqlTypeListItem, SqlTypeListCmd>(new(schema));

   public async Task<SqlTypePrevNxt?> GetSqlTypePrevNxtAsync(string current, string? schema)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlTypePrevNxt, SqlTypesPrevNxtCmd>(new(current, schema));

   public async Task<SqlTypeListItem?> GetSqlTypeAsync(string schema, string name)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlTypeListItem, SqlTypeListCmd>(new(schema, name));

   public async Task<SqlDefaultConstraintListItem?> GetSqlDefaultConstraintAsync(string schema, string name)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlDefaultConstraintListItem, SqlDefaultConstraintListCmd>(new(schema, name));

   public async Task<SqlDefaultConstraintPrevNxt?> GetSqlDefaultConstraintPrevNxtAsync(string current, string? schema)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlDefaultConstraintPrevNxt, SqlDefaultConstraintPrevNxtCmd>(new(current, schema));

   public async Task<SqlCheckConstraintPrevNxt?> GetSqlCheckConstraintPrevNxtAsync(string current, string? schema)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlCheckConstraintPrevNxt, SqlCheckConstraintPrevNxtCmd>(new(current, schema));

   public async Task<SqlCheckConstraintListItem?> GetSqlCheckConstraintAsync(string schema, string name)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlCheckConstraintListItem, SqlCheckConstraintListCmd>(new(schema, name));

   public async Task<IEnumerable<SqlPrincipalListItem>> GetSqlPrincipalsAsync(string? typetext)
      => await _sqlExecRunner.QueryAsync<SqlPrincipalListItem, SqlPrincipalListCmd>(new(typetext, null));

   public async Task<SqlPrincipalPrevNxt?> GetSqlPrincipalPrevNxtAsync(string current, SqlGroupFlags? type)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlPrincipalPrevNxt, SqlPrincipalPrevNxtCmd>(new(current, type));

   public async Task<SqlPrincipalListItem?> GetSqlPrincipalAsync(string typetext, string name)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlPrincipalListItem, SqlPrincipalListCmd>(new(typetext, name));

   public async Task<IEnumerable<SqlPrincipalGroupListItem>> GetPrincipalGroupsAsync()
      => await _sqlExecRunner.QueryAsync<SqlPrincipalGroupListItem, SqlPrincipalGroupListCmd>(new());

   public async Task<IEnumerable<SqlTriggerListItem>> GetTriggersAsync(string? schema)
      => await _sqlExecRunner.QueryAsync<SqlTriggerListItem, SqlTriggerListCmd>(new(schema));

   public async Task<SqlTriggerItem?> GetTriggerAsync(string schema, string name)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlTriggerItem, SqlTriggerItemCmd>(new(schema, name));

   public async Task<SqlTriggerPrevNxt?> GetTriggerPrevNxtAsync(string current, string? schema)
      => await _sqlExecRunner.QueryFirstRowAsync<SqlTriggerPrevNxt, SqlTriggersPrevNxtCmd>(new(current, schema));
}
