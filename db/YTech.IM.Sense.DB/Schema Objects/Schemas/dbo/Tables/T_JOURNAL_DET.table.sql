CREATE TABLE [dbo].[T_JOURNAL_DET] (
    [JOURNAL_DET_ID]          NVARCHAR (50)   NOT NULL,
    [JOURNAL_ID]              NVARCHAR (50)   NOT NULL,
    [ACCOUNT_ID]              NVARCHAR (50)   NOT NULL,
    [JOURNAL_DET_NO]          INT             NULL,
    [JOURNAL_DET_STATUS]      NVARCHAR (50)   NULL,
    [JOURNAL_DET_AMMOUNT]     NUMERIC (18, 5) NULL,
    [JOURNAL_DET_DESC]        NVARCHAR (MAX)  NULL,
    [DATA_STATUS]             NVARCHAR (50)   NULL,
    [CREATED_BY]              NVARCHAR (50)   NULL,
    [CREATED_DATE]            DATETIME        NULL,
    [MODIFIED_BY]             NVARCHAR (50)   NULL,
    [MODIFIED_DATE]           DATETIME        NULL,
    [ROW_VERSION]             TIMESTAMP       NULL,
    [JOURNAL_DET_EVIDENCE_NO] NVARCHAR (50)   NULL
);

