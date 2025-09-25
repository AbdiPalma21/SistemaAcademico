using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Models
{
    public class Profesor : Persona
    {
        // Atributos
        public string especialidad { get; set; } = string.Empty;

        // Lista de cursos
        public List<Curso> cursosAsignados { get; } = new();

        public override void mostrarInformacion()
        {
            Console.WriteLine($"Profesor: {nombre} (Especialidad: {especialidad}) | DPI: {dpi} | Correo: {correo}");
        }
    }
}
