﻿ALTER TABLE [dbo].[T_TRANS_DET_ITEM]
    ADD CONSTRAINT [FK_T_TRANS_DET_ITEM_M_ITEM] FOREIGN KEY ([ITEM_ID]) REFERENCES [dbo].[M_ITEM] ([ITEM_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;
