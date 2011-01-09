CREATE TABLE [dbo].[M_EMPLOYEE] (
    [EMPLOYEE_ID]                      NVARCHAR (50)   NOT NULL,
    [PERSON_ID]                        NVARCHAR (50)   NULL,
    [DEPARTMENT_ID]                    NVARCHAR (50)   NULL,
    [EMPLOYEE_STATUS]                  NVARCHAR (50)   NULL,
    [EMPLOYEE_DESC]                    NVARCHAR (MAX)  NULL,
    [DATA_STATUS]                      NVARCHAR (50)   NULL,
    [CREATED_BY]                       NVARCHAR (50)   NULL,
    [CREATED_DATE]                     DATETIME        NULL,
    [MODIFIED_BY]                      NVARCHAR (50)   NULL,
    [MODIFIED_DATE]                    DATETIME        NULL,
    [ROW_VERSION]                      TIMESTAMP       NULL,
    [EMPLOYEE_COMMISSION_PRODUCT_VAL]  DECIMAL (18, 5) NULL,
    [EMPLOYEE_COMMISSION_SERVICE_VAL]  DECIMAL (18, 5) NULL,
    [EMPLOYEE_COMMISSION_PRODUCT_TYPE] NVARCHAR (50)   NULL,
    [EMPLOYEE_COMMISSION_SERVICE_TYPE] NVARCHAR (50)   NULL
);

