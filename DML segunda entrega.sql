insert into Roles(Nombre) values('Cliente'), ('Funcionario'), ('Administrador');

INSERT INTO Usuarios (Nombre, Apellido, CI, Celular, Email_Value, Password_Value, RolId) VALUES
-- Funcionarios
('Sofía',     'Pérez',      '52435698', '099123456', 'sofia.perez@example.com',     'P@sSw0rd1', 2),
('Matías',    'Silva',      '45981234', '098765432', 'matias.silva@example.com',    'S3cure#2',  2),
('Camila',    'González',   '31876549', '091234567', 'camila.gonzalez@example.com', 'F*nc10na3', 2),
('Lucas',     'Fernández',  '27893465', '094567890', 'lucas.fernandez@example.com', 'Fus#2025',  2),
('Valentina', 'Díaz',       '40238765', '092345678', 'valentina.diaz@example.com',  'FnC!2024',  2),

-- Clientes
('Diego',     'Torres',     '54432109', '093456789', 'diego.torres@example.com',    'Cl1ente#1', 1),
('Isabella',  'Martínez',   '38765412', '097654321', 'isabella.martinez@example.com','Cl1ente#2', 1),
('Bruno',     'Suárez',     '21347895', '090987654', 'bruno.suarez@example.com',     'Cl1ente#3', 1),
('Florencia', 'López',      '47653218', '096543210', 'florencia.lopez@example.com',  'Cl1ente#4', 1),
('Agustín',   'Ramos',      '36542187', '095432109', 'agustin.ramos@example.com',    'Cl1ente#5', 1);

INSERT INTO Agencias (nombre, direccion, coordenada_latitud, coordenada_longitud) VALUES
('Agencia Centro Montevideo', 'Av. 18 de Julio 1234, Montevideo', -34.9059, -56.1914),
('Agencia Pocitos', 'Bulevar Espana 2501, Montevideo', -34.9137, -56.1551),
('Agencia Ciudad Vieja', 'Calle Sarandi 567, Montevideo', -34.9050, -56.2076),
('Agencia Tres Cruces', 'Av. Italia 1400, Montevideo', -34.8945, -56.1703),
('Agencia Maldonado', 'Av. Roosevelt 3000, Maldonado', -34.9105, -54.9527),
('Agencia Punta del Este', 'Gorlero 123, Punta del Este', -34.9647, -54.9459),
('Agencia Salto', 'Calle Uruguay 450, Salto', -31.3855, -57.9686),
('Agencia Paysandu', '18 de Julio 890, Paysandu', -32.3214, -58.0756),
('Agencia Rivera', 'Calle Sarandi 234, Rivera', -30.9057, -55.5508),
('Agencia Las Piedras', 'Av. Artigas 456, Las Piedras', -34.7301, -56.2209);

INSERT INTO envio
    (NroTracking, EmpleadoId, ClienteId, Peso, Estado, FechaCreacion, FechaEntrega)
VALUES
-- Diego Torres  (ClienteId = 6)
('TRK20250610001', 1, 6, 2.5, 1, '2025-06-10', '2025-06-14'),
('TRK20250615002', 3, 6, 1.2, 1, '2025-06-15', '2025-06-19'),
('TRK20250620003', 2, 6, 3.7, 0, '2025-06-20', '0001-01-01'),
('TRK20250623004', 5, 6, 0.9, 0, '2025-06-23', '0001-01-01'),

-- Isabella Martínez  (ClienteId = 7)
('TRK20250609005', 4, 7, 4.1, 1, '2025-06-09', '2025-06-12'),
('TRK20250612006', 1, 7, 2.0, 1, '2025-06-12', '2025-06-17'),
('TRK20250620007', 2, 7, 1.6, 0, '2025-06-20', '0001-01-01'),
('TRK20250623008', 3, 7, 3.4, 0, '2025-06-23', '0001-01-01'),

-- Bruno Suárez  (ClienteId = 8)
('TRK20250608009', 5, 8, 5.5, 1, '2025-06-08', '2025-06-13'),
('TRK20250613010', 2, 8, 2.8, 1, '2025-06-13', '2025-06-18'),
('TRK20250619011', 3, 8, 1.1, 0, '2025-06-19', '0001-01-01'),
('TRK20250621012', 4, 8, 0.7, 0, '2025-06-21', '0001-01-01'),

-- Florencia López  (ClienteId = 9)
('TRK20250607013', 1, 9, 2.3, 1, '2025-06-07', '2025-06-11'),
('TRK20250611014', 5, 9, 4.0, 1, '2025-06-11', '2025-06-15'),
('TRK20250620015', 4, 9, 1.9, 0, '2025-06-20', '0001-01-01'),
('TRK20250622016', 2, 9, 3.3, 0, '2025-06-22', '0001-01-01'),

-- Agustín Ramos  (ClienteId = 10)
('TRK20250606017', 3, 10, 3.7, 1, '2025-06-06', '2025-06-10'),
('TRK20250614018', 4, 10, 0.8, 1, '2025-06-14', '2025-06-18'),
('TRK20250620019', 5, 10, 2.6, 0, '2025-06-20', '0001-01-01'),
('TRK20250623020', 1, 10, 1.0, 0, '2025-06-23', '0001-01-01');

