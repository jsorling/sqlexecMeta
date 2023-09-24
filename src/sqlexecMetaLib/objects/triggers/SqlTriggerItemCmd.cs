using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.objects.triggers;

public record SqlTriggerItemCmd(string Schema, string Name) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.trigger.sql";

   protected override Type AssemblyType => typeof(SqlTriggerItemCmd);
}
