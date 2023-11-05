using Sorling.SqlExec.mapper.results;
using Sorling.SqlExecMeta.helpers;

namespace Sorling.SqlExecMeta.types;

public record SqlTypePrevNxt(string? PreviousId, SqlGroupFlags? PreviousGroup, string CurrentId, string? NextId, SqlGroupFlags? NextGroup)
   : SqlExecBaseResult, IPrevNxtSqlItem
{
   public string? PreviousSchema => SqlIdentifierHelper.GetSchema(PreviousId);

   public string? PreviousName => SqlIdentifierHelper.GetName(PreviousId);

   public string? NextSchema => SqlIdentifierHelper.GetSchema(NextId);

   public string? NextName => SqlIdentifierHelper.GetName(NextId);
}
