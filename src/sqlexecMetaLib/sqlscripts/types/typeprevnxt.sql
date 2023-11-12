with typelist as (
    select lag(ty.Name) over (order by ty.Name) PreviousId
        , lag(ty.GroupName) over (order by ty.Name) PreviousGroup
        , ty.Name CurrentId
        , lead(ty.Name) over (order by ty.Name) NextId
        , lead(ty.GroupName) over (order by ty.Name) NextGroup
    from (
        select s.name + '.' + t.name [Name]
            , case when t.is_table_type = 1 then cast(16 as bigint) else cast(64 as bigint) end [GroupName]
        from sys.types t 
        inner join sys.schemas s on s.schema_id = t.schema_id
        where (( @schema is not null and s.name = @schema ) or @schema is null)
    ) ty
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from typelist l
where l.CurrentId = @current