using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.objects.triggers;

public record SqlTriggerListCmd(string? Schema) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.triggers.sql";

   protected override Type AssemblyType => typeof(SqlTriggerListCmd);
}
