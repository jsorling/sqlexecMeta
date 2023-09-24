using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlCheckConstraintPrevNxtCmd(string Current, string? Schema) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.checkconstraintprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlCheckConstraintPrevNxtCmd);
}
