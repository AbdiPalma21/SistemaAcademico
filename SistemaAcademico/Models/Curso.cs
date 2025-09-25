using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Models
{
    public class Curso
    {
        // Atributos
        public string codigo { get; }
        public string nombre { get; }
        public Profesor profesor { get; private set; }  // agregación
        public List<Estudiante> estudiantes { get; } = new(); // agregación

        // Mapeo interno de nota por carnet para este curso
        private readonly Dictionary<string, float> notasPorCarnet = new();

        public Curso(string codigo, string nombre)
        {
            this.codigo = codigo;
            this.nombre = nombre;
        }

        // Métodos requeridos
        public void agregarEstudiante(Estudiante e)
        {
            if (e == null) return;
            if (!estudiantes.Any(x => x.carnet == e.carnet))
            {
                estudiantes.Add(e);
            }
        }

        public void asignarProfesor(Profesor p)
        {
            profesor = p;
            if (p != null && !p.cursosAsignados.Contains(this))
            {
                p.cursosAsignados.Add(this);
            }
        }

        public bool registrarNota(Estudiante e, float nota)
        {
            if (e == null) return false;

            if (!estudiantes.Any(x => x.carnet == e.carnet))
            {
                Console.WriteLine("El estudiante no está inscrito en este curso.");
                return false;
            }

            // Validar rango, por si acaso
            if (nota < 0 || nota > 100)
            {
                Console.WriteLine("La nota debe estar entre 0 y 100.");
                return false;
            }

            notasPorCarnet[e.carnet] = nota;
            e.notas[codigo] = nota;
            return true;
        }


        public double calcularPromedio()
        {
            if (notasPorCarnet.Count == 0) return 0.0;
            return Math.Round(notasPorCarnet.Values.Average(), 2);
        }

        // métodos para el menú
        public void ImprimirResumen()
        {
            Console.WriteLine($"Curso: {nombre}");
            var profLabel = profesor != null
                ? $"Prof: {profesor.nombre} (Especialidad: {profesor.especialidad})"
                : "Prof: (sin asignar)";
            Console.WriteLine(profLabel);
            Console.WriteLine($"Estudiantes inscritos: {estudiantes.Count}");
        }

        public void ImprimirDetalleConNotas()
        {
            Console.WriteLine($"Curso: {nombre}");
            if (profesor != null)
                Console.WriteLine($"Profesor: {profesor.nombre} (Especialidad: {profesor.especialidad})");
            else
                Console.WriteLine("Profesor: (sin asignar)");

            Console.WriteLine($"Estudiantes inscritos: {estudiantes.Count}");
            Console.WriteLine();

            foreach (var e in estudiantes)
            {
                string notaTxt = notasPorCarnet.TryGetValue(e.carnet, out var n)
                    ? n.ToString()
                    : "—";
                Console.WriteLine($"- {e.nombre} (Carnet: {e.carnet}) - Nota: {notaTxt}");
            }

            Console.WriteLine();
            Console.WriteLine($"Promedio del curso: {calcularPromedio():0.00}");
        }
    }
}
