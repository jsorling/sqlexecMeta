with defaultlist as (
    select lag(de.Name) over (order by de.Name) PreviousId
        , lag(de.GroupName) over (order by de.Name) PreviousGroup
        , de.Name CurrentId
        , lead(de.Name) over (order by de.Name) NextId
        , lead(de.GroupName) over (order by de.Name) NextGroup
    from (
        select s.name + '.' + d.name [Name], cast(128 as bigint) [GroupName]
        from sys.default_constraints d
        inner join sys.schemas s on s.schema_id = d.schema_id
        where (( @schema is not null and s.name = @schema ) or @schema is null)
    ) de
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from defaultlist l
where l.CurrentId = @current