using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.objects;

public record SqlObjectPrevNxtCmd(string CurrentObj, string CurrentType, string? Schema = null
   , SqlGroupFlags Filter = SqlGroupFlags.Objects) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.objects.objectprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlObjectPrevNxtCmd);
}
