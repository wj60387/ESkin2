USE [Stethoscope0930]

-- 新增字段 AudioGroupID
ALTER TABLE dbo.AudioInfo ADD
	AudioGroupID int NULL
GO
-- 修改所有表 AudioGroupID=1
UPDATE dbo.AudioInfo set AudioGroupID=1
GO

-- P_UploadAudioInfo 传入AudioGroupID
ALTER proc [dbo].[P_UpLoadAudioInfo]
  (
       @GUID varchar(50),
       @PGUID  varchar(50),
       @StetName  varchar(50),
       @Part  varchar(50),
       @TakeTime int,
       @RecordTime Datetime,
       @AudioGroupID int )
  as
   if exists (select * from AudioInfo where  StetName=@StetName and  PGUID =@PGUID and  Part=@Part  )
  update AudioInfo set  GUID=@GUID,  TakeTime=@TakeTime, RecordTime=@RecordTime, AudioGroupID=@AudioGroupID
  where StetName=@StetName and PGUID =@PGUID and  Part=@Part  
  else
  insert into AudioInfo( GUID, PGUID, StetName , Part, TakeTime 
  , RecordTime,AudioGroupID    ) select @GUID,@PGUID,@StetName ,@Part,@TakeTime 
  ,@RecordTime
  ,@AudioGroupID

 GO