﻿ALTER TABLE [dbo].[M_WAREHOUSE]
    ADD CONSTRAINT [FK_M_WAREHOUSE_M_EMPLOYEE] FOREIGN KEY ([EMPLOYEE_ID]) REFERENCES [dbo].[M_EMPLOYEE] ([EMPLOYEE_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

