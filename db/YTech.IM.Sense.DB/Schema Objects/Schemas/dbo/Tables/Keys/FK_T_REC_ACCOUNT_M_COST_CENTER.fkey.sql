﻿ALTER TABLE [dbo].[T_REC_ACCOUNT]
    ADD CONSTRAINT [FK_T_REC_ACCOUNT_M_COST_CENTER] FOREIGN KEY ([COST_CENTER_ID]) REFERENCES [dbo].[M_COST_CENTER] ([COST_CENTER_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

