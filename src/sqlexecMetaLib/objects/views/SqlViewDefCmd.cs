using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.views;

public record SqlViewDefCmd(string Schema, string Name) : ScriptResourceCommand
{
   public record Result(string Name, int ObjectId, string Schema, string FieldName, bool IsNullable
      , bool? HasDefault, int? FieldIndex, string? TypeText, short? Size, byte? Precision
      , byte? Scale, string DBName, string? FieldSchema) : SqlExecBaseResult
      , ISqlFieldNParamDefinition, ISqlItem
   {
      public int FieldSize => Size ?? 0;

      public string FieldTypeName => TypeText ?? string.Empty;

      public int FieldPrecision => Precision ?? 0;

      public int FieldScale => Scale ?? 0;

      public bool FieldIsNullable => IsNullable;

      public bool? FieldHasDefault => HasDefault ?? false;

      public bool? FieldIsOutput => false;

      public bool? FieldIsPrimaryKey => null;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.Views;

      public string? FieldUDTSchema => null;

      public string? FieldUDTName => null;

      public int Id => ObjectId;

      public string SchemaName => Schema;

      public string Group => "views";

      public SqlGroupFlags GroupFlag => SqlGroupFlags.Views;
   }

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.view.sql";

   protected override Type AssemblyType => typeof(SqlViewDefCmd);
}
