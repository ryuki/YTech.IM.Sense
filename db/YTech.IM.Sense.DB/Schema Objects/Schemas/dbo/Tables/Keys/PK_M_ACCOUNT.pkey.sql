﻿ALTER TABLE [dbo].[M_ACCOUNT]
    ADD CONSTRAINT [PK_M_ACCOUNT] PRIMARY KEY CLUSTERED ([ACCOUNT_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

