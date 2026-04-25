using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDeDatos.Datos;

public static class ImagenHelper
{
    public static async Task<string> ObtenerUrlPublicaAsync(string ruta)
    {
        if (string.IsNullOrWhiteSpace(ruta)
            || ruta == "SIN_IMAGEN"
            || ruta == "NULL")
            return null;

        if (ruta.StartsWith("http"))
            return ruta;

        var client = await Conexion.GetClientAsync();

        return client.Storage
            .From("imagenes_productos") // ← tu bucket
            .GetPublicUrl(ruta);
    }
}