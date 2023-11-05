with objlist as (
    select lag(o.Name) over (order by o.Name) PrevObj,
        lag(o.ObjectType) over (order by o.Name) PrevType,
        o.Name, o.ObjectType,
        lead(o.Name) over (order by o.Name) NxtObj, 
        lead(o.ObjectType) over (order by o.Name) NxtType
    from (
        --tables
        select s.name + '.' + t.name [Name], cast(1 as bigint) [ObjectType]
        from sys.tables t 
        inner join sys.schemas s on s.schema_id = t.schema_id 
        where (( @schema is not null and s.name = @schema ) or @schema is null) and 1 & @filter <> 0
        union all
        --views
        select s.name + '.' + t.name [Name],  cast(2 as bigint) [ObjectType]
        from sys.views t 
        inner join sys.schemas s on s.schema_id = t.schema_id 
        where (( @schema is not null and s.name = @schema ) or @schema is null)  and 2 & @filter <> 0
        union all
        --stored procedures
        select s.name + '.' + t.name [Name], cast(4 as bigint) [ObjectType]
        from sys.procedures t 
        inner join sys.schemas s on s.schema_id = t.schema_id
        where (( @schema is not null and s.name = @schema ) or @schema is null)  and 4 & @filter <> 0
        union all
        --functions
        select s.name + '.' + t.name [Name], cast(8 as bigint) [ObjectType]
        from sys.objects t 
        inner join sys.schemas s on s.schema_id = t.schema_id 
        where t.type in ( 'FN', 'IF', 'TF', 'FS', 'FT' ) and ( ( @schema is not null and s.name = @schema ) or @schema is null )  and 8 & @filter <> 0
    ) o
) 
select l.PrevObj, l.PrevType, l.Name, l.ObjectType, l.NxtObj, l.NxtType 
from objlist l 
where l.Name = @currentobj and l.ObjectType = @currenttype