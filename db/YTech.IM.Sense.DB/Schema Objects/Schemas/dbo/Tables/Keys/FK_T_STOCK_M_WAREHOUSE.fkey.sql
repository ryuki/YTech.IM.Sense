﻿ALTER TABLE [dbo].[T_STOCK]
    ADD CONSTRAINT [FK_T_STOCK_M_WAREHOUSE] FOREIGN KEY ([WAREHOUSE_ID]) REFERENCES [dbo].[M_WAREHOUSE] ([WAREHOUSE_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