/* ----------  Envíos urgentes  (Estado = 0) ---------- */
INSERT INTO EnvioUrgente (Id, Direccion, EntregadoEficiente) VALUES
(3 , 'Calle Libertad 1010, Montevideo'     , 0),
(4 , 'Calle Colonia 1234, Montevideo'      , 0),
(7 , 'Av. Rivera 4567, Montevideo'         , 0),
(8 , 'Av. Brasil 1500, Montevideo'         , 0),
(11, 'Camino Carrasco 890, Canelones'      , 0),
(12, 'Av. Kennedy 330, Punta del Este'     , 0),
(15, 'Calle Sarandí 678, Montevideo'       , 0),
(16, 'Av. Italia 2400, Montevideo'         , 0),
(19, 'Av. Roosevelt 3700, Maldonado'       , 0),
(20, 'Calle Uruguay 512, Salto'            , 0);

/* ----------  Envíos comunes  (Estado = 1) ---------- */
INSERT INTO EnvioComun (Id, AgenciaDestinoId) VALUES
(1 , 4),  -- Agencia Tres Cruces
(2 , 1),  -- Agencia Centro Montevideo
(5 , 2),  -- Agencia Pocitos
(6 , 7),  -- Agencia Salto
(9 , 9),  -- Agencia Rivera
(10, 3),  -- Agencia Ciudad Vieja
(13, 5),  -- Agencia Maldonado
(14, 10), -- Agencia Las Piedras
(17, 6),  -- Agencia Punta del Este
(18, 8);  -- Agencia Paysandú


INSERT INTO Seguimiento (Comentario, EmpleadoId, Fecha, EnvioId) VALUES
/* ---------- Envíos comunes (Estado = 1) ---------- */
/* Envío 1 */
('Se generó el envío',                       1, '2025-06-10 09:05',  1),
('Recibido en centro de distribución',       1, '2025-06-10 14:20',  1),
('Despachado hacia agencia destino',         1, '2025-06-11 08:50',  1),
('Llegó a agencia destino',                  1, '2025-06-13 10:15',  1),
('Retirado por cliente',                     1, '2025-06-14 11:30',  1),

/* Envío 2 */
('Se generó el envío',                       3, '2025-06-15 10:12',  2),
('Recibido en centro de distribución',       3, '2025-06-15 15:00',  2),
('Despachado hacia agencia destino',         3, '2025-06-16 09:00',  2),
('Llegó a agencia destino',                  3, '2025-06-18 09:45',  2),
('Retirado por cliente',                     3, '2025-06-19 16:45',  2),

/* Envío 5 */
('Se generó el envío',                       4, '2025-06-09 07:45',  5),
('Recibido en centro de distribución',       4, '2025-06-09 13:30',  5),
('Despachado hacia agencia destino',         4, '2025-06-10 08:10',  5),
('Llegó a agencia destino',                  4, '2025-06-11 09:50',  5),
('Retirado por cliente',                     4, '2025-06-12 14:10',  5),

/* Envío 6 */
('Se generó el envío',                       1, '2025-06-12 11:00',  6),
('Recibido en centro de distribución',       1, '2025-06-12 15:25',  6),
('Despachado hacia agencia destino',         1, '2025-06-13 08:40',  6),
('Llegó a agencia destino',                  1, '2025-06-16 11:15',  6),
('Retirado por cliente',                     1, '2025-06-17 12:55',  6),

/* Envío 9 */
('Se generó el envío',                       5, '2025-06-08 08:20',  9),
('Recibido en centro de distribución',       5, '2025-06-08 13:10',  9),
('Despachado hacia agencia destino',         5, '2025-06-09 09:05',  9),
('Llegó a agencia destino',                  5, '2025-06-12 10:25',  9),
('Retirado por cliente',                     5, '2025-06-13 15:40',  9),

/* Envío 10 */
('Se generó el envío',                       2, '2025-06-13 10:18', 10),
('Recibido en centro de distribución',       2, '2025-06-13 14:45', 10),
('Despachado hacia agencia destino',         2, '2025-06-14 09:20', 10),
('Llegó a agencia destino',                  2, '2025-06-17 10:30', 10),
('Retirado por cliente',                     2, '2025-06-18 13:00', 10),

/* Envío 13 */
('Se generó el envío',                       1, '2025-06-07 07:50', 13),
('Recibido en centro de distribución',       1, '2025-06-07 12:35', 13),
('Despachado hacia agencia destino',         1, '2025-06-08 08:15', 13),
('Llegó a agencia destino',                  1, '2025-06-10 09:40', 13),
('Retirado por cliente',                     1, '2025-06-11 13:15', 13),

/* Envío 14 */
('Se generó el envío',                       5, '2025-06-11 08:10', 14),
('Recibido en centro de distribución',       5, '2025-06-11 12:45', 14),
('Despachado hacia agencia destino',         5, '2025-06-12 08:55', 14),
('Llegó a agencia destino',                  5, '2025-06-14 10:20', 14),
('Retirado por cliente',                     5, '2025-06-15 12:00', 14),

