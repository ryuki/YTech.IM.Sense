﻿ALTER TABLE [dbo].[M_EMPLOYEE]
    ADD CONSTRAINT [PK_M_EMPLOYEE] PRIMARY KEY CLUSTERED ([EMPLOYEE_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

