insert into Roles(Nombre) values('Administrador'), ('Cliente'), ('Funcionario');

INSERT INTO Usuarios (Nombre, Apellido, CI, Celular, Email_Value, Password_Value, RolId) VALUES
('María', 'Gómez', '4.321.987-1', '099123456', 'maria.gomez@email.com', 'passMaria1', 1), -- Administrador
('Jorge', 'Pérez', '3.654.789-2', '098765432', 'jorge.perez@email.com', 'passJorge1', 1), -- Administrador
('Lucía', 'Fernández', '2.987.654-3', '091234567', 'lucia.fernandez@email.com', 'passLucia1', 2), -- Cliente
('Carlos', 'Rodríguez', '1.234.567-4', '097654321', 'carlos.rodriguez@email.com', 'passCarlos1', 2), -- Cliente
('Sofía', 'Martínez', '5.678.901-5', '096543210', 'sofia.martinez@email.com', 'passSofia1', 2), -- Cliente
('Andrés', 'Díaz', '6.543.210-6', '095432109', 'andres.diaz@email.com', 'passAndres1', 2), -- Cliente
('Paula', 'López', '7.890.123-7', '094321098', 'paula.lopez@email.com', 'passPaula1', 2), -- Cliente
('Diego', 'Silva', '8.765.432-8', '093210987', 'diego.silva@email.com', 'passDiego1', 2), -- Cliente
('Natalia', 'Castro', '9.876.543-9', '092109876', 'natalia.castro@email.com', 'passNatalia1', 3), -- Funcionario
('Martin', 'Vega', '1.098.765-0', '091098765', 'martin.vega@email.com', 'passMartin1', 3); -- Funcionario


INSERT INTO Agencias (nombre, direccion, coordenada_latitud, coordenada_longitud) VALUES
('Agencia Centro Montevideo', 'Av. 18 de Julio 1234, Montevideo', -34.9059, -56.1914),
('Agencia Pocitos', 'Bulevar España 2501, Montevideo', -34.9137, -56.1551),
('Agencia Ciudad Vieja', 'Calle Sarandí 567, Montevideo', -34.9050, -56.2076),
('Agencia Tres Cruces', 'Av. Italia 1400, Montevideo', -34.8945, -56.1703),
('Agencia Maldonado', 'Av. Roosevelt 3000, Maldonado', -34.9105, -54.9527),
('Agencia Punta del Este', 'Gorlero 123, Punta del Este', -34.9647, -54.9459),
('Agencia Salto', 'Calle Uruguay 450, Salto', -31.3855, -57.9686),
('Agencia Paysandú', '18 de Julio 890, Paysandú', -32.3214, -58.0756),
('Agencia Rivera', 'Calle Sarandí 234, Rivera', -30.9057, -55.5508),
('Agencia Las Piedras', 'Av. Artigas 456, Las Piedras', -34.7301, -56.2209);

-- Tabla envio
INSERT INTO envio (NroTracking, EmpleadoId, ClienteId, Peso, Estado, FechaCreacion, FechaEntrega) VALUES
('a3d98baf-9b1e-4c90-987b-a1d1a7d2b101', 9, 3, 5.2, 0, '2025-05-01', '0001-01-01'),
('5f4a9e2b-d610-4d6b-8234-8b4de301dd22', 9, 4, 3.7, 0, '2025-05-02', '0001-01-01'),
('44ad17c6-5f60-4d53-927a-dc4e2e310f33', 9, 5, 1.8, 0, '2025-05-03', '0001-01-01'),
('f6cc94b0-fd9e-4dcb-899e-b78c0d55b244', 9, 6, 2.0, 0, '2025-05-04', '0001-01-01'),
('b89c387c-cc2d-4c36-a30f-3b49df3ae211', 9, 7, 4.4, 0, '2025-05-05', '0001-01-01'),
('d3b8c8b4-6b87-48f1-a321-3dbbabe4e632', 10, 8, 6.0, 0, '2025-05-06', '0001-01-01'),
('c2e2a44f-b69a-43f7-b23e-847bc3d79d94', 10, 3, 1.5, 0, '2025-05-07', '0001-01-01'),
('02e1e4ac-ff89-4b1f-99f3-2e527f7399e1', 10, 4, 2.9, 0, '2025-05-08', '0001-01-01'),
('bee7518e-6b41-4059-b9aa-bf97b48c7d22', 10, 5, 3.3, 0, '2025-05-09', '0001-01-01'),
('f9cb3ef5-d383-4d1b-bfae-111e36e60f99', 10, 6, 7.1, 0, '2025-05-10', '0001-01-01');

-- Tabla EnvioUrgente
INSERT INTO EnvioUrgente (Id, Direccion, EntregadoEficiente) VALUES
(1, 'Av. Libertador 1234, Montevideo', 1),
(2, 'Calle Principal 456, Salto', 0),
(3, 'Bulevar Artigas 789, Maldonado', 1),
(4, 'Camino Carrasco 234, Montevideo', 1),
(5, 'Ituzaingó 432, Paysandú', 0);

-- Tabla EnvioComun
INSERT INTO EnvioComun (Id, AgenciaDestinoId) VALUES
(6, 1),
(7, 3),
(8, 5),
(9, 7),
(10, 2);
