# El Cairo — Sistema POS
## Stack
C# .NET 8 WinForms + Supabase (PostgreSQL + Auth + Storage)
Proyecto: ModernMenuUI.sln

## Arquitectura de capas
- CapaDeDatos/        → Modelos Supabase, Repositorios, Conexión
- CapaDominio/        → Modelos de negocio (Factura, ItemFactura)
- CapaServiciosSeguridad/ → ServicioSesionUsuario, roles
- ModernMenuUI/       → Formularios WinForms, controles, servicios

## Archivos clave
- frmFacturacion.cs               → POS principal (carrito, buscador, panel detalle)
- frmMenuPrincipal.cs             → Menú con barra de productos más vendidos
- CarritoManager.cs               → Retorna ResultadoCarrito enum
- BarraProductosSugeridos.cs      → Control reutilizable (ModoTabular=true para grid)
- ServicioFacturaPDF.cs           → HTML→PDF con PuppeteerSharp
- FacturaMapper.cs                → Carrito + Empresa → Factura
- EmpresaRepositorio.cs           → Lee configuracion_empresa de Supabase
- factura_sar_honduras.html       → Plantilla HTML SAR Honduras (en Recursos/)

## Funciones SQL en Supabase
- buscar_productos_bodega(texto, id_bodega, limite)     → búsqueda
- obtener_productos_mas_vendidos(id_bodega, limite)     → top ventas
- registrar_venta(...)                                  → registra venta

## Tabla configuracion_empresa
Campos: id_empresa, nombre_empresa, rtn_empresa, direccion_empresa,
        telefono_empresa, correo_empresa, cai_empresa, rango_autorizado,
        fecha_limite_emision, id_estado, estado

## Reglas importantes
- NUNCA usar HttpClient como campo de instancia — usar static readonly o using local
- El trigger resta_tras_venta resta de producto.cantidad_producto (stock total)
- El RPC registrar_venta resta de inventario.stock_producto_bodega (por bodega)
- Los productos en sugerencias y barra SOLO muestran los que tienen stock > 0
- La plantilla HTML usa {{PLACEHOLDERS}} en mayúsculas con dobles llaves
- Para compilar: dotnet build "ModernMenuUI/ModernMenuUI.csproj"
