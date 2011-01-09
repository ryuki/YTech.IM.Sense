CREATE TABLE [dbo].[M_ITEM_UOM] (
    [ITEM_UOM_ID]              NVARCHAR (50)   NOT NULL,
    [ITEM_ID]                  NVARCHAR (50)   NOT NULL,
    [ITEM_UOM_NAME]            NVARCHAR (50)   NULL,
    [ITEM_UOM_REF_ID]          NVARCHAR (50)   NULL,
    [ITEM_UOM_CONVERTER_VALUE] NUMERIC (18, 5) NULL,
    [ITEM_UOM_SALE_PRICE]      NUMERIC (18, 5) NULL,
    [ITEM_UOM_PURCHASE_PRICE]  NUMERIC (18, 5) NULL,
    [ITEM_UOM_HPP_PRICE]       NUMERIC (18, 5) NULL,
    [ITEM_UOM_DESC]            NVARCHAR (50)   NULL,
    [DATA_STATUS]              NVARCHAR (50)   NULL,
    [CREATED_BY]               NVARCHAR (50)   NULL,
    [CREATED_DATE]             DATETIME        NULL,
    [MODIFIED_BY]              VARCHAR (50)    NULL,
    [MODIFIED_DATE]            DATETIME        NULL,
    [ROW_VERSION]              TIMESTAMP       NULL
);

