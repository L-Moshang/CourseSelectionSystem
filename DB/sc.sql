if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Room_Building]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Room] DROP CONSTRAINT FK_Room_Building
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Course_Course]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Course] DROP CONSTRAINT FK_Course_Course
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_SC_Course]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[SC] DROP CONSTRAINT FK_SC_Course
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_SC_Student]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[SC] DROP CONSTRAINT FK_SC_Student
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[FK_Course_Teacher]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[Course] DROP CONSTRAINT FK_Course_Teacher
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Compare]') and xtype in (N'FN', N'IF', N'TF'))
drop function [dbo].[Compare]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Admin]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Admin]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Building]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Building]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Course]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Course]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[CourseTime]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[CourseTime]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Room]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Room]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SC]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[SC]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Student]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Student]
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Teacher]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [dbo].[Teacher]
GO

SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS OFF 
GO


CREATE FUNCTION dbo.Compare (@time1 char(10),@time2 char(10))  
RETURNS int AS  
BEGIN
declare @start int;
set @start = 1; 
while @start < len(@time1)
begin
	declare @subtime char(2);
	select @subtime = substring(@time1,@start,2);
	if(@time2 like ('%'+@subtime+'%'))
		return 1;
	set @start = @start+3;
end;
return 0;
END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO

CREATE TABLE [dbo].[Admin] (
	[AId] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Akey] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Building] (
	[BuildingId] [int] IDENTITY (1, 1) NOT NULL ,
	[BuildingName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Course] (
	[CId] [int] IDENTITY (1, 1) NOT NULL ,
	[TId] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[CName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[CType] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[CCredit] [float] NULL ,
	[CMax] [int] NULL ,
	[CNote] [text] COLLATE Chinese_PRC_CI_AS NULL ,
	[CPreCId] [int] NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[CourseTime] (
	[CId] [int] NOT NULL ,
	[RoomId] [int] NOT NULL ,
	[CWeekStart] [int] NOT NULL ,
	[CWeekEnd] [int] NOT NULL ,
	[CTime] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Room] (
	[RoomId] [int] IDENTITY (1, 1) NOT NULL ,
	[BuildingId] [int] NOT NULL ,
	[RoomName] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[RoomSize] [int] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[SC] (
	[SId] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[CId] [int] NOT NULL ,
	[Score] [float] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Student] (
	[SId] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Skey] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[SName] [varchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[SSex] [varchar] (2) COLLATE Chinese_PRC_CI_AS NULL ,
	[SAge] [int] NULL ,
	[SCredit] [float] NULL ,
	[SAddress] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SPhone] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SEmail] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[SLocked] [bit] NULL 
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Teacher] (
	[TId] [varchar] (20) COLLATE Chinese_PRC_CI_AS NOT NULL ,
	[Tkey] [varchar] (40) COLLATE Chinese_PRC_CI_AS NULL ,
	[TName] [char] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[TSex] [varchar] (2) COLLATE Chinese_PRC_CI_AS NULL ,
	[TAge] [int] NULL ,
	[TPhone] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[TMail] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
GO

