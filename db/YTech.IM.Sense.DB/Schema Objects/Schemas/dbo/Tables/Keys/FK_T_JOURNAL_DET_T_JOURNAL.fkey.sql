﻿ALTER TABLE [dbo].[T_JOURNAL_DET]
    ADD CONSTRAINT [FK_T_JOURNAL_DET_T_JOURNAL] FOREIGN KEY ([JOURNAL_ID]) REFERENCES [dbo].[T_JOURNAL] ([JOURNAL_ID]) ON DELETE NO ACTION ON UPDATE NO ACTION;

