//LIKE
//ORDER BY
select * from Clients 
where FullName like 'S%'
order by id desc;

select * from Clients
where telephoneNumber like '%0' 
order by FullName asc
limit 5;


//CROSS JOIN 
//INNER\OUTER JOIN 

select fullname, name, price  
from clients c
join orders o on o.client_id = c.id
join order_menu om on om.order_id = o.id
join menu m on m.id = om.menu_id;

select fullname, name, price  
from clients c
join orders o on o.client_id = c.id
join order_menu om on om.order_id = o.id
join menu m on m.id = om.menu_id
and (m.price > 13);


select c.name, m.name 
from coocks c
cross join menu m where c.specialization > 3 and m.price > 14;

select c.fullname, m.name
from Clients c
cross join Menu m where m.price < 10;

//LEFT\RIGHT\FULL JOIN 
select distinct c.name
from coocks c 
left join order_coock on c.id = order_coock.coockid;

select c.FullName, p.Payment_Date
from Clients c
left join Payments p on c.ID = p.Order_Id;

//DISTINCT\UNIQUE 
select o.client_id as client, o.id as order, rating 
from reviews r 
join orders o on r.order_id = o.id
order by rating desc;

//ALL 
//ASC 
select * from Coocks c
where payment < all (select price * 30 from menu)
order by name asc;

select c.id, fullname, telephonenumber, rating from Clients c
join orders o on o.client_id = c.id
join reviews r on o.id = r.order_id
where r.rating < all (
	select c.id from Clients c
	join orders o on o.client_id = c.id
	join reviews r on o.id = r.order_id
	join order_menu om on om.order_id = o.id
	join menu m on m.id = om.menu_id
	where m.id = 6)
order by id desc



//DESK
//NULL
select * from Clients 
where TelephoneNumber is not NULL 
order by id desc;

select * from Reviews 
where Rating is NULL 
order by Rating desc;

select c.id as client_id, c.fullname, o.id as order_id from clients c 
join orders o on o.client_id = c.id
order by c.id asc;

select c.fullname, m.name 
from menu m
join order_menu om on om.menu_id = m.id
join orders o on om.order_id = o.id
join clients c on o.client_id = c.id and m.compaund like 'M%';