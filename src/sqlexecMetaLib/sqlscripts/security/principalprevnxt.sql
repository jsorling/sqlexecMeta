declare @groups table(name nvarchar(128), groupflag bigint, id char)

insert into @groups(name, groupflag, id) values
    ('AppRoles', 1024, 'A')
    , ('UserCertificates', 2048, 'C')
    , ('ExtUsersAzureAD', 4096, 'E')
    , ('WinGroups', 8192, 'G')
    , ('UserAsymetricKeys', 16384, 'K')
    , ('DbRoles', 512, 'R')
    , ('SqlUsers', 32768, 'S')
    , ('WinUsers', 65536, 'U')
    , ('ExtGroupsAzureAD', 131072, 'X');

with pilist as (
    select lag(pi.Name) over (order by pi.Name collate Latin1_General_100_BIN2) PreviousId
        , lag(pi.GroupName) over (order by pi.Name  collate Latin1_General_100_BIN2) PreviousGroup
        , pi.Name CurrentId
        , lead(pi.Name) over (order by pi.Name collate Latin1_General_100_BIN2) NextId
        , lead(pi.GroupName) over (order by pi.Name collate Latin1_General_100_BIN2) NextGroup
    from (
        select g.name collate Latin1_General_100_BIN2 + '.' + p.name  collate Latin1_General_100_BIN2 [Name]
            , g.groupflag [GroupName]
        from sys.database_principals p 
        inner join @groups g on g.id = p.type collate Latin1_General_100_BIN2
        where (( @groupflags is not null and g.groupflag = @groupflags) or @groupflags is null)
    ) pi
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from pilist l
where l.CurrentId = @current collate Latin1_General_100_BIN2