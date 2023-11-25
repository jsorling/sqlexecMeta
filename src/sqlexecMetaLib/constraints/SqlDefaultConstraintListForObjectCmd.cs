using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.constraints;

public record SqlDefaultConstraintListForObjectCmd(string Name) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.constraints.defaultconstraintsforobject.sql";

   protected override Type AssemblyType => typeof(SqlDefaultConstraintListItem);
}
