namespace Sorling.SqlExecMeta.extenssions;

public static class StringExtensions
{
   public static string ToFirstUpperCase(this string s)
      => !string.IsNullOrEmpty(s) && s.Any() && char.IsLower(s[0])
      ? char.ToUpper(s[0]) + new string(s.Skip(1).ToArray())
      : s;
}
