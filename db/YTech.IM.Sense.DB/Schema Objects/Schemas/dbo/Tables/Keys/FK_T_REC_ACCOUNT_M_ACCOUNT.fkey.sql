﻿ALTER TABLE [dbo].[T_REC_ACCOUNT]
    ADD CONSTRAINT [FK_T_REC_ACCOUNT_M_ACCOUNT] FOREIGN KEY ([ACCOUNT_ID]) REFERENCES [dbo].[M_ACCOUNT] ([ACCOUNT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

