using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.storedprocedures;

public record SqlStoredProcedureDefCmd(string Schema, string Name) : ScriptResourceCommand
{
   public record Result(string Name, int ObjectId, string Schema, string FieldName, bool? HasDefault
      , int? FieldIndex, string? TypeText, bool? IsNullable, bool? IsOutPut, short? Size, byte? Precision
      , byte? Scale, string? UDTSchema, string? UDTName, string DBName, string? FieldSchema) : SqlExecBaseResult
      , ISqlFieldNParamDefinition, ISqlItem
   {
      public int FieldSize => Size ?? 0;

      public string FieldTypeName => TypeText ?? string.Empty;

      public int FieldPrecision => Precision ?? 0;

      public int FieldScale => Scale ?? 0;

      public bool? FieldIsOutput => IsOutPut ?? false;

      public bool? FieldIsPrimaryKey => false;

      public bool? FieldHasDefault => HasDefault ?? false;

      public bool FieldIsNullable => IsNullable ?? false;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.StoredProcedures;

      public string? FieldUDTSchema => UDTSchema;

      public string? FieldUDTName => UDTName;

      public int Id => ObjectId;

      public string SchemaName => Schema;

      public string Group => "storedprocedures";

      public SqlGroupFlags GroupFlag => SqlGroupFlags.StoredProcedures;
   }

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.storedprocedure.sql";

   protected override Type AssemblyType => typeof(SqlStoredProcedureDefCmd);
}
