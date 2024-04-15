//LAB 4
select name from coocks
where name in ('Jotaro Kujo', 'Furer Friday', 'Dio Brando')
union
select fullname from clients
where fullname in ('Lisa Scott', 'David Adnerson');

select FullName as Name from Clients where ID in (1, 3, 5);

select * from Clients
where ID in (
  select Client_ID
  from Orders
  intersect
  select Order_id
  from Reviews Where rating > 8
);

select avg(Rating) as AverageRating from Reviews;


select avg(price) as averagePrice from Menu where id in (
	select menu_id from order_menu
	intersect
	select id from Menu
);

select ID from Clients
intersect
select Client_ID - 20 from Orders;

select avg(price) as avg_price from menu
union
select sum(Payment) as payment_sum from Coocks;

select count(*) from Reviews;

select max(Payment) from Coocks;


select min(Specialization) from Coocks;

select * from Clients
where exists (
    select 1 from Orders
    where Orders.Client_ID = Clients.ID
);


with ClientOrders as (
    select Clients.FullName, Orders.ID
    from Clients
    inner join Orders on Clients.ID = Orders.Client_ID
)
select * from ClientOrders;


//Найти максимальный рейтинг заказа
select max(Rating) as MaxRating
from Reviews
where exists (
    select 1 from Orders
    where Orders.ID = Reviews.Order_id
);

//Найти минимальную специализацию среди поваров, у которых есть заказы

with CooksWithMinSpecialization as (
    select Name, Specialization
    from Coocks
    where Specialization = (
        select min(Specialization)
        from Coocks
    )
)
select Name, Specialization
from CooksWithMinSpecialization;


SELECT MIN(price) AS MinPrice FROM menu;
//LAB 5