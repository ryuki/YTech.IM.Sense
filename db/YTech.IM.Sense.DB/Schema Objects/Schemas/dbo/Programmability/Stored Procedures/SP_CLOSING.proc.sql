
CREATE PROCEDURE [dbo].[SP_CLOSING]
@periodId nvarchar(50),
@periodType nvarchar(50),
@periodFrom datetime,
@periodTo datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

--get last recap account
with cteLastRecapAccount(ACCOUNT_ID, REC_ACCOUNT_END) as
(
	select r.ACCOUNT_ID 
		, r.REC_ACCOUNT_END
	from dbo.T_REC_ACCOUNT r
	where r.REC_PERIOD_ID = (select top 1 p.REC_PERIOD_ID from dbo.T_REC_ACCOUNT t, dbo.T_REC_PERIOD p
where t.REC_PERIOD_ID=p.REC_PERIOD_ID and p.PERIOD_TO < @periodFrom and p.PERIOD_TYPE = @periodType)
)

--insert recap account
insert into dbo.T_REC_ACCOUNT
(
	REC_ACCOUNT_ID
	, REC_PERIOD_ID
	, COST_CENTER_ID
	, ACCOUNT_ID
	, ACCOUNT_STATUS 
	, REC_ACCOUNT_START
	, REC_ACCOUNT_END
	, REC_ACCOUNT_DESC
	, DATA_STATUS
	, CREATED_BY
	, CREATED_DATE
)

select cast(newid() as nvarchar(50)) REC_ACCOUNT_ID
	, @periodId REC_PERIOD_ID
	, a.COST_CENTER_ID COST_CENTER_ID
	, a.ACCOUNT_ID ACCOUNT_ID
	, null ACCOUNT_STATUS
	, 0 REC_ACCOUNT_START
	, 0 REC_ACCOUNT_END
	, null REC_ACCOUNT_DESC
	, 'NEW' DATA_STATUS
	, '' CREATED_BY
	, getdate() CREATED_DATE
from (
		select cost.COST_CENTER_ID, acc.ACCOUNT_ID
		from dbo.M_ACCOUNT acc 
			inner join dbo.M_COST_CENTER cost 
				on 1=1
		where acc.ACCOUNT_CAT_ID in 
			(
				SELECT ACCOUNT_CAT_ID FROM dbo.M_ACCOUNT_CAT WHERE ACCOUNT_CAT_TYPE = 'LR'
			)
	) a

union all

select cast(newid() as nvarchar(50)) REC_ACCOUNT_ID
	, @periodId REC_PERIOD_ID
	, a.COST_CENTER_ID COST_CENTER_ID
	, a.ACCOUNT_ID ACCOUNT_ID
	, null ACCOUNT_STATUS
	, isnull(a.REC_ACCOUNT_END,0) REC_ACCOUNT_START
	, isnull(a.REC_ACCOUNT_END,0) REC_ACCOUNT_END
	, null REC_ACCOUNT_DESC
	, 'NEW' DATA_STATUS
	, '' CREATED_BY
	, getdate() CREATED_DATE
from (
		select cost.COST_CENTER_ID, acc.ACCOUNT_ID, cte.REC_ACCOUNT_END
		from dbo.M_ACCOUNT acc 
			inner join dbo.M_COST_CENTER cost 
				on 1=1
			left join cteLastRecapAccount cte
				on cte.account_id = acc.account_id
		where acc.ACCOUNT_CAT_ID in 
			(
				SELECT ACCOUNT_CAT_ID FROM dbo.M_ACCOUNT_CAT WHERE ACCOUNT_CAT_TYPE = 'NERACA'
			)
	) a
;

declare @vaccount_id as nvarchar(50);
declare @vcost_center_id as nvarchar(50);
declare @vsaldo as numeric ;
declare account_cursor cursor for
		select a.COST_CENTER_ID
			, a.ACCOUNT_ID 
			, sum(a.jurnal) as SALDO
		from (
			select  j.COST_CENTER_ID
				, det.ACCOUNT_ID 
				, case det.JOURNAL_DET_STATUS
					when 'D' then sum(det.JOURNAL_DET_AMMOUNT)
					when 'K' then sum(det.JOURNAL_DET_AMMOUNT*-1)
				  end jurnal
			from dbo.T_JOURNAL j, dbo.T_JOURNAL_DET det
			where j.JOURNAL_ID = det.JOURNAL_ID 
				and j.JOURNAL_DATE between @periodFrom and @periodTo
			group by  j.COST_CENTER_ID
				, det.ACCOUNT_ID 
				, det.JOURNAL_DET_STATUS
		) a
		group by  a.COST_CENTER_ID, a.ACCOUNT_ID

OPEN account_cursor 
		FETCH NEXT FROM account_cursor INTO @vcost_center_id, @vaccount_id, @vsaldo
		--Fetch next record
		WHILE @@FETCH_STATUS = 0
		BEGIN

exec [SP_UPDATE_REC_ACCOUNT]
	@period_id = @periodId
	, @cost_center_id = @vcost_center_id
	, @account_id = @vaccount_id
	, @ammount = @vsaldo

			FETCH NEXT FROM account_cursor INTO @vcost_center_id, @vaccount_id, @vsaldo
END

CLOSE account_cursor --Close cursor
DEALLOCATE account_cursor --Deallocate cursor


--insert RL account
declare @account_rl_id nvarchar(50);
declare @lr as numeric ;
select @account_rl_id = REFERENCE_VALUE
from dbo.T_REFERENCE r where r.REFERENCE_TYPE = 'LRDitahanAccountId';
declare lr_cursor cursor for
		select	t.COST_CENTER_ID
			, case det.JOURNAL_DET_STATUS
					when 'D' then sum(det.JOURNAL_DET_AMMOUNT)
					when 'K' then sum(det.JOURNAL_DET_AMMOUNT*-1)
				end lr
		from dbo.T_JOURNAL t
			inner join dbo.T_JOURNAL_DET det
				on t.JOURNAL_ID = det.JOURNAL_ID
			inner join dbo.M_ACCOUNT acc 
				on det.ACCOUNT_ID = acc.ACCOUNT_ID
		where t.JOURNAL_DATE between @periodFrom and @periodTo
			and acc.ACCOUNT_CAT_ID in 
			(
				SELECT ACCOUNT_CAT_ID FROM dbo.M_ACCOUNT_CAT WHERE ACCOUNT_CAT_TYPE = 'LR'
			)
		group by t.COST_CENTER_ID, det.JOURNAL_DET_STATUS


OPEN lr_cursor 
		FETCH NEXT FROM lr_cursor INTO @vcost_center_id, @lr
		--Fetch next record
		WHILE @@FETCH_STATUS = 0
		BEGIN

	exec [SP_UPDATE_REC_ACCOUNT]
	@period_id = @periodId
	, @cost_center_id = @vcost_center_id
	, @account_id = @account_rl_id
	, @ammount = @lr

			FETCH NEXT FROM lr_cursor INTO @vcost_center_id,  @lr
END

CLOSE lr_cursor --Close cursor
DEALLOCATE lr_cursor --Deallocate cursor

select @lr as RL
END




