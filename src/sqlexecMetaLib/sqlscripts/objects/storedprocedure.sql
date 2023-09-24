select p.name [Name]
    , p.object_id [ObjectId]
    , s.name [Schema]
    , coalesce(pp.name, '') [FieldName]
    , pp.has_default_value [HasDefault]
    , pp.parameter_id [FieldIndex]
    , ty.name [SQLType]
    , pp.is_nullable [IsNullable]
    , pp.is_output [IsOutPut]
    , pp.max_length [Size]
    , pp.precision [Precision]
    , pp.scale [Scale]
    , schema_name(ty.schema_id) [UDTSchema]
    , ty.name [UDTName]
    , db_name() [DBName]
    , ts.name [FieldSchema]
from sys.procedures p
inner join sys.schemas s on s.schema_id = p.schema_id
left join sys.parameters pp on pp.object_id = p.object_id
left join sys.objects op on pp.object_id = op.object_id
left join sys.types ty on ty.user_type_id = pp.user_type_id
left join sys.schemas ts on ts.schema_id = ty.schema_id
where s.name = @schema and p.name = @name
order by pp.parameter_id