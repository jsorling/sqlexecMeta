select distinct s.name from sys.schemas s
inner join sys.objects o on s.schema_id = o.schema_id
order by s.name