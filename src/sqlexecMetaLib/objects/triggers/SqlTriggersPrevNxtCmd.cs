using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.objects.triggers;

public record SqlTriggersPrevNxtCmd(string Current, string? Schema) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.triggerprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlTriggersPrevNxtCmd);
}