/* Envío 17 */
('Se generó el envío',                       3, '2025-06-06 08:30', 17),
('Recibido en centro de distribución',       3, '2025-06-06 13:05', 17),
('Despachado hacia agencia destino',         3, '2025-06-07 09:00', 17),
('Llegó a agencia destino',                  3, '2025-06-09 10:40', 17),
('Retirado por cliente',                     3, '2025-06-10 14:05', 17),

/* Envío 18 */
('Se generó el envío',                       4, '2025-06-14 10:25', 18),
('Recibido en centro de distribución',       4, '2025-06-14 15:15', 18),
('Despachado hacia agencia destino',         4, '2025-06-15 08:30', 18),
('Llegó a agencia destino',                  4, '2025-06-17 11:10', 18),
('Retirado por cliente',                     4, '2025-06-18 13:18', 18),

/* ---------- Envíos urgentes en proceso (Estado = 0) ---------- */
/* Envío 3 */
('Se generó el envío',                       2, '2025-06-20 08:50',  3),
('Clasificación urgente completada',         2, '2025-06-20 09:15',  3),
('En tránsito hacia destino',                2, '2025-06-20 18:00',  3),
('Llegó a zona de entrega',                  2, '2025-06-21 10:20',  3),
('Intento de entrega programado',            2, '2025-06-22 10:20',  3),

/* Envío 4 */
('Se generó el envío',                       5, '2025-06-23 09:30',  4),
('Clasificado como urgente',                 5, '2025-06-23 10:00',  4),
('En tránsito hacia destino',                5, '2025-06-23 18:30',  4),
('Llegó a zona de entrega',                  5, '2025-06-24 08:20',  4),
('Intento de entrega reprogramado',          5, '2025-06-24 18:00',  4),

/* Envío 7 */
('Se generó el envío',                       2, '2025-06-20 09:10',  7),
('Clasificado como urgente',                 2, '2025-06-20 09:40',  7),
('En tránsito hacia destino',                2, '2025-06-20 17:55',  7),
('En punto de distribución local',           2, '2025-06-21 11:25',  7),
('Intento de entrega programado',            2, '2025-06-23 08:35',  7),

/* Envío 8 */
('Se generó el envío',                       3, '2025-06-23 10:05',  8),
('Clasificación urgente completada',         3, '2025-06-23 10:30',  8),
('En tránsito hacia destino',                3, '2025-06-23 19:10',  8),
('En punto de distribución local',           3, '2025-06-24 09:15',  8),
('Intento de entrega programado',            3, '2025-06-26 09:25',  8),

/* Envío 11 */
('Se generó el envío',                       3, '2025-06-19 08:55', 11),
('Clasificado como urgente',                 3, '2025-06-19 09:30', 11),
('En tránsito hacia destino',                3, '2025-06-19 18:10', 11),
('En zona de entrega',                       3, '2025-06-20 10:15', 11),
('Intento de entrega reprogramado',          3, '2025-06-21 10:45', 11),

/* Envío 12 */
('Se generó el envío',                       4, '2025-06-21 09:35', 12),
('Clasificado como urgente',                 4, '2025-06-21 10:05', 12),
('En tránsito hacia destino',                4, '2025-06-21 19:20', 12),
('En punto de distribución local',           4, '2025-06-22 11:05', 12),
('Intento de entrega programado',            4, '2025-06-23 11:22', 12),

/* Envío 15 */
('Se generó el envío',                       4, '2025-06-20 09:05', 15),
('Clasificación urgente completada',         4, '2025-06-20 09:35', 15),
('En tránsito hacia destino',                4, '2025-06-20 18:05', 15),
('En zona de entrega',                       4, '2025-06-21 12:10', 15),
('Intento de entrega reprogramado',          4, '2025-06-22 09:58', 15),

/* Envío 16 */
('Se generó el envío',                       2, '2025-06-22 09:12', 16),
('Clasificado como urgente',                 2, '2025-06-22 09:45', 16),
('En tránsito hacia destino',                2, '2025-06-22 17:30', 16),
('En punto de distribución local',           2, '2025-06-23 10:10', 16),
('Intento de entrega programado',            2, '2025-06-24 10:20', 16),

/* Envío 19 */
('Se generó el envío',                       5, '2025-06-20 07:59', 19),
('Clasificación urgente completada',         5, '2025-06-20 08:25', 19),
('En tránsito hacia destino',                5, '2025-06-20 17:40', 19),
('En zona de entrega',                       5, '2025-06-22 09:35', 19),
('Intento de entrega programado',            5, '2025-06-23 11:40', 19),

/* Envío 20 */
('Se generó el envío',                       1, '2025-06-23 09:27', 20),
('Clasificado como urgente',                 1, '2025-06-23 09:55', 20),
('En tránsito hacia destino',                1, '2025-06-23 19:25', 20),
('En punto de distribución local',           1, '2025-06-24 11:20', 20),
('Intento de entrega reprogramado',          1, '2025-06-26 10:55', 20);
