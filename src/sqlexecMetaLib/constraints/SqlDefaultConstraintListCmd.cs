using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlDefaultConstraintListCmd(string? Schema, string? Name) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.defaultconstraints.sql";

   protected override Type AssemblyType => typeof(SqlDefaultConstraintListItem);
}
