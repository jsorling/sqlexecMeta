with triggerlist as (
    select lag(tr.Name) over (order by tr.Name) PreviousId
        , lag(tr.GroupName) over (order by tr.Name) PreviousGroup
        , tr.Name CurrentId
        , lead(tr.Name) over (order by tr.Name) NextId
        , lead(tr.GroupName) over (order by tr.Name) NextGroup
    from (
        select s.name + '.' + t.name [Name], cast(262144 as bigint) [GroupName]
        from sys.triggers t
        inner join sys.objects o on o.object_id = t.parent_id
        inner join sys.schemas s on s.schema_id = o.schema_id
        where (( @schema is not null and s.name = @schema ) or @schema is null)
    ) tr
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from triggerlist l
where l.CurrentId = @current