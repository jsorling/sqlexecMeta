using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.functions;

public record SqlFunctionDefCmd(string Schema, string Name) : ScriptResourceCommand
{
   public record Result(string Name, int ObjectId, string Schema, string? FieldName, bool? HasDefault
      , int? FieldIndex, string? TypeText, bool IsNullable, bool? IsOutPut, bool IsResult, short? Size
      , byte? Precision, byte? Scale, string? UDTSchema, string? UDTName, string DBName, string Group
      , SqlGroupFlags GroupFlag, string? FieldSchema) : SqlExecBaseResult, ISqlFieldNParamDefinition, ISqlItem
   {
      public int FieldSize => Size ?? 0;

      public string FieldTypeName => TypeText ?? string.Empty;

      public int FieldPrecision => Precision ?? 0;

      public int FieldScale => Scale ?? 0;

      public bool? FieldIsOutput => IsOutPut;

      public bool? FieldIsPrimaryKey => null;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.Functions;

      public bool FieldIsNullable => IsNullable;

      public bool? FieldHasDefault => HasDefault ?? false;

      public string? FieldUDTSchema => UDTSchema;

      public string? FieldUDTName => UDTName;

      public int Id => ObjectId;

      public string SchemaName => Schema;
   }

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.function.sql";

   protected override Type AssemblyType => typeof(SqlFunctionDefCmd);
}
