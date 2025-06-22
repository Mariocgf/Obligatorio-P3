insert into Roles(Nombre) values('Administrador'), ('Cliente'), ('Funcionario');

INSERT INTO Usuarios (Nombre, Apellido, CI, Celular, Email_Value, Password_Value, RolId) VALUES
('Mar�a', 'G�mez', '4.321.987-1', '099123456', 'maria.gomez@email.com', 'passMaria1', 1), -- Administrador
('Jorge', 'P�rez', '3.654.789-2', '098765432', 'jorge.perez@email.com', 'passJorge1', 1), -- Administrador
('Luc�a', 'Fern�ndez', '2.987.654-3', '091234567', 'lucia.fernandez@email.com', 'passLucia1', 2), -- Cliente
('Carlos', 'Rodr�guez', '1.234.567-4', '097654321', 'carlos.rodriguez@email.com', 'passCarlos1', 2), -- Cliente
('Sof�a', 'Mart�nez', '5.678.901-5', '096543210', 'sofia.martinez@email.com', 'passSofia1', 2), -- Cliente
('Andr�s', 'D�az', '6.543.210-6', '095432109', 'andres.diaz@email.com', 'passAndres1', 2), -- Cliente
('Paula', 'L�pez', '7.890.123-7', '094321098', 'paula.lopez@email.com', 'passPaula1', 2), -- Cliente
('Diego', 'Silva', '8.765.432-8', '093210987', 'diego.silva@email.com', 'passDiego1', 2), -- Cliente
('Natalia', 'Castro', '9.876.543-9', '092109876', 'natalia.castro@email.com', 'passNatalia1', 3), -- Funcionario
('Martin', 'Vega', '1.098.765-0', '091098765', 'martin.vega@email.com', 'passMartin1', 3); -- Funcionario


INSERT INTO Agencias (nombre, direccion, coordenada_latitud, coordenada_longitud) VALUES
('Agencia Centro Montevideo', 'Av. 18 de Julio 1234, Montevideo', -34.9059, -56.1914),
('Agencia Pocitos', 'Bulevar Espa�a 2501, Montevideo', -34.9137, -56.1551),
('Agencia Ciudad Vieja', 'Calle Sarand� 567, Montevideo', -34.9050, -56.2076),
('Agencia Tres Cruces', 'Av. Italia 1400, Montevideo', -34.8945, -56.1703),
('Agencia Maldonado', 'Av. Roosevelt 3000, Maldonado', -34.9105, -54.9527),
('Agencia Punta del Este', 'Gorlero 123, Punta del Este', -34.9647, -54.9459),
('Agencia Salto', 'Calle Uruguay 450, Salto', -31.3855, -57.9686),
('Agencia Paysand�', '18 de Julio 890, Paysand�', -32.3214, -58.0756),
('Agencia Rivera', 'Calle Sarand� 234, Rivera', -30.9057, -55.5508),
('Agencia Las Piedras', 'Av. Artigas 456, Las Piedras', -34.7301, -56.2209);

-- Tabla envio
INSERT INTO envio (NroTracking, EmpleadoId, ClienteId, Peso, Estado, FechaCreacion, FechaEntrega) VALUES
('a3d98baf', 9, 3, 5.2, 0, '2025-05-01', '0001-01-01'),
('5f4a9e2b', 9, 4, 3.7, 0, '2025-05-02', '0001-01-01'),
('44ad17c6', 9, 5, 1.8, 0, '2025-05-03', '0001-01-01'),
('f6cc94b0', 9, 6, 2.0, 0, '2025-05-04', '0001-01-01'),
('b89c387c', 9, 7, 4.4, 0, '2025-05-05', '0001-01-01'),
('d3b8c8b4', 10, 8, 6.0, 0, '2025-05-06', '0001-01-01'),
('c2e2a44f', 10, 3, 1.5, 0, '2025-05-07', '0001-01-01'),
('02e1e4ac', 10, 4, 2.9, 0, '2025-05-08', '0001-01-01'),
('bee7518e', 10, 5, 3.3, 0, '2025-05-09', '0001-01-01'),
('f9cb3ef5', 10, 6, 7.1, 0, '2025-05-10', '0001-01-01');

-- Tabla EnvioUrgente
INSERT INTO EnvioUrgente (Id, Direccion, EntregadoEficiente) VALUES
(1, 'Av. Libertador 1234, Montevideo', 1),
(2, 'Calle Principal 456, Salto', 0),
(3, 'Bulevar Artigas 789, Maldonado', 1),
(4, 'Camino Carrasco 234, Montevideo', 1),
(5, 'Ituzaing� 432, Paysand�', 0);

-- Tabla EnvioComun
INSERT INTO EnvioComun (Id, AgenciaDestinoId) VALUES
(6, 1),
(7, 3),
(8, 5),
(9, 7),
(10, 2);

INSERT INTO Seguimiento (Comentario, EmpleadoId, Fecha, EnvioId) VALUES
('Paquete recibido en la agencia. En proceso de clasificación.', 9, '2025-05-01', 1),
('El paquete fue cargado en el camión de reparto.', 9, '2025-05-02', 1),

('Retraso por condiciones climáticas. Reprogramando entrega.', 9, '2025-05-02', 2),

('Producto embalado correctamente. Esperando despacho.', 10, '2025-05-03', 3),
('Cliente consultó por el estado del paquete.', 10, '2025-05-04', 3),

('El paquete fue entregado al cliente sin inconvenientes.', 10, '2025-05-04', 4),

('Verificación adicional por peso excesivo.', 9, '2025-05-05', 5),

('Paquete en tránsito hacia la agencia de destino.', 9, '2025-05-06', 6),
('Demora por alta demanda en agencia destino.', 10, '2025-05-07', 6),

('Cliente solicitó cambio de dirección de entrega.', 10, '2025-05-08', 7),

('Entregado en agencia central, esperando retiro del cliente.', 9, '2025-05-08', 8),

('Paquete dañado durante el envío. Informado al supervisor.', 10, '2025-05-09', 10);
