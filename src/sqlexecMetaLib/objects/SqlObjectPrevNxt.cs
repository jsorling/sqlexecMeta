using Sorling.SqlExec.mapper.results;
using Sorling.SqlExecMeta.helpers;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectPrevNxt(string? PrevObj, string? PrevType, string CurrentObjFullName, string CurrentType, string? NxtObj
   , string? NxtType) : SqlExecBaseResult, IPrevNxtSqlItem
{
   public string? PreviousId => PrevObj;

   public string? PreviousGroup => PrevType;

   public string? PreviousSchema => SqlIdentifierHelper.GetSchema(PrevObj);

   public string? PreviousName => SqlIdentifierHelper.GetName(PrevObj);

   public string CurrentId => CurrentObjFullName;

   public string? NextId => NxtObj;

   public string? NextGroup => NxtType;

   public string? NextSchema => SqlIdentifierHelper.GetSchema(NxtObj);

   public string? NextName => SqlIdentifierHelper.GetName(NxtObj);
}
