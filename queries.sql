SET IDENTITY_INSERT dbo.Usuarios OFF
SET IDENTITY_INSERT dbo.Necesidades ON

/*INSERT INTO dbo.Usuarios (idUsuario, Nombre, Apellido, FechaNacimiento, UserName, Email, Password, Foto, TipoUsuario, FechaCracion, Activo, Token)
VALUES (2, null, null, 1986-12-30, null, 'pepe@gmail.com', 1234, null, 1, 2020-01-01, 1, 'q1w2e3r4');*/

/*INSERT INTO dbo.Necesidades (IdNecesidad, Nombre, Descripcion, FechaCreacion, FechaFin, TelefonoContacto, TipoDonacion, Foto, IdUsuarioCreador, Estado, Valoracion) 
VALUES (2, 'Coronavirus', 'Corona', 2020-01-01, 2020-02-02, 3333, 1, 'mifoto.jpg', 2, 1, 5);*/

select * from dbo.Usuarios;
select * from dbo.Necesidades;
select * from dbo.NecesidadesDonacionesInsumos;
select * from dbo.DonacionesInsumos;
select * from dbo.NecesidadesReferencias;