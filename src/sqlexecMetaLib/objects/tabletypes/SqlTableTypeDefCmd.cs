using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.tabletypes;

public record SqlTableTypeDefCmd(string Name) : ScriptResourceCommand
{
   public record Result(string Name, int ObjectId, string Schema, byte SystemTypeId, int UserTypeId
      , string FieldName, int? FieldIndex, bool IsNullable, string? TypeText
      , bool IsComputed, short? Size, byte? Precision, byte? Scale, bool IsIdentity
      , bool IsRowGuid, string DBName, string? FieldSchema) : SqlExecBaseResult, ISqlFieldNParamDefinition, ISqlItem
   {
      public int FieldSize => Size ?? 0;

      public string FieldTypeName => TypeText ?? string.Empty;

      public int FieldPrecision => Precision ?? 0;

      public int FieldScale => Scale ?? 0;

      public bool FieldIsNullable => IsNullable;

      public bool? FieldHasDefault => false;

      public bool? FieldIsOutput => false;

      public bool? FieldIsPrimaryKey => false;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.TableTypes;

      public string? FieldUDTSchema => null;

      public string? FieldUDTName => null;

      public int Id => ObjectId;

      public string SchemaName => Schema;

      public string Group => "tabletypes";

      public SqlGroupFlags GroupFlag => SqlGroupFlags.TableTypes;
   }

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.tabletype.sql";

   protected override Type AssemblyType => typeof(SqlTableTypeDefCmd);
}
