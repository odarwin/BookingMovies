--a. Generar el query necesario para obtener las reservas de películas cuyo genero sea terror y con un rango de fechas
declare @fecha_inicio date='20102023', @fecha_fin date ='31122023'
select bo.
from BookingEntity bo
inner join BillboardEntity bi
on bo.BillboardId=bi.Id
inner join MovieEntity m
on m.id=bi.MovieId
where m.Genre like 'TERROR'
and bo.Date between @fecha_inicio and @fecha_fin


---b. Generar el query necesario para obtener el numero de butacas disponibles y ocupadas por sala en la cartelera del día actual.


select r.Number,count(s.Number)'butacas ocupadas'
from SeatEntity s
inner join RoomEntity r
on s.RoomId=r.Id
inner join BillboardEntity b
on b.RoomId=r.Id
inner join BookingEntity bo
on bo.BillboardId=b.Id and bo.SeatId=s.Id
where b.Date = CONVERT(date, GETDATE())
group by r.Number

union

select r.Number,count(s.Number)'butacas disponibles'
from SeatEntity s
inner join RoomEntity r
on s.RoomId=r.Id
inner join BillboardEntity b
on b.RoomId=r.Id
left join BookingEntity bo
on bo.BillboardId=b.Id and bo.SeatId=s.Id
where b.Date = CONVERT(date, GETDATE())
and bo.Id is null
group by r.Number