--/dummy data/--
USE [Tracker]
GO
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(1,1,'True')
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(2,1,'True')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(3,1,'True')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(4,1,'True')
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(1,2,'True')
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(2,2,'True')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(3,2,'False')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(4,2,'True')
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(1,3,'True')
INSERT INTO [dbo].[attendance]([userid],[eventid],[present])
     VALUES(2,3,'False')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(3,3,'True')
INSERT INTO [dbo].[attendance] ([userid],[eventid],[present])
     VALUES(4,3,'False')
GO


