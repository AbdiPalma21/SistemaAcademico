using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Models
{
    public class Estudiante : Persona
    {
        // Atributos
        public string carnet { get; set; } = string.Empty;

        public Dictionary<string, float> notas { get; } = new();
        public override void mostrarInformacion()
        {
            Console.WriteLine($"Estudiante: {nombre} (Carnet: {carnet}) | DPI: {dpi} | Correo: {correo}");
        }
    }
}
