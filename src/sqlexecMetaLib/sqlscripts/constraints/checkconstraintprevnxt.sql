with checklist as (
    select lag(ch.Name) over (order by ch.Name) PreviousId
        , lag(ch.GroupName) over (order by ch.Name) PreviousGroup
        , ch.Name CurrentId
        , lead(ch.Name) over (order by ch.Name) NextId
        , lead(ch.GroupName) over (order by ch.Name) NextGroup
    from (
        select s.name + '.' + c.name [Name], cast(256 as bigint) [GroupName]
        from sys.check_constraints c 
        inner join sys.schemas s on s.schema_id = c.schema_id
        where (( @schema is not null and s.name = @schema ) or @schema is null)
    ) ch
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from checklist l
where l.CurrentId = @current