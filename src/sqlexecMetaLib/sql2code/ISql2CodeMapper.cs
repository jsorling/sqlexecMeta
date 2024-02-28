using Sorling.SqlExecMeta.objects;

namespace Sorling.SqlExecMeta.sql2code;

public interface ISql2CodeMapper
{
   public string MapSql2CodeProperty(ISqlFieldNParamDefinition sqlFieldNParam);

   public string MapSql2CodeVar(ISqlFieldNParamDefinition sqlFieldNParam);

   public string MapSql2ProperName(string name);
}
