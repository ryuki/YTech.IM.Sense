﻿ALTER TABLE [dbo].[T_JOURNAL_DET]
    ADD CONSTRAINT [PK_T_JOURNAL_DET] PRIMARY KEY CLUSTERED ([JOURNAL_DET_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

