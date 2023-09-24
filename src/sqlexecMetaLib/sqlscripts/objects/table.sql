select t.name [Name]
    , t.object_id [ObjectId]
    , s.name [Schema]
    , cc.name [FieldName]
    , cc.column_id [FieldIndex]
    , cc.is_nullable [IsNullable]
    , ty.name [TypeText]
    , cast(case when cc.default_object_id > 0 then 1 else 0 end as bit) [HasDefault]
    , cast(case when pc.column_id is not null then 1 else 0 end as bit) [IsPrimaryKey]
    , cc.max_length [Size]
    , cc.precision [Precision]
    , cc.scale [Scale]
    , cc.is_identity [IsIdentity]
    , cc.is_computed [IsComputed]
    , cc.is_rowguidcol [IsRowGUID]
    , db_name() [DBName]
    , ts.name [FieldName]
from sys.tables t 
inner join sys.schemas s on s.schema_id = t.schema_id
inner join sys.columns cc on t.object_id = cc.object_id
inner join sys.objects oc on cc.object_id = oc.object_id 
--inner join sys.schemas sc on sc.schema_id = oc.schema_id 
inner join sys.types ty on ty.user_type_id = cc.user_type_id
inner join sys.schemas ts on ts.schema_id = ty.schema_id
left join sys.indexes xc on xc.object_id = cc.object_id and xc.is_primary_key = 1 
left join sys.index_columns pc on pc.index_id = xc.index_id and pc.column_id = cc.column_id
    and cc.object_id = pc.object_id 
where s.name = @schema and t.name = @name