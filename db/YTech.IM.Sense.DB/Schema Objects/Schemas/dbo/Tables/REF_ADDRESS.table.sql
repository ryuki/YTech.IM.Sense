﻿CREATE TABLE [dbo].[REF_ADDRESS] (
    [ADDRESS_ID]             NVARCHAR (50) NOT NULL,
    [ADDRESS_LINE1]          NVARCHAR (50) NULL,
    [ADDRESS_LINE2]          NVARCHAR (50) NULL,
    [ADDRESS_LINE3]          NVARCHAR (50) NULL,
    [ADDRESS_PHONE]          NVARCHAR (50) NULL,
    [ADDRESS_FAX]            NVARCHAR (50) NULL,
    [ADDRESS_CITY]           NVARCHAR (50) NULL,
    [ADDRESS_CONTACT]        NVARCHAR (50) NULL,
    [ADDRESS_CONTACT_MOBILE] NVARCHAR (50) NULL,
    [ADDRESS_EMAIL]          NVARCHAR (50) NULL,
    [DATA_STATUS]            NVARCHAR (50) NULL,
    [CREATED_BY]             NVARCHAR (50) NULL,
    [CREATED_DATE]           DATETIME      NULL,
    [MODIFIED_BY]            NVARCHAR (50) NULL,
    [MODIFIED_DATE]          DATETIME      NULL,
    [ROW_VERSION]            TIMESTAMP     NULL
);

