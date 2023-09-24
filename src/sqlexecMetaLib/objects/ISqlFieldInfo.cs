namespace Sorling.SqlExecMeta.objects;

public interface ISQLFieldInfo
{
   public string? SQLType { get; }

   public string? FieldName { get; }

   public bool? IsNullable { get; }

   public short? Size { get; }

   public byte? Precision { get; }

   public byte? Scale { get; }
}
