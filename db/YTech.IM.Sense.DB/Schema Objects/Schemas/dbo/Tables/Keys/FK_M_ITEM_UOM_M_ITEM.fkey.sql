﻿ALTER TABLE [dbo].[M_ITEM_UOM]
    ADD CONSTRAINT [FK_M_ITEM_UOM_M_ITEM] FOREIGN KEY ([ITEM_ID]) REFERENCES [dbo].[M_ITEM] ([ITEM_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
