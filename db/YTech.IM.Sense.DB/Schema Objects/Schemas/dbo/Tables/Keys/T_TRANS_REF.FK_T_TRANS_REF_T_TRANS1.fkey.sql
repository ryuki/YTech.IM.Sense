﻿
ALTER TABLE [dbo].[T_TRANS_REF]  WITH CHECK ADD  CONSTRAINT [FK_T_TRANS_REF_T_TRANS1] FOREIGN KEY([TRANS_ID_REF])
REFERENCES [dbo].[T_TRANS] ([TRANS_ID])