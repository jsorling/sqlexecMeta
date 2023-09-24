using Sorling.SqlExec.mapper.commands;

namespace Sorling.SqlExecMeta.security;

public record SqlPrincipalListCmd(string? TypeText = null, string? Name = null) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.security.principals.sql";

   protected override Type AssemblyType => typeof(SqlPrincipalListCmd);
}
