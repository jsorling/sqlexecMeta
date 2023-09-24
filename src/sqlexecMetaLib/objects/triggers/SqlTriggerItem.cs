using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects.triggers;

public record SqlTriggerItem(string Name, int Object_id, byte Parent_class, string? Parent_class_desc, int Parent_id
   , string Type_desc, DateTime Create_date, DateTime Modify_date, bool Is_ms_shipped, bool Is_disabled
   , bool Is_not_for_replication, bool Is_instead_of_trigger, string ParentSchema, string? ParentName
   , string DBName, SqlGroupFlags GroupFlag, string Group, string Definition) : SqlExecBaseResult, ISqlItem
{
   public int Id => Object_id;

   public string SchemaName => ParentSchema;
}
