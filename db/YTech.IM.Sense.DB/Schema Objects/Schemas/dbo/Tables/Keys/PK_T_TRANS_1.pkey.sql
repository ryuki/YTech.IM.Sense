﻿ALTER TABLE [dbo].[T_TRANS]
    ADD CONSTRAINT [PK_T_TRANS_1] PRIMARY KEY CLUSTERED ([TRANS_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

