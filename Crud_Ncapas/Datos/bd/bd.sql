use prueba

create sequence id_producto
as smallint
start with 1
increment by 1
no cycle
no cache
go

create table producto(
id varchar(45) not null primary key default 'pro'+right('00'+cast(next value for id_producto as varchar),3),
descripcion varchar(45) not null
)
go
insert into producto (descripcion) values('martillo');
go
create procedure usp_List_producto
as
begin
	select * from producto
end
go
create procedure usp_Add_producto
(
@descripcion varchar(45)
)
as
begin
	insert into producto (descripcion)
	values (@descripcion)
end
go
create procedure Update_producto
(
@codigo varchar(45),
@descripcion varchar(45)
)
as
begin
	Update producto set descripcion=@descripcion
	where id=@codigo
end
go
create procedure Delete_producto
(
@codigo varchar(45)
)
as
begin
	delete producto
	where id=@codigo
end
go
