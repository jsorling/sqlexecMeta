select o.name [Name]
    , o.object_id [ObjectId]
    , s.name [Schema]
    , pp.name [FieldName]
    , pp.has_default_value [HasDefault]
    , pp.parameter_id [FieldIndex]
    , ty.name [TypeText]
    , cast(0 as bit) [IsNullable]
    , pp.is_output [IsOutPut]
    , cast(case when o.type in ('IF', 'TF', 'FT') then 1 else 0 end as bit) [IsTableValued]
    , pp.max_length [Size]
    , pp.precision [Precision]
    , pp.scale [Scale]
    , schema_name(ty.schema_id) [UDTSchema]
    , ty.name [UDTName]
    , db_name() [DBName]
    , 'functions' [Group]
    , cast (8 as int) [GroupFlag]
    , ts.name [FieldSchema]
from sys.objects o
inner join sys.schemas s on s.schema_id = o.schema_id
left join sys.parameters pp on pp.object_id = o.object_id
left join sys.objects op on pp.object_id = op.object_id 
left join sys.types ty on ty.user_type_id = pp.user_type_id
left join sys.schemas ts on ts.schema_id = ty.schema_id
where s.name  = @schema and o.name = @name