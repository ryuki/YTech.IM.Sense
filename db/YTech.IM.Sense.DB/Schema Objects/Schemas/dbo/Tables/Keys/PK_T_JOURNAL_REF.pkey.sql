﻿ALTER TABLE [dbo].[T_JOURNAL_REF]
    ADD CONSTRAINT [PK_T_JOURNAL_REF] PRIMARY KEY CLUSTERED ([JOURNAL_REF_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

