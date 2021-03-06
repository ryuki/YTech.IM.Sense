﻿CREATE TABLE [dbo].[M_SUPPLIER] (
    [SUPPLIER_ID]       NVARCHAR (50)   NOT NULL,
    [SUPPLIER_NAME]     NVARCHAR (50)   NOT NULL,
    [ADDRESS_ID]        NVARCHAR (50)   NULL,
    [SUPPLIER_STATUS]   NVARCHAR (50)   NULL,
    [SUPPLIER_MAX_DEBT] NUMERIC (18, 5) NULL,
    [SUPPLIER_DESC]     NVARCHAR (MAX)  NULL,
    [DATA_STATUS]       NVARCHAR (50)   NULL,
    [CREATED_BY]        NVARCHAR (50)   NULL,
    [CREATED_DATE]      DATETIME        NULL,
    [MODIFIED_BY]       NVARCHAR (50)   NULL,
    [MODIFIED_DATE]     DATETIME        NULL,
    [ROW_VERSION]       TIMESTAMP       NULL
);

