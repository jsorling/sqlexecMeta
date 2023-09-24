using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectTextCmd(string Name) : ScriptResourceCommand
{
   public record Result(string Line) : SqlExecBaseResult;

   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.objecttext.sql";

   protected override Type AssemblyType => typeof(SqlObjectTextCmd);
}
