using Sorling.SqlExec.mapper.results;
using Sorling.SqlExecMeta.helpers;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectPrevNxt(string? PrevObj, SqlGroupFlags? PrevType, string CurrentObjFullName, SqlGroupFlags CurrentType, string? NxtObj
   , SqlGroupFlags? NxtType) : SqlExecBaseResult, IPrevNxtSqlItem
{
   public string? PreviousId => PrevObj;

   public SqlGroupFlags? PreviousGroup => PrevType;

   public string? PreviousSchema => SqlIdentifierHelper.GetSchema(PrevObj);

   public string? PreviousName => SqlIdentifierHelper.GetName(PrevObj);

   public string CurrentId => CurrentObjFullName;

   public string? NextId => NxtObj;

   public SqlGroupFlags? NextGroup => NxtType;

   public string? NextSchema => SqlIdentifierHelper.GetSchema(NxtObj);

   public string? NextName => SqlIdentifierHelper.GetName(NxtObj);
}
