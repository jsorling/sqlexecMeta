using System.Data;

namespace Sorling.SqlExecMeta;

public interface ISqlType2WCodeType
{
   public int SqlSize { get; }

   public string SqlTypeName { get; }

   public int SqlPrecision { get; }

   public int SqlScale { get; }

   public string SqlDeclaration { get; }

   public bool IsNullable { get; }

   public bool? HasDefault { get; }

   public bool? IsOutput { get; }

   public bool? IsPrimaryKey { get; }

   public SqlDbType SqlDbType { get; }

   public Type NetType { get; }
}
