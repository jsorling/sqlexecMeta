using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.tables;

public record TableDefCmd(string Schema, string Name) : ScriptResourceCommand
{
   public record Result(string Name, int ObjectId, string Schema, string FieldName, int? FieldIndex
      , bool IsNullable, string? TypeText, bool? HasDefault, bool IsPrimaryKey, short? Size, byte? Precision
      , byte? Scale, bool IsIdentity, bool IsComputed, bool IsRowGuid, string DBName, string? FieldSchema)
      : SqlExecBaseResult, ISqlFieldNParamDefinition, ISqlItem
   {
      public int FieldSize => Size ?? 0;

      public string FieldTypeName => TypeText ?? string.Empty;

      public int FieldPrecision => Precision ?? 0;

      public int FieldScale => Scale ?? 0;

      public bool? FieldIsOutput => null;

      public bool FieldIsNullable => IsNullable;

      public bool? FieldHasDefault => HasDefault ?? false;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.Tables;

      public string? FieldUDTSchema => null;

      public string? FieldUDTName => null;

      public bool? FieldIsPrimaryKey => IsPrimaryKey;

      public int Id => ObjectId;

      public string SchemaName => Schema;

      public string Group => "tables";

      public SqlGroupFlags GroupFlag => SqlGroupFlags.Tables;
   }

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.table.sql";

   protected override Type AssemblyType => typeof(TableDefCmd);
}
