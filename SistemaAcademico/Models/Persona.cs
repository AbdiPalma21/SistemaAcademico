using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Models
{
    public abstract class Persona
    {
        // Atributos
        public string nombre { get; set; } = string.Empty;
        public string dpi { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;

        // Método común
        public virtual void mostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre} | DPI: {dpi} | Correo: {correo}");
        }
    }
}
