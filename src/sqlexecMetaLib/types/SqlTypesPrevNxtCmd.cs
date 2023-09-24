using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.types;

public record SqlTypesPrevNxtCmd(string Current, string? Schema) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.types.typeprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlTypesPrevNxtCmd);
}
