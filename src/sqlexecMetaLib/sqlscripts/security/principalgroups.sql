declare @groups table(name nvarchar(128) not null
    , id nchar(1) not null
    , filter bigint not null)

insert into @groups(name, id, filter) values
    ('AppRoles', 'A', 1024)
    , ('UserCertificates', 'C', 2048)
    , ('ExtUsersAzureAD', 'E', 4096)
    , ('WinGroups', 'G', 8192)
    , ('UserAsymetricKeys', 'K', 16384)
    , ('DbRoles', 'R', 512)
    , ('SqlUsers', 'S', 32768)
    , ('WinUsers', 'U', 65536)
    , ('ExtGroupsAzureAD', 'X', 131072);

select g.name, g.id, g.filter, count (*) count from @groups g
inner join sys.database_principals p on p.type = g.id collate Latin1_General_100_BIN2
group by g.name, g.id, g.filter
order by g.name