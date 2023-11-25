if not exists ( select * from sys.schemas where name = N'sqmtest' ) 
      exec('create schema [sqmtest]');
GO

if object_id('sqmtest.FunctionB', 'TF') is not null
    drop function sqmtest.FunctionB
GO

if object_id('sqmtest.FunctionA', 'FN') is not null
    drop function sqmtest.FunctionA
GO

if exists (select null 
    from sys.types t 
    cross apply(
        select * from sys.schemas s where s.schema_id = t.schema_id and s.name = 'sqmtest'
    ) x
    where t.name = 'tabletype1')
    drop type sqmtest.tabletype1
GO

if object_id('sqmtest.sprserror', 'P') is not null
    drop procedure sqmtest.sprserror
GO

if object_id('sqmtest.spmanyresultset', 'P') is not null
    drop procedure sqmtest.spmanyresultset
GO

if object_id('sqmtest.sponeresultset', 'P') is not null
    drop procedure sqmtest.sponeresultset
GO

if object_id('sqmtest.spnoresnopar', 'P') is not null
    drop procedure sqmtest.spnoresnopar
GO

if object_id('sqmtest.view1', 'V') is not null
    drop view sqmtest.view1
GO

if object_id('sqmtest.table1', 'U') is not null
    drop table sqmtest.table1
GO

create table sqmtest.table1(
    astring nvarchar ( 65 ),
    anint int
)
GO

if object_id('sqmtest.table2', 'U') is not null
    drop table sqmtest.table2
GO

create table sqmtest.table2(
    astring nvarchar ( 65 ) constraint df_table2_astring default '123',
    anint int
)
GO

create view sqmtest.view1 as select anint + 2 plustwo from sqmtest.table1
GO

create procedure sqmtest.spnoresnopar
as
    begin
        declare @tor int = (select count(*) from sqmtest.table1)
        return @tor
    end
GO

create procedure sqmtest.sponeresultset
as
    begin
        select astring, anint from sqmtest.table1
    end
GO

create procedure sqmtest.spmanyresultset
as
    begin
        select astring, anint from sqmtest.table1
        select 'second resultset' second
    end
GO

create procedure sqmtest.sprserror
as
    begin
        select * from sqmtest.doesnotexists
end
GO

create type sqmtest.tabletype1 as table(
    [Result] [int] null,
    [EndUserInfo] [bit] null,
    [ResultText] [nvarchar](512) null
)
GO

create function sqmtest.FunctionA (@anInt int)
  returns int
as begin
  return 3
end
GO

create function sqmtest.FunctionB (@anInt int)
  returns @aTable table ( AnId int, AString nvarchar (65) )
as
 begin
  insert @aTable ( AnId, AString ) 
  select AnId, AString from testssqlmappingproject.TableA

  return
end
GO

create trigger triggertable1
    on sqmtest.table1
    after insert, update
as begin
    declare @hello nvarchar(12) = 'hello trigger'
    print @hello
end
GO
