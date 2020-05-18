select Clinker.HoodName, [Service].[Type] as [Service], [Service].ClinkerId
                        from Service
	                        join Clinker
		                        on Service.ClinkerId = Clinker.Id

select *
from ClinkerInterest

drop table ClinkerInterest

drop table ClinkerService

create table ClinkerInterest (
	ClinkerInterestId int not null identity(1,1) Primary key,
	ClinkerId int foreign key references Clinker(Id)
)

alter table clinkerinterest
add InterestId int foreign key references Interest(Id)

insert into ClinkerInterest (ClinkerId, InterestId)
values (1, 1),
		(1, 2),
		(2, 3),
		(2, 2),
		(3, 4),
		(3, 3),
		(4, 4),
		(4, 5),
		(5, 6),
		(5, 7)

select *
from ClinkerInterest

create table ClinkerService (
	ClinkerServiceId int not null identity(1,1) Primary key,
	ClinkerId int foreign key references Clinker(Id),
	ServiceId int foreign key references [Service](Id)
)

insert into ClinkerService (ClinkerId, ServiceId)
values (1, 6),
		(2, 9),
		(3, 10),
		(4, 8),
		(5, 9)

select Clinker.HoodName, [Service].[Type] as [Service], ClinkerService.ClinkerId
from ClinkerService
	join Clinker
		on ClinkerService.ClinkerId = Clinker.Id
	join [Service]
		on ClinkerService.ServiceId = [Service].Id

select ClinkerInterest.ClinkerId, Interest.[Type] as Interest
from ClinkerInterest
	join Clinker
		on ClinkerInterest.ClinkerId = Clinker.Id
	join Interest
		on ClinkerInterest.InterestId = Interest.Id