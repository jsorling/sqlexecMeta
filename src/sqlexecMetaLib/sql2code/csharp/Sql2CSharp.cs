using Sorling.SqlExecMeta.extenssions;
using Sorling.SqlExecMeta.objects;
using Sorling.SqlExecMeta.objects.extensions;
using System.Globalization;

namespace Sorling.SqlExecMeta.sql2code.csharp;

public class Sql2CSharp : ISql2CodeMapper
{
   private static readonly TextInfo _textInfo = new CultureInfo("en-US", false).TextInfo;

   public string MapSql2CodeProperty(ISqlFieldNParamDefinition sqlFieldNParam)
      => $"[SqlSource(\"{sqlFieldNParam.FieldName}\", \"{sqlFieldNParam.GetSqlFieldDeclaration()}\", \"{0}\")] {sqlFieldNParam.GetNetTypeDeclaration()} {GetProperFieldName(sqlFieldNParam)}";

   private static string GetProperFieldName(ISqlFieldNParamDefinition sqlFieldNParam)
      => GetProperName(sqlFieldNParam.FieldName) ?? "NoNameField";

   public static string? GetProperResultSetName(string? resultSetName)
      => GetProperName(resultSetName);

   private static string? GetProperName(string? name) {
      if (string.IsNullOrEmpty(name))
         return null;

      string? result = name.TrimStart('@').ToFirstUpperCase().Replace(' ', '_');
      return CSharpConsts.IsKeyword(result) ? "@" + result : result;
   }

   public string MapSql2CodeVar(ISqlFieldNParamDefinition sqlFieldNParam)
      => $"{sqlFieldNParam.GetNetTypeDeclaration()} {GetProperFieldName(sqlFieldNParam)}";
}
