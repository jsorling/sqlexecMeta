select t.name
    , t.object_id
    , t.parent_class
    , t.parent_class_desc
    , t.parent_id
    , t.type type_desc
    , t.create_date
    , t.modify_date
    , t.is_ms_shipped
    , t.is_disabled
    , t.is_not_for_replication
    , t.is_instead_of_trigger
    , os.ParentSchema ParentSchema
    , os.ParentName ParentName
    , db_name() DBName
    , cast(262144 as bigint) GroupFlags
    , 'Triggers' [Group]
from sys.triggers t
cross apply (
    select sc.name ParentSchema, o.name ParentName
    from sys.objects o
    inner join sys.schemas sc on sc.schema_id = o.schema_id
        and (@schema is null or (@schema is not null and sc.name = @schema))
    where o.object_id = t.parent_id
) os
order by os.ParentSchema, t.name