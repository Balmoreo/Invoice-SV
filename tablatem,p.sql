create table Tbl_FacturaTemp( 
NumeroAutorizacion varchar(50),	NumeroDocumento Numeric(18,0),	FechaEmision Datetime,	estadodocumento varchar(20),	fechaanulado datetime,
CodigoDeMoneda varchar(10),	TipoDeCambio Numeric(18,0),	CodigoDeEstablecimiento Numeric(18,0),	DispositivoElectronico varchar(20),	Nit varchar(20),
NombreComercial varchar(300),	Idioma varchar(10),Direccion1 varchar(800),Direccion2	varchar(800),Municipio	varchar(200),Departamento varchar(200),	
CodigoDePais varchar(200),Descripcion varchar(300),CodigoEAN varchar(200), UNIDADMEDIDIA varchar(200),Cantidad numeric(18,2),PrecioSinDR numeric(18,2),	
MontoSinDR numeric(18,2),SumaDeDescuentos numeric(18,2), Tasa numeric(18,2),PrecioConDR numeric(18,2),MontoConDR numeric(18,2),TotalDeImpuestos numeric(18,2),	
TotalDelIva numeric(18,2),	Tasa1 numeric(18,2),	Tipodeotroimpuesto varchar(20),	base numeric(18,2),	tasa2 numeric(18,2),	Monto numeric(18,2),
Categoria varchar(100),	SubTotalSinDR numeric(18,2),SumaDeDescuentos1 numeric(18,2),	SubTotalConDR numeric(18,2),	TotalDeImpuestos1 numeric(18,2),	
IngresosNetosGravados numeric(18,2),	Total numeric(18,2),TotalLetras varchar(300),	MontoIsr numeric(18,2),	RefferenciaInterna varchar(50),	TextoPosicion1 varchar(100),
TextoPosicion2 varchar(100),Diccionaryname varchar(100),Entry_kfromv varchar(100),	Entryktov varchar(100),	Entrykccv varchar(100),	Entrykformatsv varchar(100),
TextoPie1 varchar(100),	TextoPie2 varchar(100),	TextoPie3 varchar(100),	TextoPie4 varchar(100),	TextoPie5 varchar(100),	TextoPie6 varchar(100),	TextoPie7 varchar(100),	TextoPie8 varchar(100),	TextoPie9 varchar(100),	
TextoPie10 varchar(100),	TextoPie11 varchar(100),	TextoPie12 varchar(100),	TextoPie13 varchar(100),	TextoPie14 varchar(100),	TextoPie15 varchar(100),
TextoPie16 varchar(100),	TextoPie17 varchar(100),	TextoPie18 varchar(100),	TextoPie19 varchar(100),	TextoPie20 varchar(100),FechaIngreso datetime default getdate(), Estado varchar(5) default 'N'
)