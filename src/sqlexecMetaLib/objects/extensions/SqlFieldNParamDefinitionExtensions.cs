using System.Data;
using System.Globalization;

namespace Sorling.SqlExecMeta.objects.extensions;

public static class SqlFieldNParamDefinitionExtensions
{
   public static string GetSqlFieldDeclaration(this ISqlFieldNParamDefinition sqlFNPDef)
      => GetSqlDbType(sqlFNPDef) switch {
         SqlDbType.BigInt => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Binary => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Bit => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Char => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.DateTime => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Decimal => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Float => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Image => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Int => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Money => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.NChar => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.NText => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.NVarChar => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Real => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.UniqueIdentifier => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.SmallDateTime => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.SmallInt => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.SmallMoney => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Text => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Timestamp => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.TinyInt => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.VarBinary => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.VarChar => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Variant => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Xml => $"{GetSqlTypeDeclaration(sqlFNPDef)}",
         SqlDbType.Udt => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Structured => $"{GetSqlTypeDeclaration(sqlFNPDef)}",
         SqlDbType.Date => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.Time => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.DateTime2 => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         SqlDbType.DateTimeOffset => $"{GetSqlTypeDeclaration(sqlFNPDef)} {(sqlFNPDef.FieldIsNullable ? "null" : "not null")} {(sqlFNPDef.FieldIsPrimaryKey ?? false ? "primary key" : "")}",
         _ => throw new NotImplementedException(),
      };

