using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.security;

public record SqlPrincipalListItem(string Name, int Principal_id, string Type, string? Type_desc, string? Default_schema_name
   , DateTime Create_date, DateTime Modify_date, int? Owning_principal_id, byte[]? Sid, bool Is_fixed_role, int Authentication_type
   , string? Authentication_type_desc, string? Default_language_name, int? Default_language_lcid, bool Allow_encrypted_value_modifications
   , string DBName, string Group, SqlGroupFlags GroupFlag) : SqlExecBaseResult, ISqlItem
{
   public int Id => Principal_id;

   public string SchemaName => Group;
}
