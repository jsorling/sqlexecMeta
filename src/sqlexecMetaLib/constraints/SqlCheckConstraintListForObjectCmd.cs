using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlCheckConstraintListForObjectCmd(string Name) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.checkconstraintsforobject.sql";

   protected override Type AssemblyType => typeof(SqlCheckConstraintListCmd);
}
