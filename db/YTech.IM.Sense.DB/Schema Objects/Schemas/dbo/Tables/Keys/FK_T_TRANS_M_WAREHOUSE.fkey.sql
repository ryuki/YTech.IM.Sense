﻿ALTER TABLE [dbo].[T_TRANS]
    ADD CONSTRAINT [FK_T_TRANS_M_WAREHOUSE] FOREIGN KEY ([WAREHOUSE_ID]) REFERENCES [dbo].[M_WAREHOUSE] ([WAREHOUSE_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

