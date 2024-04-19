create table Clients (
	ID serial primary key,
	FullName varchar(256),
	TelephoneNumber varchar(32),
	PaymentType int
);
insert into clients(fullname, telephonenumber, paymenttype)
values
	('John Smith', '+3751234567890', 2),
	('Emily Johnson', '+3759876543210', 1),
	('Michael Williams', '+3755551234567', 3),
	('Jessica Brown', '+3759876543210', 0),
	('Christopher Jones', '+3755551234567', 4),
	('Jennifer Davis', '+3751234567890', 2),
	('Matthew Miller', '+3759876543210', 1),
	('Elizabeth Wilson', '+3755551234567', 3),
	('David Anderson', '+3759876543210', 0),
	('Sarah Taylor', '+3755551234567', 4),
	('Daniel Martinez', '+3751234567890', 2),
	('Linda Thomas', '+3759876543210', 1),
	('Andrew Jackson', '+3755551234567', 3),
	('Susan White', '+3759876543210', 0),
	('James Lee', '+3755551234567', 4),
	('Maria Lopez', '+3751234567890', 2),
	('Charles Harris', '+3759876543210', 1),
	('Karen Clark', '+3755551234567', 3),
	('Joseph Young', '+3759876543210', 0),
	('Nancy Hall', '+3755551234567', 4),
	('Robert Turner', '+3751234567890', 2),
	('Lisa Scott', '+3759876543210', 1),
	('William Green', '+3755551234567', 3),
	('Patricia Adams', '+3759876543210', 0),
	('Thomas Baker', '+3755551234567', 4),
	('Jessica Hill', '+3751234567890', 2),
	('Daniel Carter', '+3759876543210', 1),
	('Laura Mitchell', '+3755551234567', 3),
	('Mark Young', '+3759876543210', 0),
	('Sarah Hall', '+3755551234567', 4);	

create table Coocks(
	ID serial primary key,
	Name varchar(128) not null,
	Specialization integer check (Specialization >= 0),
	Payment decimal check (Payment >= 0),
	Post integer check (Post >=0),
	TelephoneNumber varchar(64) not null
);
insert into coocks (name, specialization, payment, post, telephonenumber)
values
	('Octavian August', 1, 250, 2, '+375336612230'),
	('Todd Howard', 4, 2500, 4, '+375334455879'),
	('Nikita Buyanow', 0, 50, 0, '+375296743333'),
	('George Washington', 2, 400, 1, '+375899823666'),
	('Adolf Hitler', 3, 600, 3, '+37529148813372'),
	('Furer Friday', 2, 340, 3, '+375291478232'),
	('Spike Shpigel', 1, 230, 2, '+375123423531'),
	('Jotaro Kujo', 2, 700, 3, '+375223344158'),
	('Kaneki ken', 1, 230, 1, '+375334455160'),
	('Zxcursed', 2, 340, 2, '+375343443130'),
	('Giorno Giovanno', 2, 300, 2, '+375784534120'),
	('Joseph Joestar', 4, 2440, 5, '+375130996633'),
    ('Dio Brando', 1, 250, 2, '+375336612231'),
	('Abdul', 4, 2500, 4, '+375334455880'),
	('Vanomas', 0, 50, 0, '+375296743334'),
	('Ivan Gomaz', 2, 400, 1, '+375899823667'),
	('Tolyan', 3, 600, 3, '+37529148813373'),
	('Kira Yoshikage', 2, 340, 3, '+375291478233'),
	('Light Yagami', 1, 230, 2, '+375123423532'),
	('Saitama', 2, 700, 3, '+375223344159'),
	('Krytoi muzhic 2007', 1, 250, 2, '+375336612232'),
	('Goida', 4, 2500, 4, '+375334455881'),
	('Jenya Prigozhin', 0, 50, 0, '+375296743335'),
	('Prashutto', 2, 400, 1, '+375899823668'),
	('Rizotto Nero', 3, 600, 3, '+37529148813374'),
	('Seryoga Pirat', 2, 340, 3, '+375291478234'),
	('Pol Pot', 1, 230, 2, '+375123423533'),
	('Kakashi Hatake', 2, 700, 3, '+375223344160'),
	('Mikasa Ackerman', 1, 250, 2, '+375336612233'),
	('Killua Zoldyck', 4, 2500, 4, '+375334455882'),
	('Sakura Haruno', 0, 50, 0, '+375296743336'),
	('Rayan Gosling', 1, 300, 2, '+375297878872');


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
	Client_ID integer references clients(ID)
); 
insert into orders(client_id)
values
	(1),
	(2),
	(3),
	(4),
	(5),
	(6),
	(7),
	(8),
	(9),
	(10),
	(11),
	(12),
	(13),
	(14),
	(15),
	(16),
	(17),
	(18),
	(19),
	(20),
	(21),
	(22),
	(23),
	(24),
	(25),
	(26),
	(27),
	(28),
	(29),
	(30);
	

