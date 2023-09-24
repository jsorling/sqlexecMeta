using Sorling.SqlExec.mapper.commands;

namespace sqlexecMetaTests;
internal record TestScriptCommand : ScriptResourceCommand
{
   protected override string SqlResourceText => "sqlexecMetaTests.scriptresources.TestObjects.sql";

   protected override Type AssemblyType => typeof(TestScriptCommand);
}
