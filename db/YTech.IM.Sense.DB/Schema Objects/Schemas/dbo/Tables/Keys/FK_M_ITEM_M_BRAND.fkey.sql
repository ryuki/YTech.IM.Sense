﻿ALTER TABLE [dbo].[M_ITEM]
    ADD CONSTRAINT [FK_M_ITEM_M_BRAND] FOREIGN KEY ([BRAND_ID]) REFERENCES [dbo].[M_BRAND] ([BRAND_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
