select d.name [Name]
    , d.type_table_object_id [ObjectId]
    , s.name [Schema]
    , d.system_type_id [SystemTypeId]
    , d.user_type_id [UserTypeId]
    , ct.name [FieldName]
    , ct.column_id [FieldIndex]
    , ct.is_nullable [IsNullable]
    , yt.name [TypeText]
    , ct.is_computed [IsComputed]
    , ct.max_length [Size]
    , ct.precision [Precision]
    , ct.scale [Scale]
    , ct.is_identity [IsIdentity]
    , ct.is_rowguidcol [IsRowGUID]
    , db_name() [DBName] 
    , st.name [FieldSchema]
from sys.table_types d 
inner join sys.schemas s on s.schema_id = d.schema_id
inner join sys.columns ct on ct.object_id = d.type_table_object_id 
inner join sys.objects ot on ct.object_id = ot.object_id 
inner join sys.types yt on yt.user_type_id = ct.user_type_id 
inner join sys.schemas st on st.schema_id = yt.schema_id
where s.name + '.' + d.name = @name