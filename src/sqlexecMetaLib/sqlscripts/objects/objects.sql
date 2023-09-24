select  o.name[Name]
    , o.object_id [ObjectId]
    , s.name[SchemaName]
    , case when o.type	= 'U' then 'Table'
        when o.type = 'V' then 'View'
        when o.type = 'P' then 'Stored procedure'
        when o.type in ( 'FN', 'IF', 'TF', 'FS', 'FT' ) then 'Function'
      else
        o.type_desc
      end [Group]
    , db_name() [DBName]
    , cast (
        case when o.type	= 'U' then 1
            when o.type = 'V' then 2
            when o.type = 'P' then 4
            when o.type in ( 'FN', 'IF', 'TF', 'FS', 'FT' ) then 8
        else
            o.type_desc
      end as int) [GroupFlag] 
from sys.objects o
cross apply (
    select c.name from sys.schemas c 
    where c.schema_id = o.schema_id
        and (( @schema is not null and c.name = @schema ) 
            or @schema is null)	
) s
where o.type in ( 'FN', 'IF', 'TF', 'FS', 'FT', 'U', 'V', 'P' )
    and (
        @filter = 0
        or (1 & @filter <> 0 and o.type = 'U')
        or (2 & @filter <> 0 and o.type = 'V')
        or (4 & @filter <> 0 and o.type = 'P')
        or (8 & @filter <> 0 and o.type in ( 'FN', 'IF', 'TF', 'FS', 'FT' )))
order by s.name, o.name