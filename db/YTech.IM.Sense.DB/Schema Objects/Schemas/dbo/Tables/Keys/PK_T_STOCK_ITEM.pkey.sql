﻿ALTER TABLE [dbo].[T_STOCK_ITEM]
    ADD CONSTRAINT [PK_T_STOCK_ITEM] PRIMARY KEY CLUSTERED ([STOCK_ITEM_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

