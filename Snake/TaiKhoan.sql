use QLTK
go

create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
)
go
insert into [User] values (NEWID(), 'user01', '123')
insert into [User] values (NEWID(), 'user02', '124')
insert into [User] values (NEWID(), 'user03', '126')
go
select *from [User]