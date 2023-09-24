﻿using Sorling.SqlExec.mapper.commands;
using Sorling.SqlExecMeta.types;

namespace Sorling.SqlExecMeta.security;

public record SqlPrincipalPrevNxtCmd(string Current, string? TypeText) : ScriptResourceCommand
{
   protected override string SqlResourceText => "Sorling.SqlExecMeta.sqlscripts.security.principalprevnxt.sql";

   protected override Type AssemblyType => typeof(SqlTypesPrevNxtCmd);
}