insert into menu(compaund, name, price)
values
	('cheese, dough', 'Pizza Margherita', 9.99),
	('Spaghetti, pork, souse', 'Spaghetti Bolognese', 12.99),
	('crackers, salad, chicken', 'Caesar Salad', 8.99),
	('Salmon, Tuna, Eel', 'Nigiri Sushi', 14.99),
	('Hamburger with French Fries', 'Hamburger with French Fries', 10.99),
	('Cheese, pepperoni', 'Pepperoni Pizza', 11.99),
	('Chicken, fettuccine, Alfredo sauce', 'Chicken Alfredo', 13.99),
	('Mushrooms, rice', 'Mushroom Risotto', 9.99),
	('Beef, vegetables, soy sauce', 'Beef Stir Fry', 14.99),
	('Fried fish, tortillas, salsa', 'Fish Tacos', 10.99),
	('Chicken, lettuce, Caesar dressing', 'Chicken Caesar Wrap', 8.99),
	('Assorted vegetables, curry sauce', 'Vegetable Curry', 12.99),
	('Steak, mashed potatoes', 'Steak with Mashed Potatoes', 15.99),
	('Shrimp, garlic, butter', 'Shrimp Scampi', 13.99),
	('Assorted vegetables, lasagna noodles, cheese', 'Vegetable Lasagna', 11.99),
	('Ribs, BBQ sauce, coleslaw', 'BBQ Ribs', 16.99),
	('Chicken, marinara sauce, cheese', 'Chicken Parmesan', 12.99),
	('Seasoned beef, tortillas, toppings', 'Beef Tacos', 9.99),
	('Pasta, assorted vegetables, cream sauce', 'Pasta Primavera', 11.99),
	('Salmon, teriyaki sauce, rice', 'Teriyaki Salmon', 14.99),
	('Spinach, feta, chicken', 'Spinach and Feta Stuffed Chicken', 13.99),
	('Eggplant, marinara sauce, cheese', 'Eggplant Parmesan', 10.99),
	('lemon, herb, Chicken', 'Lemon Herb Roasted Chicken', 12.99),
	('Beef, broccoli, soy sauce', 'Beef and Broccoli', 11.99),
	('Tomatoes, mozzarella, basil', 'Caprese Salad', 9.99),
	('Pork, apples', 'Pork Chops with Apples', 13.99),
	('Bell peppers, ground beef, rice', 'Stuffed Bell Peppers', 10.99),
	('Chicken, noodles, vegetables', 'Chicken Noodle Soup', 8.99),
	('Lobster, ravioli, sauce', 'Lobster Ravioli', 15.99),
	('Tofu, seaweed, miso', 'Miso Soup', 7.99);
	

create table Order_Coock(
	CoockId integer references coocks(ID),
	OrderNum integer references orders(ID),
	Status integer check (Status >=0),
	primary key (CoockId, OrderNum)
);
insert into order_coock (coockid, ordernum, status)
values
	(1, 2, 0),
	(1, 3, 1),
	(2, 1, 2),
	(2, 4, 0),
	(4, 5, 0),
    (3, 6, 1),
    (3, 8, 1),
    (5, 7, 2),
    (5, 9, 0),
    (6, 10, 1),
    (6, 12, 1),
    (7, 11, 0),
    (7, 13, 2),
    (8, 14, 0),
    (8, 15, 1),
    (9, 17, 2),
    (9, 16, 0),
    (10, 20, 1),
    (10, 18, 1),
    (11, 19, 0),
    (11, 21, 1),
    (12, 22, 1),
    (12, 23, 0),
    (13, 24, 2),
    (13, 25, 0),
    (14, 26, 1),
    (14, 27, 1),
	(15, 28, 1),
	(16, 29, 0),
	(17, 30, 0);


create table order_menu (
  ID serial primary key,
  order_id integer references orders(ID),
  menu_id integer references menu(ID)
);
insert into order_menu (order_id, menu_id)
values
	(1, 1),
	(1, 2),
	(2, 3),
	(3, 5),
	(4, 5),
	(5, 3),
	(5, 6),
	(6, 1),
	(6, 2),
	(7, 8),
	(7, 3),
	(8, 4),
	(9, 5),
	(10, 6),
	(11, 3),
	(11, 2),
	(12, 4),
	(12, 8),
	(12, 3),
	(13, 5),
	(14, 2),
	(15, 7),
	(15, 3),
	(16, 1),
	(16, 15),
	(17, 4),
	(18, 5),
	(19, 6),
	(20, 1),
	(21, 3),
    (22, 25),
    (23, 20),
    (24, 17),
    (25, 18),
    (26, 23),
	(27, 2),
	(27, 4),
	(28, 5),
	(29, 9),
	(30, 11);



alter table Orders
	add order_menu_ID integer references order_menu(ID);
	
update Orders
set order_menu_ID = order_menu.ID
from order_menu
where Orders.ID = order_menu.order_id;


create table Payments(
	ID serial primary key,
	Order_Id int references Orders(id),
	Payment_Date date,
	Payment_Type int check (Payment_Type >= 0) 
);

create table Reviews(
	ID serial primary key,
	Order_id int references orders(id),	
	Rating int check (Rating >= 0 AND Rating <= 10)
);

alter table clients
	drop column paymenttype;

	
insert into Payments (Order_Id, Payment_Date, Payment_Type)
select
    o.id,
    current_date - interval '30 days' * random(),
    floor(random() * 5)
from Orders o
order by random()
limit 30;

insert into Reviews(Order_Id, Rating)
values
	(1, 7),
	(2, 8),
	(3, 6),
    (4, 5),
    (5, 7),
    (6, 8),
    (7, 10),
    (8, 2),
    (9, 3),
    (10, 4),
    (11, 6),
    (12, 5),
    (13, 8),
    (14, 6),
    (15, 9),
    (16, 9),
    (17, 8),
    (18, 7),
    (19, 10),
    (20, 10),
	(21, 5),
	(22, 8),
	(23, 8),
	(24, 8),
    (25, 8),
    (26, 8),
    (27, 9),
    (28, 7),
    (29, 7),
    (30, 8);
	