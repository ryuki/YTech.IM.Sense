CREATE TABLE [dbo].[T_TRANS_ROOM] (
    [TRANS_ID]                NVARCHAR (50)   NOT NULL,
    [ROOM_ID]                 NVARCHAR (50)   NULL,
    [ROOM_BOOK_DATE]          DATETIME        NULL,
    [ROOM_IN_DATE]            DATETIME        NULL,
    [ROOM_OUT_DATE]           DATETIME        NULL,
    [ROOM_STATUS]             NVARCHAR (50)   NULL,
    [ROOM_CASH_PAID]          DECIMAL (18, 5) NULL,
    [ROOM_CREDIT_PAID]        DECIMAL (18, 5) NULL,
    [ROOM_VOUCHER_PAID]       DECIMAL (18, 5) NULL,
    [ROOM_COMMISSION_PRODUCT] DECIMAL (18, 5) NULL,
    [ROOM_COMMISSION_SERVICE] DECIMAL (18, 5) NULL,
    [ROOM_DESC]               NVARCHAR (MAX)  NULL,
    [DATA_STATUS]             NVARCHAR (50)   NULL,
    [CREATED_BY]              NVARCHAR (50)   NULL,
    [CREATED_DATE]            DATETIME        NULL,
    [MODIFIED_BY]             NVARCHAR (50)   NULL,
    [MODIFIED_DATE]           DATETIME        NULL,
    [ROW_VERSION]             TIMESTAMP       NULL
);

