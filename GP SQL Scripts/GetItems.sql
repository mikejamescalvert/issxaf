
Create Proc #GetItems
(
@PriceLevel varchar(20)
,@LocnCode varchar(20)

)
AS
--declare @PriceLevel varchar(20)
--declare @LocnCode varchar(20)
--select @PriceLevel='RETAIL'
--Select @LocnCode='WAREHOUSE'

select	im.ITEMNMBR
from IV00101 im
inner join IV00108 ip on im.ITEMNMBR=ip.ITEMNMBR
Where ip.PRCLEVEL=@PriceLevel AND im.LOCNCODE=@LocnCode

GO


