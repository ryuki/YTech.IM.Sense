﻿ALTER TABLE [dbo].[T_SHIFT]
    ADD CONSTRAINT [PK_T_SHIFT] PRIMARY KEY CLUSTERED ([SHIFT_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

