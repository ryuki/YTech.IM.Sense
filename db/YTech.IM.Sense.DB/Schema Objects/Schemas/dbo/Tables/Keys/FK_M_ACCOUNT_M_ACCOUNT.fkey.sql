﻿ALTER TABLE [dbo].[M_ACCOUNT]
    ADD CONSTRAINT [FK_M_ACCOUNT_M_ACCOUNT] FOREIGN KEY ([ACCOUNT_PARENT_ID]) REFERENCES [dbo].[M_ACCOUNT] ([ACCOUNT_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

