﻿ALTER TABLE [dbo].[T_STOCK]
    ADD CONSTRAINT [FK_T_STOCK_M_ITEM] FOREIGN KEY ([ITEM_ID]) REFERENCES [dbo].[M_ITEM] ([ITEM_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

