using Sorling.SqlExec.mapper.results;
using Sorling.SqlExecMeta.helpers;

namespace Sorling.SqlExecMeta.types;

public record SqlTypePrevNxt(string? PreviousId, string? PreviousGroup, string CurrentId, string? NextId, string? NextGroup)
   : SqlExecBaseResult, IPrevNxtSqlItem
{
   public string? PreviousSchema => SqlIdentifierHelper.GetSchema(PreviousId);

   public string? PreviousName => SqlIdentifierHelper.GetName(PreviousId);

   public string? NextSchema => SqlIdentifierHelper.GetSchema(NextId);

   public string? NextName => SqlIdentifierHelper.GetName(NextId);
}
