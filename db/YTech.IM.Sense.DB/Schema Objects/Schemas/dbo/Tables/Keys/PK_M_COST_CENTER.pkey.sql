﻿ALTER TABLE [dbo].[M_COST_CENTER]
    ADD CONSTRAINT [PK_M_COST_CENTER] PRIMARY KEY CLUSTERED ([COST_CENTER_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);
