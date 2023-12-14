create database Assignment6
use Assignment6

create table Products(
ProductId int primary key,
ProductName nvarchar(50),
Price float,
Quantity int,
MfDate date not null,
ExpDate date not null)

insert into Products VALUES (1,'Mobile',20000,5,'12/01/2023','07/07/2024')
insert into Products VALUES (2,'Laptop',65000,2,'01/06/2023','06/06/2024')
insert into Products VALUES (3,'TAB',40000,3,'09/24/2022','05/25/2024')
insert into Products VALUES (4,'Laptop',76000,3,'12/25/2023','06/25/2024')
insert into Products VALUES (5,'Mobile',35000,2,'06/22/2018','08/17/2023')

select * from Products