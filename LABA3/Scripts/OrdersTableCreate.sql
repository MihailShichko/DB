create table Orders
(
	ID serial primary key,
	Sum double precision check(Sum > 0),
	Dishes_ID integer references menu(id),
	Client_ID integer references clients(id)
); 