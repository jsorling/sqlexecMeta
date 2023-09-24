using Sorling.SqlExec.mapper.results;

namespace Sorling.SqlExecMeta.security;

public record SqlPrincipalGroupListItem(string Name, string Id, SqlGroupFlags Filter, int Count) : SqlExecBaseResult;
