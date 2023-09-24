using System.Data.Common;

namespace Sorling.SqlExecMeta.objects;

public record SqlResultSetColumn(DbColumn DbColumn) : ISqlFieldNParamDefinition
{
   public int FieldSize => DbColumn.ColumnSize ?? 0;

   public string FieldTypeName => DbColumn.DataTypeName ?? string.Empty;

   public int FieldPrecision => DbColumn.NumericPrecision ?? 0;

   public int FieldScale => DbColumn.NumericScale ?? 0;

   public bool FieldIsNullable => DbColumn.AllowDBNull ?? false;

   public bool? FieldHasDefault => false;

   public bool? FieldIsOutput => false;

   public bool? FieldIsPrimaryKey => false;

   public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.ResultSet;

   public string FieldName => DbColumn.ColumnName;

   public int? FieldIndex => DbColumn.ColumnOrdinal;

   public string? FieldUDTSchema => DbColumn.UdtAssemblyQualifiedName;

   public string? FieldUDTName => null;

   public string? FieldSchema => DbColumn.BaseSchemaName;
}
