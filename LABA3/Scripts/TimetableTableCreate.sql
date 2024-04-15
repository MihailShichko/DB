create table Timetable(
	ID serial primary key, 
	Day integer check(Day >= 0 AND Day <= 7),
	Dayout bool,
	StartTime time not null,
    EndTime time not null
);