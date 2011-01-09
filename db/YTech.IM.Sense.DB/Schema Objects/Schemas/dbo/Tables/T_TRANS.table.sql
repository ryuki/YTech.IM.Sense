CREATE TABLE [dbo].[T_TRANS] (
    [TRANS_ID]             NVARCHAR (50)   NOT NULL,
    [WAREHOUSE_ID]         NVARCHAR (50)   NULL,
    [WAREHOUSE_ID_TO]      NVARCHAR (50)   NULL,
    [TRANS_DATE]           DATETIME        NULL,
    [TRANS_BY]             NVARCHAR (50)   NULL,
    [TRANS_REF_ID]         NVARCHAR (50)   NULL,
    [TRANS_FACTUR]         NVARCHAR (50)   NULL,
    [EMPLOYEE_ID]          NVARCHAR (50)   NULL,
    [TRANS_DUE_DATE]       DATETIME        NULL,
    [TRANS_PAYMENT_METHOD] NVARCHAR (50)   NULL,
    [TRANS_SUB_TOTAL]      NUMERIC (18, 5) NULL,
    [TRANS_DISC]           NUMERIC (18, 5) NULL,
    [TRANS_TAX]            NUMERIC (18, 5) NULL,
    [TRANS_STATUS]         NVARCHAR (50)   NULL,
    [TRANS_DESC]           NVARCHAR (MAX)  NULL,
    [DATA_STATUS]          NVARCHAR (50)   NULL,
    [CREATED_BY]           NVARCHAR (50)   NULL,
    [CREATED_DATE]         DATETIME        NULL,
    [MODIFIED_BY]          NVARCHAR (50)   NULL,
    [MODIFIED_DATE]        DATETIME        NULL,
    [ROW_VERSION]          TIMESTAMP       NULL
);

