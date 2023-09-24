using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlCheckConstraintListCmd(string? Schema, string? Name) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.checkconstraints.sql";

   protected override Type AssemblyType => typeof(SqlCheckConstraintListCmd);
}
