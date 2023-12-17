NOTA---------------------------------------------------------------------------------------------

- Ejecutar script.Sql para crear la base de datos que consume la app.
- Cambiar la cadena de conexión en la clase CD_Conexión (Si se ejectuo el scrip.Sql debería bastar con cambiar la parte del DataSource).


USUARIOS----------------------------------------------------------------------------------------

Usuario Administrador: 
- usuario : Admin1
- Contraseña : 123abc

Usuario de ventas: 
- usuario : ventas1
- Contraseña : v321

QUERY PARA DESENCRIPTAR LA CONTRASEÑA DE UN USUARIO---------------------------------------------------------

-Debe reemplazar el texto XXXXX por el USUARIO en el siguiente query:

SELECT (Convert (Varchar(50),DECRYPTBYPASSPHRASE('FAMC',Contrasena))) FROM Usuarios WHERE Usuario='XXXXX'