   public static string GetSqlTypeDeclaration(this ISqlFieldNParamDefinition sqlFNPDef)
      => GetSqlDbType(sqlFNPDef) switch {
         SqlDbType.BigInt => $"bigint",
         SqlDbType.Binary => $"binary{(sqlFNPDef.FieldSize is > 1 or < 0 ? $"({sqlFNPDef.FieldSize})" : "")}",
         SqlDbType.Bit => $"bit",
         SqlDbType.Char => $"char{(sqlFNPDef.FieldSize > 1 ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.DateTime => $"datetime",
         SqlDbType.Decimal => $"decimal{(sqlFNPDef.FieldPrecision != 18 || sqlFNPDef.FieldScale != 0 ? $"({sqlFNPDef.FieldPrecision}, {sqlFNPDef.FieldScale})" : "")}",
         SqlDbType.Float => $"float{(sqlFNPDef.FieldPrecision != 53 ? $"({sqlFNPDef.FieldPrecision})" : "")}",
         SqlDbType.Image => $"image{(sqlFNPDef.FieldSize != 2147483647 ? $"({sqlFNPDef.FieldSize})" : "")}",
         SqlDbType.Int => $"int",
         SqlDbType.Money => $"money",
         SqlDbType.NChar => $"nchar{(sqlFNPDef.FieldSize > 1 ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.NText => $"ntext{(sqlFNPDef.FieldSize is < 1073741823 and > (-1) ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.NVarChar => $"nvarchar{(sqlFNPDef.FieldSize > 1 ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.Real => $"real",
         SqlDbType.UniqueIdentifier => $"uniqueidentifier",
         SqlDbType.SmallDateTime => $"smalldatetime",
         SqlDbType.SmallInt => $"smallint",
         SqlDbType.SmallMoney => $"smallmoney",
         SqlDbType.Text => $"ntext{(sqlFNPDef.FieldSize is < 2147483647 and > (-1) ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.Timestamp => $"timestamp",
         SqlDbType.TinyInt => $"tinyint",
         SqlDbType.VarBinary => $"varbinary{(sqlFNPDef.FieldSize > 1 ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.VarChar => $"varchar{(sqlFNPDef.FieldSize > 1 ? $"({sqlFNPDef.FieldSize})" : sqlFNPDef.FieldSize == -1 ? "(max)" : "")}",
         SqlDbType.Variant => $"sql_variant",
         SqlDbType.Xml => "??xml??",
         SqlDbType.Udt => sqlFNPDef.ResolveSqlUDTDeclaration(),
         SqlDbType.Structured => $"{sqlFNPDef.FieldUDTSchema ?? "??structered??"}.{sqlFNPDef.FieldUDTName ?? "??structered??"}",
         SqlDbType.Date => $"date",
         SqlDbType.Time => $"time",
         SqlDbType.DateTime2 => $"datetime2{(sqlFNPDef.FieldScale < 7 ? $"({sqlFNPDef.FieldScale})" : "")}",
         SqlDbType.DateTimeOffset => $"datetime2{(sqlFNPDef.FieldScale < 7 ? $"({sqlFNPDef.FieldScale})" : "")}",
         _ => throw new NotImplementedException(),
      };

   public static SqlDbType GetSqlDbType(this ISqlFieldNParamDefinition sqlFieldNParamDefinition)
      => sqlFieldNParamDefinition.FieldTypeName.ToLower(CultureInfo.InvariantCulture) switch {
         "nvarchar" => SqlDbType.NVarChar,
         "nchar" => SqlDbType.NChar,
         "char" => SqlDbType.Char,
         "varchar" => SqlDbType.VarChar,
         "bigint" => SqlDbType.BigInt,
         "int" => SqlDbType.Int,
         "uniqueidentifier" => SqlDbType.UniqueIdentifier,
         "bit" => SqlDbType.Bit,
         "datetime" => SqlDbType.DateTime,
         "datetime2" => SqlDbType.DateTime2,
         "date" => SqlDbType.Date,
         "time" => SqlDbType.Time,
         "binary"
         or "rowversion"
         or "varbinary" => SqlDbType.Binary,
         "decimal" => SqlDbType.Decimal,
         "money" => SqlDbType.Money,
         "numeric" => SqlDbType.Decimal,
         "smallmoney" => SqlDbType.SmallMoney,
         "float" => SqlDbType.Float,
         "real" => SqlDbType.Real,
         "smallint" => SqlDbType.SmallInt,
         "sql_variant" => SqlDbType.Variant,
         "tinyint" => SqlDbType.TinyInt,
         "table type" => SqlDbType.Structured,
         "datetimeoffset" => SqlDbType.DateTimeOffset,
         "smalldatetime" => SqlDbType.SmallDateTime,
         "timestamp" => SqlDbType.Timestamp,
         "xml" => SqlDbType.Xml,
         "text" => SqlDbType.Text,
         "ntext" => SqlDbType.NText,
         "image" => SqlDbType.Image,
         _ => SqlDbType.Udt,
      };

   public static string GetNetTypeDeclaration(this ISqlFieldNParamDefinition sqlFNPDef)
      => GetSqlDbType(sqlFNPDef) switch {
         SqlDbType.BigInt => sqlFNPDef.FieldIsNullable ? "long?" : "long",
         SqlDbType.VarBinary
         or SqlDbType.Image
         or SqlDbType.Timestamp
         or SqlDbType.Binary => sqlFNPDef.FieldIsNullable ? "byte[]?" : "byte[]",
         SqlDbType.Bit => sqlFNPDef.FieldIsNullable ? "bool?" : "bool",
         SqlDbType.NText
         or SqlDbType.NVarChar
         or SqlDbType.VarChar
         or SqlDbType.NChar
         or SqlDbType.Text
         or SqlDbType.Char => sqlFNPDef.FieldIsNullable ? "string?" : "string",
         SqlDbType.Date
         or SqlDbType.SmallDateTime
         or SqlDbType.DateTime2
         or SqlDbType.DateTime => sqlFNPDef.FieldIsNullable ? "DateTime?" : "DateTime",
         SqlDbType.SmallMoney
         or SqlDbType.Money
         or SqlDbType.Decimal => sqlFNPDef.FieldIsNullable ? "decimal?" : "decimal",
         SqlDbType.Float => sqlFNPDef.FieldIsNullable ? "double?" : "double",
         SqlDbType.Int => sqlFNPDef.FieldIsNullable ? "int?" : "int",
         SqlDbType.Real => sqlFNPDef.FieldIsNullable ? "Single?" : "Single",
         SqlDbType.UniqueIdentifier => sqlFNPDef.FieldIsNullable ? "Guid?" : "Guid",
         SqlDbType.SmallInt => sqlFNPDef.FieldIsNullable ? "short?" : "short",
         SqlDbType.TinyInt => sqlFNPDef.FieldIsNullable ? "byte?" : "byte",
         SqlDbType.Variant => sqlFNPDef.FieldIsNullable ? "object?" : "object",
         SqlDbType.Time => sqlFNPDef.FieldIsNullable ? "TimeSpan?" : "TimeSpan",
         SqlDbType.DateTimeOffset => sqlFNPDef.FieldIsNullable ? "DateTimeOffset?" : "DateTimeOffset",
         SqlDbType.Xml => "??xml??",
         SqlDbType.Udt => sqlFNPDef.ResolveNetUDTDeclaration(),
         SqlDbType.Structured => "??structured??", //$"{sqlFNPDef.FieldUDTSchema ?? "??structered??"}.{sqlFNPDef.FieldUDTName ?? "??structered??"}",
         _ => throw new NotImplementedException(),
      };

   private static string ResolveNetUDTDeclaration(this ISqlFieldNParamDefinition sqlFNPDef) {
      string fieldschemaname = $"{sqlFNPDef.FieldSchema}.{sqlFNPDef.FieldTypeName}".ToLowerInvariant();

      if (fieldschemaname.EndsWith("sys.sysname"))
         return sqlFNPDef.FieldIsNullable ? "string?" : "string";

      if (fieldschemaname.EndsWith("sys.geography"))
         return sqlFNPDef.FieldIsNullable ? "SqlGeography?" : "SqlGeography";

      if (fieldschemaname.EndsWith("sys.geometry"))
         return sqlFNPDef.FieldIsNullable ? "SqlGeometry?" : "SqlGeometry";

      if (fieldschemaname.EndsWith("sys.hierarchyid"))
         return sqlFNPDef.FieldIsNullable ? "SqlHierarchyId?" : "SqlHierarchyId";

      string tor = $"??{sqlFNPDef.FieldSchema}.{sqlFNPDef.FieldTypeName}-{sqlFNPDef.FieldUDTSchema}.{sqlFNPDef.FieldUDTName}??";
      return tor;
   }

   private static string ResolveSqlUDTDeclaration(this ISqlFieldNParamDefinition sqlFNPDef) {
      string fieldschemaname = $"{sqlFNPDef.FieldSchema}.{sqlFNPDef.FieldTypeName}".ToLowerInvariant();

      if (fieldschemaname.EndsWith("sys.sysname"))
         return "sysname";

      if (fieldschemaname.EndsWith("sys.geography"))
         return "geography";

      if (fieldschemaname.EndsWith("sys.geometry"))
         return "geometry";

      if (fieldschemaname.EndsWith("sys.hierarchyid"))
         return "hierarchyid";

      string tor = $"??{sqlFNPDef.FieldSchema}.{sqlFNPDef.FieldTypeName}-{sqlFNPDef.FieldUDTSchema}.{sqlFNPDef.FieldUDTName}??";
      return tor;
   }
}
