﻿ALTER TABLE [dbo].[M_ACCOUNT_REF]
    ADD CONSTRAINT [FK_M_ACCOUNT_REF_M_ACCOUNT] FOREIGN KEY ([ACCOUNT_ID]) REFERENCES [dbo].[M_ACCOUNT] ([ACCOUNT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

