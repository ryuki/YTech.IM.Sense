﻿CREATE TABLE [dbo].[M_ITEM_CAT] (
    [ITEM_CAT_ID]   NVARCHAR (50) NOT NULL,
    [ITEM_CAT_NAME] NVARCHAR (50) NOT NULL,
    [ITEM_CAT_DESC] NVARCHAR (50) NULL,
    [DATA_STATUS]   NVARCHAR (50) NULL,
    [CREATED_BY]    NVARCHAR (50) NULL,
    [CREATED_DATE]  DATETIME      NULL,
    [MODIFIED_BY]   NVARCHAR (50) NULL,
    [MODIFIED_DATE] DATETIME      NULL,
    [ROW_VERSION]   TIMESTAMP     NULL
);

