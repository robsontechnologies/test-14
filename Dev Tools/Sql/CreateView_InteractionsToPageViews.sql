-- =====================================================================================================
-- Author:        Rock
-- Create Date: 
-- Modified Date: 01-03-2021
-- Description:   This script creates the following views for data that was moved to the Interactions Tables:
--                 - vPageView
--                 - vPageViewUserAgent
--                 - vPageViewSession
--
-- Change History:
--                 01-03-2021 COREYH - Fixed query that was joining on nonexisitent ChannelId instead of 
--                                     InteractionChannelId  
-- =====================================================================================================

IF OBJECT_ID(N'[dbo].[vPageView]', 'V') IS NOT NULL
    DROP VIEW vPageView
GO

CREATE VIEW vPageView
AS
SELECT i.[Id]
    ,icp.EntityId [PageId]
    ,ich.ChannelEntityId [SiteId]
    ,i.[PersonAliasId]
    ,i.InteractionDateTime [DateTimeViewed]
    ,i.[Guid]
    ,i.InteractionData [Url]
    ,icp.[Name] [PageTitle]
    ,i.[ForeignKey]
    ,i.[ForeignGuid]
    ,i.[ForeignId]
    ,iss.Id [PageViewSessionId]
FROM [Interaction] i
join InteractionComponent icp on i.InteractionComponentId = icp.Id
join InteractionChannel ich on icp.InteractionChannelId = ich.Id
join InteractionSession iss on i.InteractionSessionId = iss.Id 
GO


/* vPageViewUserAgent*/
IF OBJECT_ID(N'[dbo].[vPageViewUserAgent]', 'V') IS NOT NULL
    DROP VIEW vPageViewUserAgent
GO

CREATE VIEW vPageViewUserAgent
AS
SELECT dt.[Id]
      ,dt.DeviceTypeData [UserAgent]
      ,dt.[ClientType]
      ,dt.[OperatingSystem]
      ,dt.[Application] [Browser]
      ,dt.[Guid]
      ,dt.[ForeignId]
      ,dt.[ForeignGuid]
      ,dt.[ForeignKey]
  FROM [InteractionDeviceType] dt
GO

/* vPageViewSession*/
IF OBJECT_ID(N'[dbo].[vPageViewSession]', 'V') IS NOT NULL
    DROP VIEW vPageViewSession
GO

CREATE VIEW vPageViewSession
AS
SELECT iss.[Id]
    ,iss.DeviceTypeId [PageViewUserAgentId]
    ,iss.[Guid] [SessionId]
    ,iss.[IpAddress]
    ,iss.[Guid]
    ,iss.[ForeignId]
    ,iss.[ForeignGuid]
    ,iss.[ForeignKey]
FROM [InteractionSession] iss

