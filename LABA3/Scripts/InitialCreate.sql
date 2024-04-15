create table Clients (
	ID serial primary key,
	FullName varchar(256),
	TelephoneNumber varchar(32),
	PaymentType int
);

create table Coocks(
	ID serial primary key,
	Name varchar(128) not null,
	Specialization integer check (Specialization >= 0),
	Payment decimal check (Payment >= 0),
	Post integer check (Post >=0),
	TelephoneNumber varchar(64) not null
);

create table menu
(
	ID serial primary key,
	Compaund varchar(256) not null,
	name varchar(64) not null
);

ALTER TABLE menu
ADD COLUMN price double precision;

ALTER TABLE menu
ADD CONSTRAINT price_check CHECK (price > 0);

create table Orders
(
	ID serial primary key,
	Sum double precision check(Sum > 0),
	Client_ID integer references clients(id)
); 

create table Order_Coock(
	PasportNum integer references coocks(ID),
	OrderNum integer references orders(ID),
	Status integer check (Status >=0),
	primary key (PasportNum, OrderNum)
);

create table order_menu (
  ID serial primary key,
  order_id integer references orders(id),
  menu_id integer references menu(id)
);

alter table Orders
	add Dishes_ID integer references order_menu(id);

create table Timetable(
	ID serial primary key, 
	Day integer check(Day >= 0 AND Day <= 7),
	Dayout bool,
	StartTime time not null,
    EndTime time not null
);

create table Warehouse(
	ID serial primary key,
	ProductName varchar(64) not null,
	ProductAmount integer check (ProductAmount >= 0),
	Measurement integer check (Measurement >= 0)
);