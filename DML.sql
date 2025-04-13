insert into Roles(Nombre) values('Administrador'), ('Cliente'), ('Funcionario');

insert into Usuarios(Nombre,Apellido,CI,Celular,Email_Value,Password_Value,RolId)
values 
('Laura', 'Fernández', '4.123.456-7', '099123456', 'laura.fernandez@email.com', 'L@ura2025!', 1),
('Martín', 'Rodríguez', '5.234.567-8', '098765432', 'martin.rodriguez@email.com', 'M4rt1n#85', 1),
('Sofía', 'Pereira', '3.876.543-2', '091112233', 'sofia.pereira@email.com', 'S0fia*123', 1),
('Nicolás', 'Gómez', '4.567.890-1', '092334455', 'nicolas.gomez@email.com', 'N1c0las!99', 1),
('Camila', 'Torres', '3.456.789-0', '095667788', 'camila.torres@email.com', 'C@m1la2024', 1)

insert into Agencias(nombre, direccion, coordenada_latitud, coordenada_longitud)
values
('Agencia Central', 'Av. Principal 123, Ciudad Capital', '-34.9011', '-56.1645'),
('Agencia Norte', 'Calle 8 Nº456, Barrio Norte', '-34.8800', '-56.1400'),
('Agencia Sur', 'Ruta 5 Km 20, Zona Sur', '-34.9500', '-56.2000'),
('Agencia Este', 'Av. Costanera 789, Playa Este', '-34.9200', '-56.1200'),
('Agencia Oeste', 'Camino del Oeste 321, Monte Alto', '-34.9400', '-56.1800');
