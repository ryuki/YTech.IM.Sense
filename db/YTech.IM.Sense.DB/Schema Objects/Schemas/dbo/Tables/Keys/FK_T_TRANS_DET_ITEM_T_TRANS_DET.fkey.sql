﻿ALTER TABLE [dbo].[T_TRANS_DET_ITEM]
    ADD CONSTRAINT [FK_T_TRANS_DET_ITEM_T_TRANS_DET] FOREIGN KEY ([TRANS_DET_ID]) REFERENCES [dbo].[T_TRANS_DET] ([TRANS_DET_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

