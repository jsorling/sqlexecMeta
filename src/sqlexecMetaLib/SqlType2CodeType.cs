using System.Data;
using System.Globalization;

namespace Sorling.SqlExecMeta;
public record SqlType2CodeType(int SqlSize, string SqlTypeName, int SqlPrecision, int SqlScale
   , bool IsNullable, bool HasDefault, bool IsOutput, bool IsPrimaryKey) //: ISqlType2WCodeType
{
   public string SqlDeclaration
      => SqlDbType switch {
         SqlDbType.BigInt => $"bigint {(IsNullable ? "null" : "not null")}",
         SqlDbType.Binary => $"binary{(SqlSize > 1 ? $"({SqlSize})" : SqlSize == -1 ? "max" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Bit => $"bit {(IsNullable ? "null" : "not null")}",
         SqlDbType.Char => $"char{(SqlSize > 1 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.DateTime => $"datetime {(IsNullable ? "null" : "not null")}",
         SqlDbType.Decimal => $"decimal{(SqlPrecision != 18 || SqlScale != 0 ? $"({SqlPrecision}, {SqlScale})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Float => $"float{(SqlPrecision != 53 ? $"({SqlPrecision})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Image => $"image{(SqlSize != 2147483647 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Int => $"int {(IsNullable ? "null" : "not null")}",
         SqlDbType.Money => $"money {(IsNullable ? "null" : "not null")}",
         SqlDbType.NChar => $"nchar{(SqlSize > 1 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.NText => $"ntext{(SqlSize != 1073741823 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.NVarChar => $"nvarchar{(SqlSize != 1 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Real => $"real {(IsNullable ? "null" : "not null")}",
         SqlDbType.UniqueIdentifier => $"uniqueidentifier {(IsNullable ? "null" : "not null")}",
         SqlDbType.SmallDateTime => $"smalldatetime {(IsNullable ? "null" : "not null")}",
         SqlDbType.SmallInt => $"smallint {(IsNullable ? "null" : "not null")}",
         SqlDbType.SmallMoney => $"smallmoney {(IsNullable ? "null" : "not null")}",
         SqlDbType.Text => $"ntext{(SqlSize != 2147483647 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Timestamp => $"timestamp {(IsNullable ? "null" : "not null")}",
         SqlDbType.TinyInt => $"tinyint {(IsNullable ? "null" : "not null")}",
         SqlDbType.VarBinary => $"varbinary{(SqlSize > 1 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.VarChar => $"varchar{(SqlSize != 1 ? $"({SqlSize})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.Variant => $"sql_variant {(IsNullable ? "null" : "not null")}",
         SqlDbType.Xml => throw new NotImplementedException(),
         SqlDbType.Udt => throw new NotImplementedException(),
         SqlDbType.Structured => throw new NotImplementedException(),
         SqlDbType.Date => $"date {(IsNullable ? "null" : "not null")}",
         SqlDbType.Time => $"time {(IsNullable ? "null" : "not null")}",
         SqlDbType.DateTime2 => $"datetime2{(SqlScale < 7 ? $"({SqlScale})" : "")} {(IsNullable ? "null" : "not null")}",
         SqlDbType.DateTimeOffset => $"datetime2{(SqlScale < 7 ? $"({SqlScale})" : "")} {(IsNullable ? "null" : "not null")}",
         _ => throw new NotImplementedException(),
      };

   public SqlDbType SqlDbType
      => SqlTypeName.ToLower(CultureInfo.InvariantCulture) switch {
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
         _ => throw new NotSupportedException($"SQL datatype '{SqlTypeName}' is not supported")
      };

   public Type NetType => throw new NotImplementedException();
}
