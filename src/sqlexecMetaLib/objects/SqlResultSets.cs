using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.extensions;
using Sorling.SqlExec.runner;
using Sorling.SqlExecMeta.objects.extensions;
using Sorling.SqlExecMeta.objects.storedprocedures;
using System.Data;
using System.Data.SqlClient;

namespace Sorling.SqlExecMeta.objects;

public class SqlResultSets
{
   private readonly string _connectionString;

   public SqlResultSets(string connectionString) => _connectionString = connectionString;

   private record EmptyCmd() : SqlExecBaseCommand
   {
      public override CommandType SqlExecCommandType => CommandType.Text;

      public override string SqlExecSqlText => "";
   }

   private async Task<string> GetUndeclaredDeclaredAsync(string sql) {
      SqlMetadataProvider mp = new(new SqlExecRunner(_connectionString));
      IEnumerable<SqlScriptDescribUndeclaredParamsCmd.Result> undec = await mp.GetSqlUndeclaredParamsAsync(sql);
      return undec.Any()
         ? $"{string.Join("\r\n", undec.Where(w => w.FieldName != string.Empty).Select(s => $"declare {s.FieldName}  {s.GetSqlTypeDeclaration()}"))}\r\n{sql}"
         : sql;
   }

   public async Task<(Dictionary<int, IEnumerable<SqlResultSetColumn>> ResultSets, string QuerySql)> GetResultSetsAsync(string sql) {
      Dictionary<int, IEnumerable<SqlResultSetColumn>> resultsets = new();

      using SqlConnection con = new(_connectionString);
      using SqlCommand cmd = con.SqlExecCreatePreparedCommand(new EmptyCmd());
      CommandBehavior combehavior = CommandBehavior.KeyInfo | CommandBehavior.SchemaOnly | CommandBehavior.CloseConnection;

      string qsql = await GetUndeclaredDeclaredAsync(sql);
      cmd.CommandText = qsql;
      await con.OpenAsync();

      int rowsetindex = 0;
      using SqlDataReader r = await cmd.ExecuteReaderAsync(combehavior);
      do {
         if (r.FieldCount > 0) {
            resultsets.Add(rowsetindex, (await r.GetColumnSchemaAsync()).Where(w => !(w.IsHidden ?? false)).Select(s => new SqlResultSetColumn(s)));
         }

         rowsetindex++;
      } while (await r.NextResultAsync());

      return (resultsets, qsql);
   }

   public async Task<(Dictionary<int, IEnumerable<SqlResultSetColumn>> ResultSets, string QuerySql)> GetSPResultSetsAsync(string spName, IEnumerable<SqlStoredProcedureDefCmd.Result> parameters) {
      string sql = parameters.Any()
           ? $"{string.Join("\r\n", parameters.Where(w => w.FieldName != string.Empty).Select(s => $"declare {s.FieldName}  {s.GetSqlTypeDeclaration()}"))}\r\n"
           : "";

      sql += $"exec {spName} {string.Join(", ", parameters.Where(w => w.FieldName != string.Empty).Select(s => $"{s.FieldName} = {s.FieldName}"))} ";

      return await GetResultSetsAsync(sql);
   }
}
