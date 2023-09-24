select v.name [Name]
    , v.object_id [ObjectId]
    , s.name [Schema]
    , cc.name [FieldName]
    , cast( cc.is_nullable as bit) [IsNullable]
    , cast(case when cc.default_object_id > 0 then 1 else 0 end as bit) [HasDefault]
    , cc.column_id [FieldIndex]
    , ty.name [TypeText]
    , cc.max_length [Size]
    , cc.precision [Precision]
    , cc.scale [Scale]
    , db_name() [DBName]
    , ts.name FieldSchema
from sys.views v 
inner join sys.schemas s on s.schema_id = v.schema_id
inner join sys.columns cc on cc.object_id = v.object_id 
inner join sys.types ty on ty.user_type_id = cc.user_type_id
inner join sys.schemas ts on ts.schema_id = ty.schema_id
where s.name = @schema and v.name = @name