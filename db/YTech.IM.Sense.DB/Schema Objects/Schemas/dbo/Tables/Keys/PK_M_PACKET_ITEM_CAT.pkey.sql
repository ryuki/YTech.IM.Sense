﻿ALTER TABLE [dbo].[M_PACKET_ITEM_CAT]
    ADD CONSTRAINT [PK_M_PACKET_ITEM_CAT] PRIMARY KEY CLUSTERED ([PACKET_ITEM_CAT_ID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);

