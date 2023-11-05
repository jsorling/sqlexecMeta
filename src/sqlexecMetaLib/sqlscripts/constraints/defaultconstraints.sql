select d.name [Name]
	, d.object_id [Id]
	, s.name [SchemaName]
	, d.principal_id
	, d.schema_id
	, d.parent_object_id
	, d.type
	, d.type_desc
	, d.create_date
	, d.modify_date
	, d.is_ms_shipped
	, d.is_published
	, d.is_schema_published
	, d.parent_column_id
	, d.definition
	, d.is_system_named
	, 'defaultconstraints' [Group]
	, cast(128 as bigint) [GroupFlag]
	, db_name() [DBName]
	, object_schema_name(d.parent_object_id) [ParentSchema]
	, object_name(d.parent_object_id) [ParentName]
	, col_name(d.parent_object_id, d.parent_column_id) [ColumnName]
from sys.default_constraints d
cross apply(
    select name from sys.schemas c
    where c.schema_id = d.schema_id
        and (c.name = @schema or @schema is null)
) s
where (@name is not null and @name = d.name and s.name = @schema) 
    or @name is null
order by s.name, d.name
