using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectListItem(string Name, int ObjectId, string SchemaName, string Group, string DBName
   , SqlGroupFlags GroupFlag) : SqlExecBaseResult, ISqlItem
{
   public int Id => ObjectId;
}
