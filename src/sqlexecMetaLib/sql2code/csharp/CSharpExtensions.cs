using Sorling.SqlExecMeta.objects;

namespace Sorling.SqlExecMeta.sql2code.csharp;
public static class CSharpExtensions
{
   public static string? GetSuggestedPropertyName(this IEnumerable<SqlResultSetColumn> columns)
      => Sql2CSharp.GetProperResultSetName(
         columns.OrderBy(o => o.FieldIndex).FirstOrDefault(f => !string.IsNullOrEmpty(f.DbColumn.BaseTableName))?.DbColumn?.BaseTableName);
}
