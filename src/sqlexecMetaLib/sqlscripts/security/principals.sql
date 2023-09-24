select p.name
    , p.principal_id
    , p.type
    , p.type_desc
    , p.default_schema_name
    , p.create_date
    , p.modify_date
    , p.owning_principal_id
    , p.sid
    , p.is_fixed_role
    , p.authentication_type
    , p.authentication_type_desc
    , p.default_language_name
    , p.default_language_lcid
    , p.allow_encrypted_value_modifications
    , db_name() DBName
    , case 
        when p.type = 'A' then 'AppRoles'
        when p.type = 'C' then 'UserCertificates'
        when p.type = 'E' then 'ExtUsersAzureAD'
        when p.type = 'G' then 'WinGroups'
        when p.type = 'K' then 'UserAsymetricKeys'
        when p.type = 'R' then 'DbRoles'
        when p.type = 'S' then 'SqlUsers'
        when p.type = 'U' then 'WinUsers'
        when p.Type = 'X' then 'ExtGroupsAzureAD'
    end [Group]
    , cast(
        case 
            when p.type = 'A' then 1024
            when p.type = 'C' then 2048
            when p.type = 'E' then 4096
            when p.type = 'G' then 8192
            when p.type = 'K' then 16384
            when p.type = 'R' then 512
            when p.type = 'S' then 32768
            when p.type = 'U' then 65536
            when p.Type = 'X' then 131072
        end
    as bigint) GroupFlag
from sys.database_principals p
where (@name is not null and @typetext is not null and
    (
        (@name = p.name and @typetext = 'AppRoles' and p.type = 'A')
        or (@name = p.name and @typetext = 'UserCertificates' and p.type = 'C')
        or (@name = p.name and @typetext = 'ExtUsersAzureAD' and p.type = 'E')
        or (@name = p.name and @typetext = 'WinGroups' and p.type = 'G')
        or (@name = p.name and @typetext = 'UserAsymetricKeys' and p.type = 'K')
        or (@name = p.name and @typetext = 'DbRoles' and p.type = 'R')
        or (@name = p.name and @typetext = 'SqlUsers' and p.type = 'S')
        or (@name = p.name and @typetext = 'WinUsers' and p.type = 'U')
        or (@name = p.name and @typetext = 'ExtGroupsAzureAD' and p.type = 'X')
    )) --name match
    or 
    (@typetext is not null and @name is null and
        ((@typetext = 'AppRoles' and p.type = 'A')
        or (@typetext = 'UserCertificates' and p.type = 'C')
        or (@typetext = 'ExtUsersAzureAD' and p.type = 'E')
        or (@typetext = 'WinGroups' and p.type = 'G')
        or (@typetext = 'UserAsymetricKeys' and p.type = 'K')
        or (@typetext = 'DbRoles' and p.type = 'R')
        or (@typetext = 'SqlUsers' and p.type = 'S')
        or (@typetext = 'WinUsers' and p.type = 'U')
        or (@typetext = 'ExtGroupsAzureAD' and p.type = 'X')
    )) -- typetext match
    or @typetext is null
