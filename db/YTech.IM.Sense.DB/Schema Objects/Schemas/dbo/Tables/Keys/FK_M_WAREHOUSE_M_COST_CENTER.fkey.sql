﻿ALTER TABLE [dbo].[M_WAREHOUSE]
    ADD CONSTRAINT [FK_M_WAREHOUSE_M_COST_CENTER] FOREIGN KEY ([COST_CENTER_ID]) REFERENCES [dbo].[M_COST_CENTER] ([COST_CENTER_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

