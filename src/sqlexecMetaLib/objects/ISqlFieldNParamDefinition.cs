namespace Sorling.SqlExecMeta.objects;

public interface ISqlFieldNParamDefinition
{
   public int FieldSize { get; }

   public string FieldTypeName { get; }

   public int FieldPrecision { get; }

   public int FieldScale { get; }

   public bool FieldIsNullable { get; }

   public bool? FieldHasDefault { get; }

   public bool? FieldIsOutput { get; }

   public bool? FieldIsPrimaryKey { get; }

   public SqlGroupFlags FieldObjectGroup { get; }

   public string? FieldName { get; }

   public int? FieldIndex { get; }

   public string? FieldUDTSchema { get; }

   public string? FieldUDTName { get; }

   public string? FieldSchema { get; }
}
