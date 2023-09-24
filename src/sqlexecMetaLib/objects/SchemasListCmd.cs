using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects;

public record SchemasListCmd() : ScriptResourceCommand
{
   public record Result(string Name) : SqlExecBaseResult;

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.schemas.sql";

   protected override Type AssemblyType => typeof(SchemasListCmd);
}
