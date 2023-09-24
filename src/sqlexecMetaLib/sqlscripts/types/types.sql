select t.name
    , t.system_type_id
    , t.user_type_id
    , t.schema_id
    , s.name [Schema]
    , t.principal_id
    , t.max_length
    , t.precision
    , t.scale
    , t.collation_name
    , t.is_nullable
    , t.is_user_defined
    , t.is_assembly_type
    , t.default_object_id
    , t.rule_object_id
    , t.is_table_type
    , db_name() DBName
    , case when t.is_table_type = 1 then 'tabletypes' else 'types' end [Group]
    , cast(case when t.is_table_type = 1 then 16 else 64 end as int) GroupFlag
from sys.types t
cross apply(
    select name from sys.schemas c
    where c.schema_id = t.schema_id
        and (c.name = @schema or @schema is null)
) s
where (@name is not null and @name = t.name and s.name = @schema) 
    or @name is null
order by s.name, t.name