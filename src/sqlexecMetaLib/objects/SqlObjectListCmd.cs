using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectListCmd(string? Schema = null, SqlGroupFlags Filter = SqlGroupFlags.Objects) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.objects.sql";

   protected override Type AssemblyType => typeof(SqlObjectListCmd);
}
