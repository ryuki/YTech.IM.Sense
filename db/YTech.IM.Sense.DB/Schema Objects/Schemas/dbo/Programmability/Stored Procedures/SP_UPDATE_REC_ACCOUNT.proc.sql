
CREATE PROCEDURE [dbo].[SP_UPDATE_REC_ACCOUNT]
  @period_id AS nvarchar(50)
, @cost_center_id AS nvarchar(50)
, @account_id AS nvarchar(50)
, @ammount AS numeric
   AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	--search parent of account by recursive select
	with ctechild(COST_CENTER_ID, ACCOUNT_ID, ACCOUNT_PARENT_ID, ACCOUNT_LEVEL) as 
	( 
		select r.COST_CENTER_ID, acc.ACCOUNT_ID, acc.ACCOUNT_PARENT_ID, 0 as ACCOUNT_LEVEL
		from dbo.T_REC_ACCOUNT r  inner join dbo.M_ACCOUNT acc on r.ACCOUNT_ID = acc.ACCOUNT_ID 
		where r.ACCOUNT_ID = @account_id
			and r.COST_CENTER_ID = @cost_center_id
			and r.REC_PERIOD_ID = @period_id
		union all
		select r.COST_CENTER_ID, acc.ACCOUNT_ID,acc.ACCOUNT_PARENT_ID, c.ACCOUNT_LEVEL+1
		from dbo.T_REC_ACCOUNT r inner join dbo.M_ACCOUNT acc on r.ACCOUNT_ID = acc.ACCOUNT_ID 
		inner join ctechild c
			on c.ACCOUNT_PARENT_ID = acc.ACCOUNT_ID
		where r.COST_CENTER_ID = @cost_center_id
			and r.REC_PERIOD_ID = @period_id
	)
	--update m_account and his parents, add balance if status = debet
	update dbo.T_REC_ACCOUNT
	set REC_ACCOUNT_END = REC_ACCOUNT_END + @ammount
	from ctechild i, dbo.T_REC_ACCOUNT a
	where i.COST_CENTER_ID = a.COST_CENTER_ID
		and i.ACCOUNT_ID = a.ACCOUNT_ID
		and a.REC_PERIOD_ID = @period_id;

END



