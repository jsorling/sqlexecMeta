using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.types;

public record SqlTypeListItem(string Name, byte System_type_id, int User_type_id, int Schema_id, string SchemaName, int? Principal_id
   , short Max_length, byte Precision, byte Scale, string? Collation_name, bool? Is_nullable, bool Is_user_defined
   , bool Is_assembly_type, int Default_object_id, int Rule_object_id, bool Is_table_type, string DBName, string Group
   , SqlGroupFlags GroupFlag) : SqlExecBaseResult, ISqlItem
{
   public int Id => User_type_id;
}
