#drop database CLINICA1;

create database CLINICA1;
use CLINICA1;

#USUARIOS Y PRIVILEGIOS

#GRANT ALL PRIVILEGES ON clinica TO 'root'@'localhost' IDENTIFIED BY 'Sebas1234' ;

create table TIPO_USUARIO(
id_tipo_usuario varchar(15) primary key not null,
nombre_tipo_usuario varchar(30) not null

)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into tipo_usuario values ("1", "Admin");

create table USUARIOS(
id_usuario varchar(15) primary key not null,
id_tipo_usuario varchar(15) not null,
nombre_usuario varchar(30) not null,
passwd_usuario varchar(15) not null,
estado_usuario varchar(1) not null,
foreign key (id_tipo_usuario) references TIPO_USUARIO(id_tipo_usuario)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into usuarios values ("1", "1", "Mel", "MelYJustin4evah", "1");
insert into usuarios values ("2", "1", "Sebas", "SebasYMel2021", "1");

select * from usuarios;
#FORMAS DE PAGO Y RELACIONADOS



/*
create table BANCOS(
id_banco varchar(15) primary key,
nombre_banco varchar(30) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
*/
/*create table CUENTA_BANCARIA(
id_cuenta varchar(15) primary key,
nombre_cuenta varchar(30) not null,
num_cuenta varchar(30) not null,
id_banco varchar(15),
id_moneda varchar(15),
saldo_cuenta float not null,

foreign key (id_banco) references BANCOS(id_banco),
foreign key (id_moneda) references MONEDA(id_moneda)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
*/

create table ASEGURADORAS(
id_aseguradora varchar(15) primary key not null,
nombre_aseguradora varchar(30) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table DESCUENTOS_ASEGURADORAS(
id_descuento varchar(15) primary key not null,
nombre_descuento varchar(30) not null,
descuento float not null,
id_aseguradora varchar(15),

foreign key (id_aseguradora) references ASEGURADORAS(id_aseguradora)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

#GESTION CLINICA Y ADMINISTRATIVA
create table BITACORA(
id_bitacora varchar(15) primary key not null,
id_usuario varchar(15) not null,
descripcion_bitacora varchar(50),
fecha_bitacora date not null,
hora_bitacora time not null,
ip_bitacora varchar(30) not null,

foreign key (id_usuario) references USUARIOS(id_usuario)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table SEDE (
id_sede varchar(15) not null primary key,
nombre_sede varchar(30) not null,
direccion varchar(30) not null,
telefono varchar(15) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into sede values ('1', 'Portales', 'ZonaPortales', '25262422');
insert into sede values ('2', 'VillaNueva', 'Villa Nueva', '25262422');
insert into sede values ('3', 'SanKris', 'San Cristobal', '25262422');

create table PUESTO(
id_puesto varchar(15) primary key not null,
nombre_puesto varchar(15) not null,
status_puesto varchar(1)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into puesto values ("1" , "Jefe", "1");
insert into puesto values ("2" , "Gerente", "1");
insert into puesto values ("3" , "Conserje", "1");

select id_puesto from puesto where nombre_puesto = 'Jefe';

create table PACIENTE(
id_paciente varchar(15) not null,
cui_paciente varchar(30) not null,
nit_paciente varchar(10) not null,
nombre_paciente varchar(30) not null,
apellido_paciente varchar(30) not null,
genero_paciente varchar(1) not null,
edad_paciente int not null,
telefono_paciente varchar(15) not null,
direccion_paciente varchar(50) not null,
email_paciente varchar(50) not null,
status_paciente varchar(1) not null,
seguro_paciente varchar(30) not null,
primary key (id_paciente, nit_paciente)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into clinica1.paciente values ('1', '3003999650101', '2018658-4', 'Meredid', 'Blake', 'F', '21', '58595653', 'Ciudad', 'mblake@gmail.com', '1', '789');
insert into clinica1.paciente values ('2', '3003997898655', '2089698-7', 'Mario', 'Bros', 'M', '29', '5963565', 'Ciudad', 'mbros@gmail.com', '1', '7895');
insert into clinica1.paciente values ('3', '3004856582254', '2896994-8', 'Bad', 'Bunny', 'M', '33', '47859912', 'Ciudad', 'benito@gmail.com', '1', '653');
select * from paciente;	

create table EMPLEADO(
id_empleado varchar(15) primary key not null,
cui_empleado varchar(30) not null,
nit_empleado varchar(10) not null,
nombre_empleado varchar(30) not null,
apellido_empleado varchar(30) not null,
genero_empleado varchar(1) not null,
edad_empleado int not null,
telefono_empleado varchar(15) not null,
direccion_empleado varchar(50) not null,
email_empleado varchar(50) not null,
status_empleado varchar(1) not null,
id_puesto varchar(15) not null,
colegiado_empleado varchar(15) not null,
id_sede varchar(15) not null,
foreign key (id_puesto) references PUESTO(id_puesto),
foreign key (id_sede) references SEDE(id_sede)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into empleado (id_empleado, cui_empleado, nit_empleado, nombre_empleado, apellido_empleado, 
genero_empleado, edad_empleado, telefono_empleado, direccion_empleado, email_empleado, status_empleado, id_puesto, colegiado_empleado, id_sede)
 VALUES ('1', '3003888450101', '2017258-3', 'Sebas', 'Moreira', 'M', 21, '48125651', 'Ciudad', 'sebas@gmail.com', '1', '1', '8485', '1' );
 
select * from empleado;

create table REQUERIMIENTOS_CLINICOS(
id_requerimiento_clinico varchar(15) primary key not null,
descripcion_requerimiento_clinico varchar(100) not null, 
cantidad int not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

select * from REQUERIMIENTOS_CLINICOS;

create table REQUERIMIENTOS_PACIENTE(
id_requerimiento_paciente varchar(15) primary key not null,
descripcion_requerimiento_paciente varchar(100) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into REQUERIMIENTOS_PACIENTE values ("1" , "12 HORAS DE AYUNO, ULTIMA COMIDA HAYA SIDO LIVIANA");
insert into REQUERIMIENTOS_PACIENTE values ("2" , "DESAYUNAR Y DESPUES REGRESAR POR EL EXAMEN");
insert into REQUERIMIENTOS_PACIENTE values ("3" , "TOMAR LA PRIMERA MUESTRA DE LA MAÑANA EN FRASCO ESTÉRIL");
insert into REQUERIMIENTOS_PACIENTE values ("4" , "PRIMERA ORINA DE LA MAÑANA CON TECNICA MEDIO VUELO EN FRASCO ESTERIL");
select * from REQUERIMIENTOS_PACIENTE;

create table TIPO_EXAMEN(
id_tipo_examen varchar(15) primary key not null,
nombre_tipo_examen varchar(30) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
insert into tipo_examen values ("1", "Hematología");
insert into tipo_examen values ("2", "Heces");
insert into tipo_examen values ("3", "Orina");
insert into tipo_examen values ("4", "Glucosa");
insert into tipo_examen values ("5", "MRA (Resonancia Magnética");

create table EXAMEN(
id_examen varchar(15) primary key not null,
nombre_examen varchar(30) not null,
id_tipo_examen varchar(15) not null,
id_requerimiento_paciente varchar(15) not null,
precio_examen float not null,

foreign key (id_tipo_examen) references TIPO_EXAMEN(id_tipo_examen),
foreign key (id_requerimiento_paciente) references REQUERIMIENTOS_PACIENTE(id_requerimiento_paciente)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into EXAMEN values ("1", "Sangre", "1", "1", "50");
insert into EXAMEN values ("2", "Triglicéridos", "1", "1", "35");
insert into EXAMEN values ("3", "Colésterol", "1", "1", "40");

insert into EXAMEN values ("4", "Heces", "2", "3", "50");
insert into EXAMEN values ("5", "Coprocultivo", "2", "3", "75");

insert into EXAMEN values ("6", "Urocultivo", "3", "4", "80");
insert into EXAMEN values ("7", "Creatinina", "3", "4", "50");
insert into EXAMEN values ("14", "Orina Simple", "3", "4", "40");

insert into EXAMEN values ("8", "Glucosa Preprandial", "4", "1", "35");
insert into EXAMEN values ("9", "Glucosa Postprandial", "4", "2", "35");
insert into EXAMEN values ("10", "Glicosilada", "4", "1", "60");

insert into EXAMEN values ("11", "MRA Cervical", "5", "2", "500");
insert into EXAMEN values ("12", "MRA de tórax", "5", "2", "500");
insert into EXAMEN values ("13", "MRA de cabeza", "5", "2", "500");

select * from examen;

create table PAQUETE_ENCABEZADO(
id_paquete varchar(15) primary key not null,
nombre_paquete varchar(30) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

insert into PAQUETE_ENCABEZADO values ( "1", "Renal");
insert into PAQUETE_ENCABEZADO values ( "2", "Preoperatorio");
insert into PAQUETE_ENCABEZADO values ( "3", "Lipidos");

create table PAQUETE_DETALLE(
id_detalle varchar(15) primary key not null,
id_paquete_encabezado varchar(15) not null,
id_paquete varchar(15) not null,
id_tipo_examen varchar(15) not null,
id_examen varchar(30) not null,

foreign key (id_paquete) references PAQUETE_ENCABEZADO(id_paquete),
foreign key (id_examen) references EXAMEN(id_examen), 
foreign key (id_tipo_examen) references TIPO_EXAMEN(id_tipo_examen)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table CITAS(
id_cita varchar(15) primary key not null,
id_paciente varchar(15) not null,
id_empleado varchar(15) not null,
fecha_cita date not null,
descripcion varchar(150) not null,
status_cita varchar(1) not null,

foreign key (id_paciente) references PACIENTE(id_paciente),
foreign key (id_empleado) references EMPLEADO(id_empleado)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table TIPO_MUESTRA(
id_tipo_muestra varchar(15) primary key not null,
nombre_tipo_muestra varchar(30) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table MUESTRAS(
id_muestra varchar(15) primary key not null,
id_paciente varchar(15) not null,
id_tipo_muestra varchar(15) not null,
fecha_muestra date not null,
hora_muestra time not null,

foreign key (id_paciente) references PACIENTE(id_paciente),
foreign key (id_tipo_muestra) references TIPO_MUESTRA(id_tipo_muestra)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table ETIQUETAS(
id_etiqueta varchar(15) primary key not null,
id_muestra varchar(15) not null,
nombre_paciente varchar(30) not null,
tipo_muestra varchar(15) not null,
foreign key (id_muestra) references MUESTRAS(id_muestra)

)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table ENCABEZADO_FACTURA(
id_encabezado_factura varchar(15) primary key not null,
id_paciente varchar(15) not null,
id_empleado varchar(15) not null,
fecha_factura date not null,
hora_factura time not null,
total_factura float not null,
foreign key (id_paciente) references PACIENTE(id_paciente),
foreign key (id_empleado) references EMPLEADO(id_empleado)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table DETALLE_FACTURA(
id_detalle_factura varchar(15) primary key not null,
id_encabezado_factura varchar(15) not null,
descripcion varchar(15) not null,
precio float not null,

foreign key (id_encabezado_factura) references ENCABEZADO_FACTURA(id_encabezado_factura)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


create table ENCABEZADO_EXPEDIENTE(
id_encabezado_expediente varchar(15) primary key not null,
id_paciente varchar(15) not null,

foreign key (id_paciente) references PACIENTE(id_paciente)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table DETALLE_EXPEDIENTE(
id_detalle_expediente varchar(15) primary key not null,
id_encabezado_expediente varchar(15) not null,
fecha_expediente date not null,
hora_expediente time not null,
descripcion_resultados varchar(200) not null,

foreign key (id_encabezado_expediente) references ENCABEZADO_EXPEDIENTE(id_encabezado_expediente),
foreign key (descripcion_resultados) references DETALLE_FACTURA(id_detalle_factura)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table COTIZACION(
id_cotizacion int auto_increment primary key not null,
id_paciente varchar(15) not null,
fecha_cotizacion date not null,
id_paquete varchar(15),
id_tipo_examen varchar(15),
nombre_examen varchar(30),
precio float not null,

foreign key (id_paciente) references PACIENTE(id_paciente)

)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

select * from cotizacion;

#eliminar carrito y poner solo detalle cotizacion
/*
create table DETALLE_COTIZACION(
id_detalle_cotizacion varchar(15) primary key not null,
id_encabezado_cotizacion varchar(15) not null,
id_paquete varchar(15),
id_examen varchar(15) null,
total_cotizacion float not null,

foreign key (id_encabezado_cotizacion) references ENCABEZADO_COTIZACION(id_encabezado_cotizacion),
foreign key (id_examen) references EXAMEN(id_examen),
foreign key (id_paquete) references PAQUETE_ENCABEZADO(id_paquete)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;*/

create table CAJA(
id_caja varchar(15) primary key not null,
nombre_caja varchar(30) not null,
saldo_caja float not null,
id_empleado varchar(30) not null,

foreign key (id_empleado) references EMPLEADO(id_empleado)

)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


create table MONEDA(
id_moneda varchar(15) primary key not null,
id_factura varchar(15) not null,
nombre_moneda varchar(30) not null,
tipo_cambio float not null,
status_moneda varchar(1),

foreign key (id_factura) references ENCABEZADO_FACTURA(id_encabezado_factura)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

#INDICES
create table FORMAS_PAGO(
id_forma_pago varchar(15) primary key not null,
nombre_forma_pago varchar(30) not null,
status_forma_pago varchar(1) not null
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table HISTORIAL_PAGOS(
id_historial varchar(15) primary key not null,
id_paciente varchar(15) not null,
id_forma_pago varchar(15) not null,
id_fecha date not null,
id_hora time not null,
monto float not null,

foreign key (id_paciente) references PACIENTE(id_paciente),
foreign key (id_forma_pago) references FORMAS_PAGO(id_forma_pago)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

create table CREDITO(
id_credito varchar(15) primary key not null,
id_paciente varchar(15) not null,
id_forma_pago varchar(15) not null,
id_factura varchar(15) not null,

foreign key (id_paciente) references PACIENTE(id_paciente),
foreign key (id_forma_pago) references FORMAS_PAGO(id_forma_pago),
foreign key (id_factura) references ENCABEZADO_FACTURA(id_encabezado_factura)
)ENGINE=InnoDB DEFAULT CHARSET =utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

