
GO
/****** Object:  StoredProcedure [dbo].[REP_VENTAS_CONSUMIDORES]    Script Date: 02/12/2015 21:58:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[REP_VENTAS_CONSUMIDORES]-- '01/28/2015','01/30/2015','SALFCF'
@FechaDesde date,
@FechaHasta date,
@Tipo_Doc varchar(20)

				   
AS          
BEGIN          
   with VentasConsumidores
   as
   (
  
   
  SELECT distinct p.Cod_Punto_Venta,p.Nombre_Punto,p.Encargado,p.Cod_Empresa,f.Tipo_Doc as TipoDocFac,f.Serie,f.No_factura,f.fecha_sys,
   /*dp.Cod_Doc as TipoDocPV,*/cli.Nombre,cli.Nrc,
   f.VentaSujeta as VentaNoSujeta,f.VentaGravada,f.Monto_Iva,f.Monto_Fact as TotalFactura,f.EstadoExenta,f.Estado
  FROM tbl_factura f
  INNER JOIN tbl_Punto_Venta p ON f.Cod_Punto_Venta = p.Cod_Punto_Venta
  INNER JOIN tbl_Doc_PuntoVenta dp ON p.Cod_Punto_Venta = dp.Cod_PuntoVenta	 AND dp.Cod_Doc = @Tipo_Doc
  INNER JOIN tbl_clientes cli ON f.Id_cliente = cli.Id_cliente
  WHERE f.Tipo_Doc = @Tipo_Doc AND f.Fecha_Sys between @FechaDesde AND @FechaHasta	AND F.ESTADO <> 'A'

											  
  ) -- Fin with
  
SELECT distinct Cod_Punto_Venta,Nombre_Punto,Serie,Cast(Fecha_Sys as DATE) as Fecha_Sys,
MIN(No_factura)over(partition by Cast(Fecha_Sys as DATE)) as correlativo_ini,
MAX(No_factura) OVER(PARTITION by Cast(Fecha_Sys as DATE)) as correlativo_fin, 
SUM(VentaNoSujeta) OVER(PARTITION by Cast(Fecha_Sys as DATE)) as VentasNoSujetas,
SUM(VentaGravada)OVER (PARTITION by Cast(Fecha_Sys as DATE)) as VentaGravada, 
SUM(Monto_Iva) OVER(PARTITION by Cast(Fecha_Sys as DATE)) as Monto_Iva, 
SUM(TotalFactura) OVER(PARTITION by Cast(Fecha_Sys as DATE)) as Monto_Fact,EstadoExenta
FROM VentasConsumidores
WHERE TipoDocFac = @Tipo_Doc

END -- FIN SP