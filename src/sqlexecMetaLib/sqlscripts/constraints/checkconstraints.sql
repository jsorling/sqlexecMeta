select c.name [Name]
    , c.object_id [Id]
    , s.name [SchemaName]
    , c.principal_id
    , c.schema_id
    , c.parent_object_id
    , c.type
    , c.type_desc
    , c.create_date
    , c.modify_date
    , c.is_ms_shipped
    , c.is_published
    , c.is_schema_published
    , c.parent_column_id
    , c.definition
    , c.is_system_named
    , c.uses_database_collation
    , c.is_not_for_replication
    , c.is_disabled
    , 'checkconstraints' [Group]
    , cast(256 as int) [GroupFlag]
    , db_name() [DBName]
    , object_schema_name(c.parent_object_id) [ParentSchema]
    , object_name(c.parent_object_id) [ParentName]
    , col_name(c.parent_object_id, c.parent_column_id) [ColumnName]
from sys.check_constraints c
cross apply(
    select h.name from sys.schemas h
    where h.schema_id = c.schema_id
        and (h.name = @schema or @schema is null)
) s
where (@name is not null and @name = c.name and s.name = @schema) 
    or @name is null
order by s.name, c.name