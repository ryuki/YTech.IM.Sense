﻿CREATE TABLE [dbo].[M_PACKET_ITEM_CAT] (
    [PACKET_ITEM_CAT_ID]     NVARCHAR (50)   NOT NULL,
    [PACKET_ID]              NVARCHAR (50)   NULL,
    [ITEM_CAT_ID]            NVARCHAR (50)   NULL,
    [ITEM_CAT_QTY]           DECIMAL (18, 5) NULL,
    [PACKET_ITEM_CAT_STATUS] NVARCHAR (50)   NULL,
    [PACKET_ITEM_CAT_DESC]   NVARCHAR (MAX)  NULL,
    [DATA_STATUS]            NVARCHAR (50)   NULL,
    [CREATED_BY]             NVARCHAR (50)   NULL,
    [CREATED_DATE]           DATETIME        NULL,
    [MODIFIED_BY]            NVARCHAR (50)   NULL,
    [MODIFIED_DATE]          DATETIME        NULL,
    [ROW_VERSION]            TIMESTAMP       NULL
);

