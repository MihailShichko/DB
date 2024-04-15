create table Order_Coock(
	PasportNum integer references coocks(ID),
	OrderNum integer references orders(ID),
	Status integer check (Status >=0),
	primary key (PasportNum, OrderNum)
);