insert into Clinker(HoodName, ReleaseDate)
values ('June Bug', 2020-12-10),
		('Lil Ray', 2022-01-05),
		('Lil Randy', 2042-12-31),
		('Lil Kel', 2020-08-07),
		('Lil Mo', 2020-04-24)

alter table Clinker
drop column ServiceId

select *
from Clinker

delete from Clinker where ClinkerId = 2
delete from Clinker where ClinkerId = 3
delete from Clinker where ClinkerId = 4
delete from Clinker where ClinkerId = 5
delete from Clinker where ClinkerId = 6
dbcc checkident ('Clinker', reseed, 0)
insert into Clinker(HoodName, ReleaseDate)
values ('June Bug', 2020-12-10),
		('Lil Ray', 2022-01-05),
		('Lil Randy', 2042-12-31),
		('Lil Kel', 2020-08-07),
		('Lil Mo', 2020-04-24)


insert into [Service]([Type], ClinkerId)
values ('Cook', 1),
		('Snitch', 2),
		('Negotiator', 3),
		('Thief', 4),
		('Snitch', 5)

select *
from [Service]

insert into Interest (ClinkerId, [Type])
values (1, 'Dominos'),
		(1, 'Basketball'),
		(2, 'Cooking'),
		(2, 'Basketball'),
		(3, 'Sleeping'),
		(3, 'Cooking'),
		(4, 'Sleeping'),
		(4, 'Sneaking'),
		(5, 'Eating'),
		(5, 'Money')

select *
from Interest