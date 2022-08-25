create database ControlInventario

use ControlInventario

create table MaeArticulos(
codigoArticulo int identity,
DescripcionArticulo varchar(30),
codigoTipo int,
precioArticulo money,
costoArticulo money,
cantidad int
constraint pk_codigoArt primary key(codigoArticulo),
constraint fk_codiTipo foreign key(codigoTipo) references TipoArticulo(codigoTipo)
)
select*from MaeArticulos
insert into MaeArticulos values('té',1,350,400,10)

create table TipoArticulo(
codigoTipo int identity,
descTipo varchar(30)
constraint pk_codigoTip primary key (codigoTipo),
)
select*from TipoArticulo

create table Usuarios(
codigoUsuario int identity,
nombreUsuario varchar(20),
claveUsuario varchar(20),
tipoUsuario int
constraint pk_codigoUser primary key(codigoUsuario),
constraint fk_tipoUser foreign key(tipoUsuario) references TipoUsuario(codTipoUser)
)
select *from Usuarios

create table TipoUsuario(
codTipoUser int identity,
descripTipoUser varchar(20)
constraint pk_tipoUser primary key(codTipoUser)
)
insert into TipoUsuario values ('Regular'),('Administrador')
select *from TipoUsuario

create table ArticulosBitacora(
codigoArticulo int,
DescripcionArticulo varchar(30),
codigoTipo int,
precioArticulo money,
costoArticulo money,
cantidad int,
Usuario varchar(20),
Fecha datetime,
Tipo varchar(10)
)

create trigger ControlArticulos_Bitacora
on MaeArticulos
After Insert, Delete
 as
  begin
   insert into ArticulosBitacora(codigoArticulo,DescripcionArticulo,codigoTipo,precioArticulo,costoArticulo,cantidad,Usuario,Fecha,Tipo)
   select i.codigoArticulo, i.DescripcionArticulo, i.codigoTipo, i.precioArticulo, i.costoArticulo, i.cantidad, 'Admin', GETDATE(), 'Ingreso' from inserted i
   union all
   select d.codigoArticulo, d.DescripcionArticulo, d.codigoTipo, d.precioArticulo, d.costoArticulo, d.cantidad, 'Admin', GETDATE(), 'Borrado' from deleted d
 end


 create procedure ReporteArticulos
 as 
  begin
   select a.codigoArticulo, a.DescripcionArticulo, t.descTipo, a.precioArticulo, a.costoArticulo, a.cantidad
   from MaeArticulos a
   inner join TipoArticulo t on t.codigoTipo = a.codigoTipo
  end


  create procedure IngresarArticulo
  @descArticulo varchar(30),
  @codigTipo int,
  @precArticulo money,
  @costArticulo money,
  @cant int
  as
   begin
   insert into MaeArticulos values (@descArticulo,@codigTipo,@precArticulo,@costArticulo,@cant)
   end
    
 create procedure BorrarArticulo
 @codArticulo int
 as
  begin
  delete MaeArticulos where codigoArticulo=@codArticulo
  end

 create procedure ActualizarArticulo
 @codArt int,
 @descArt varchar(30),
 @codTip int,
 @precioArt money,
 @costoArt money,
 @canti int
 as
  begin
  update MaeArticulos set DescripcionArticulo=@descArt, codigoTipo=@codTip,precioArticulo=@precioArt,costoArticulo=@costoArt,cantidad=@canti
  where codigoArticulo=@codArt
  end

  create procedure IngresarUsuario
  @nomUser varchar(20),
  @clavUser varchar(20),
  @tipUser int
  as
   begin
    insert into Usuarios values(@nomUser,@clavUser,@tipUser)
	end

 create procedure BorrarUsuario
 @codUser int
 as
  begin
  delete Usuarios where codigoUsuario=@codUser
  end

 create procedure ActualizarUsuario
 @codUser int,
 @nomUser varchar(20),
 @clavUser varchar(20),
 @tipUser int
 as
  begin
  update Usuarios set nombreUsuario=@nomUser,claveUsuario=@clavUser,tipoUsuario=@tipUser
  where codigoUsuario=@codUser
  end

  create procedure IngresarTipoArt
  @descTipo varchar(30)
  as
   begin
    insert into TipoArticulo values(@descTipo)
   end

  create procedure BorrarTipoArt
  @codTipo int
  as
   begin
   delete TipoArticulo where codigoTipo=@codTipo
   end

  create procedure ModificarTipoArt
  @codTipo int,
  @descTipo varchar(30)
  as
   begin 
   update TipoArticulo set descTipo=@descTipo
   where codigoTipo=@codTipo
   end


	select codigoArticulo, DescripcionArticulo, cantidad, precioArticulo,
	cantidad * precioArticulo as [Total ventas],
	cantidad * costoArticulo as [Total Costos],
	(cantidad * precioArticulo) - (cantidad * costoArticulo) as [Ganancias]
	from MaeArticulos

	 create procedure IniciarSesion
	 @username varchar(20),
	 @claveUser varchar(20),
	 @tipoUser int
	 as
	  begin
	  select nombreUsuario, claveUsuario, tipoUsuario from Usuarios where nombreUsuario=@username and claveUsuario=@claveUser and tipoUsuario=@tipoUser
	  end



  create procedure ListadoArticulos
  as
   begin
   select*from MaeArticulos
   end

  create procedure ListadoUsuarios
  as
   begin
   select*from Usuarios
   end

 create procedure ListadoTipoArt
 as 
  begin
  select*from TipoArticulo
  end

 create procedure ArtiAuditoria
 as 
  begin
  select*from ArticulosBitacora
  end