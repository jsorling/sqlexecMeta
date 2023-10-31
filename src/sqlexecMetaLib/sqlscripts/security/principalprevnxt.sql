declare @groups table(name nvarchar(128), id char)

insert into @groups(name, id) values
    ('AppRoles', 'A')
    , ('UserCertificates', 'C')
    , ('ExtUsersAzureAD', 'E')
    , ('WinGroups', 'G')
    , ('UserAsymetricKeys', 'K')
    , ('DbRoles', 'R')
    , ('SqlUsers', 'S')
    , ('WinUsers', 'U')
    , ('ExtGroupsAzureAD', 'X');

with pilist as (
    select lag(pi.Name) over (order by pi.Name collate Latin1_General_100_BIN2) PreviousId
        , lag(pi.GroupName) over (order by pi.Name  collate Latin1_General_100_BIN2) PreviousGroup
        , pi.Name CurrentId
        , lead(pi.Name) over (order by pi.Name collate Latin1_General_100_BIN2) NextId
        , lead(pi.GroupName) over (order by pi.Name collate Latin1_General_100_BIN2) NextGroup
    from (
        select g.name collate Latin1_General_100_BIN2 + '.' + p.name  collate Latin1_General_100_BIN2 [Name]
            , g.name [GroupName]
        from sys.database_principals p 
        inner join @groups g on g.id = p.type collate Latin1_General_100_BIN2
        where (( @typetext is not null and g.name = @typetext) or @typetext is null)
    ) pi
) 
select l.PreviousId
    , l.PreviousGroup
    , l.CurrentId
    , l.NextId
    , l.NextGroup
from pilist l
where l.CurrentId = @current collate Latin1_General_100_BIN2