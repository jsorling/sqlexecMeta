namespace Sorling.SqlExecMeta.helpers;

public static class SqlIdentifierHelper
{
   public static (string? Schema, string? Name) GetSchemaNName(string? fullname) {
      if (string.IsNullOrEmpty(fullname))
         return (null, null);
      string[] sa = fullname.Split('.');
      return sa.Length < 2 ? ((string? Schema, string? Name))(null, sa[0])
         : ((string? Schema, string? Name))(sa[^2], sa[^1]);
   }

   public static string? GetSchema(string? fullname)
      => GetSchemaNName(fullname).Schema;

   public static string? GetName(string? fullname)
      => GetSchemaNName(fullname).Name;
}
