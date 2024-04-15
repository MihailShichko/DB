create table Warehouse(
	ID serial primary key,
	ProductName varchar(64) not null,
	ProductAmount integer check (ProductAmount >= 0),
	Measurement integer check (Measurement >= 0)
);