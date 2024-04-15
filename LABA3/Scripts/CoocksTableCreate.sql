create table Coocks(
	ID serial primary key,
	Name varchar(128) not null,
	Specialization integer check (Specialization >= 0),
	Payment decimal check (Payment >= 0),
	Post integer check (Post >=0),
	TelephoneNumber varchar(64) not null
);