using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.constraints;

public record SqlDefaultConstraintListItem(string Name, int Id, string SchemaName, int? Principal_id, int Schema_id, int Parent_object_id
   , string? Type, string? Type_desc, DateTime Create_date, DateTime Modify_date, bool Is_ms_shipped, bool Is_published
   , bool Is_schema_published, int Parent_column_id, string? Definition, bool Is_system_named, string Group, SqlGroupFlags GroupFlag
   , string DBName, string? ParentSchema, string? ParentName, string? ColumnName) : SqlExecBaseResult, ISqlItem;
