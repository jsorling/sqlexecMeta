using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.types;

public record SqlTypeListCmd(string? Schema = null, string? Name = null) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.types.types.sql";

   protected override Type AssemblyType => typeof(SqlTypeListCmd);
}
