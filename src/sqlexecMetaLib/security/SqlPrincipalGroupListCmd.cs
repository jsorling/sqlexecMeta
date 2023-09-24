using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.security;

public record SqlPrincipalGroupListCmd() : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.security.principalgroups.sql";

   protected override Type AssemblyType => typeof(SqlPrincipalGroupListCmd);
}
