create table Orders
(
	ID serial primary key,
	Sum double precision check(Sum > 0),
	Client_ID integer references clients(id)
); 

create table order_menu (
  ID integer primary key,
  order_id integer references orders(id),
  menu_id integer references menu(id)
);

alter table Orders
	add Dishes_ID integer references order_menu(id);
