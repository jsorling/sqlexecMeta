namespace Sorling.SqlExecMeta.objects.storedprocedures;

public record SqlSPParameter(string? SQLType, string? FieldName, bool? IsNullable
   , short? Size, byte? Precision, byte? Scale) : ISQLFieldInfo;
