using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;
using System.Data;

namespace Sorling.SqlExecMeta.objects;

public record SqlScriptDescribUndeclaredParamsCmd(string TSql) : SqlExecBaseCommand
{
   public record Result(int Parameter_Ordinal, string Name, int Suggested_System_Type_Id, string? Suggested_System_Type_Name
      , short Suggested_Max_Length, byte Suggested_Precision, byte Suggested_Scale, int? Suggested_User_Type_Id
      , string? Suggested_User_Type_Database, string? Suggested_User_Type_Schema, string? Suggested_User_Type_Name
      , string? Suggested_Assembly_Qualified_Type_Name, int? Suggested_Xml_Collection_Id
      , string? Suggested_Xml_Collection_Database, string? Suggested_Xml_Collection_Schema
      , string? Suggested_Xml_Collection_Name, bool Suggested_Is_Xml_Document, bool Suggested_Is_Case_Sensitive
      , bool Suggested_Is_Fixed_Length_Clr_Type, bool Suggested_Is_Input, bool Suggested_Is_Output
      , string? Formal_Parameter_Name, int Suggested_Tds_Type_Id, int Suggested_Tds_Length) : SqlExecBaseResult, ISqlFieldNParamDefinition
   {
      public int FieldSize => Suggested_Max_Length;

      public string FieldTypeName => Suggested_System_Type_Name?.Split('(').FirstOrDefault()?.Trim() ?? string.Empty;

      public int FieldPrecision => Suggested_Precision;

      public int FieldScale => Suggested_Scale;

      public bool FieldIsNullable => true;

      public bool? FieldHasDefault => false;

      public bool? FieldIsOutput => Suggested_Is_Output;

      public bool? FieldIsPrimaryKey => false;

      public SqlGroupFlags FieldObjectGroup => SqlGroupFlags.ResultSet;

      public string FieldName => Name;

      public int? FieldIndex => Parameter_Ordinal;

      public string? FieldUDTSchema => Suggested_User_Type_Schema;

      public string? FieldUDTName => Suggested_User_Type_Name;

      public string? FieldSchema => Suggested_User_Type_Schema;
   }

   public override CommandType SqlExecCommandType => CommandType.StoredProcedure;

   public override string SqlExecSqlText => "sp_describe_undeclared_parameters";
}
