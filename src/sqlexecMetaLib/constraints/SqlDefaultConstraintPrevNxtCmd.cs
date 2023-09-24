using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlDefaultConstraintPrevNxtCmd(string Current, string? Schema) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.defaultconstraintprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlDefaultConstraintPrevNxtCmd);
}
