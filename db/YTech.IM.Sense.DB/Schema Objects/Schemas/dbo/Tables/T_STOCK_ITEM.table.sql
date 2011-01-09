﻿CREATE TABLE [dbo].[T_STOCK_ITEM] (
    [ITEM_ID]         NVARCHAR (50)   NOT NULL,
    [WAREHOUSE_ID]    NVARCHAR (50)   NOT NULL,
    [ITEM_STOCK_MAX]  NUMERIC (18, 5) NULL,
    [ITEM_STOCK_MIN]  NUMERIC (18, 5) NULL,
    [ITEM_STOCK]      NUMERIC (18, 5) NULL,
    [ITEM_STOCK_RACK] NVARCHAR (50)   NULL,
    [DATA_STATUS]     NVARCHAR (50)   NULL,
    [CREATED_BY]      NVARCHAR (50)   NULL,
    [CREATED_DATE]    DATETIME        NULL,
    [MODIFIED_BY]     NVARCHAR (50)   NULL,
    [MODIFIED_DATE]   DATETIME        NULL,
    [ROW_VERSION]     TIMESTAMP       NULL,
    [STOCK_ITEM_ID]   NVARCHAR (50)   NOT NULL
);
