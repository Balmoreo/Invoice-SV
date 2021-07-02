DECLARE 
@No_Factura numeric(18, 0), --en blanco
@Tipo_Doc varchar(50),--SALCCF credito fiscal -- SALFCF consumidor final
@Serie  varchar(50),  --en blanco 
@Id_cliente numeric(18,0),--Generico
@Cod_PV numeric(18,0),--codigo punto de venta
@Fecha datetime,
@Boleto varchar(50),
@Monto_Fact  numeric(18,4), 
@Monto_Iva  numeric(18,4), 
@Cod_Empresa  numeric(18, 0), 
@Estado varchar(50),
@PercepcionRetencion numeric(18,4),
@Sujeta numeric(18,4), 
@Gravada numeric(18,4), 
@Exenta bit, 
@VentaExenta numeric(18,4),
@Nombre varchar(MAX),
@Direccion varchar(MAX),
@Telefono varchar(50),
@Movil varchar(50),
@Nit varchar(50),
@Nrc varchar(50),
@Giro varchar(50)

DECLARE INGRESO CURSOR FOR
select Distinct top 1  NumeroDocumento,'GUAWEB' as 'Tipo_Doc','' as 'serie',999 as 'Id_Cliente',304 as 'Cod_PV',FechaEmision,'NA' as 'Boleto',Total,TotalDeImpuestos1,
200 as 'Cod_Empresa',cast(0 as bit) as 'Estado',0 as 'Per/Ret',(SubTotalConDR-IngresosNetosGravados ) as 'Sujeta',IngresosNetosGravados,cast(0 as bit) as 'Exenta',0 as 'VentaExenta',NombreComercial,Direccion1,
'0000-0000' as 'Telefono','0000-0000' as 'Movil',Nit,'NA' as 'NRC',NombreComercial from tbl_facturaTemp where estado='N' 
order by FechaEmision
OPEN INGRESO

FETCH NEXT FROM INGRESO

INTO @No_Factura, @Tipo_Doc, @Serie,@Id_cliente, @Cod_PV ,@Fecha,@Boleto,@Monto_Fact,@Monto_Iva,@Cod_Empresa ,@Estado,@PercepcionRetencion,@Sujeta,@Gravada,@Exenta, 
@VentaExenta,@Nombre,@Direccion ,@Telefono ,@Movil ,@Nit ,@Nrc ,@Giro
WHILE @@FETCH_STATUS = 0
BEGIN
       EXEC [dbo].[P_Enc_Factura] @No_Factura, @Tipo_Doc, @Serie,@Id_cliente, @Cod_PV ,@Fecha,@Boleto,@Monto_Fact,@Monto_Iva,@Cod_Empresa ,@Estado,@PercepcionRetencion,@Sujeta,@Gravada,@Exenta, 
@VentaExenta,@Nombre,@Direccion ,@Telefono ,@Movil ,@Nit ,@Nrc ,@Giro


       DECLARE  @correlativo numeric(18, 0),@nolinea numeric(18, 0),@idservicio  varchar(50),@cantidad numeric(18,0),@precio numeric(18,4),
@precio_total numeric(18,4),@Descripcion varchar(MAX),@sujeto  bit 
           
                                                                                 
                    DECLARE DETALLE CURSOR FOR 
                    
                    select  0 as 'Cor',rank() OVER (ORDER BY Descripcion) as linea,'1021' as 'Servicio',Cantidad,PrecioSinDR,(MontoConDR+TotalDElIva) as 'PrecioTotal',Descripcion,0 from Tbl_FacturaTemp 
                    WHERE NumeroDocumento = @No_factura 
                   
                    
                    OPEN DETALLE
                    FETCH NEXT FROM DETALLE
                    INTO  @correlativo,@nolinea ,@idservicio ,@cantidad ,@precio ,@precio_total ,@Descripcion ,@sujeto 
                    WHILE @@FETCH_STATUS = 0
                    BEGIN
                           
                           EXEC P_Det_Factura  @No_Factura, @correlativo,@nolinea ,@idservicio ,@cantidad ,@precio ,@precio_total ,@Descripcion ,@sujeto,@Tipo_Doc ,@Cod_PV 
                                                    FETCH NEXT FROM DETALLE
                           INTO  @correlativo,@nolinea ,@idservicio ,@cantidad ,@precio ,@precio_total ,@Descripcion ,@sujeto 

                    END
                    CLOSE DETALLE
                    DEALLOCATE DETALLE

					UPDATE Tbl_FacturaTemp SET Estado = 'P' WHERE NumeroDocumento = @No_Factura 

       FETCH NEXT FROM INGRESO
       INTO @No_Factura, @Tipo_Doc, @Serie,@Id_cliente, @Cod_PV ,@Fecha,@Boleto,@Monto_Fact,@Monto_Iva,@Cod_Empresa ,@Estado,@PercepcionRetencion,@Sujeta,@Gravada,@Exenta, 
@VentaExenta,@Nombre,@Direccion ,@Telefono ,@Movil ,@Nit ,@Nrc ,@Giro
END
CLOSE INGRESO
DEALLOCATE INGRESO

--P_Det_Factura
--P_Enc_Factura