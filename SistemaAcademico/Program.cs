using SistemaAcademico.Data;
using SistemaAcademico.Models;

namespace SistemaAcademico
{
    internal class Program
    {
        static List<Profesor> _profesores = new();
        static List<Estudiante> _estudiantes = new();
        static List<Curso> _cursos = new();

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Cargar datos de ejemplo
            (_profesores, _estudiantes, _cursos) = DatosIniciales.CrearDatos();

            // Menú principal
            int op;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== Sistema de Gestión Académica =====");
                Console.WriteLine("1) Listar cursos");
                Console.WriteLine("2) Ver detalle de un curso (con notas y promedio)");
                Console.WriteLine("3) Registrar nota en un curso");
                Console.WriteLine("4) Asignar profesor a un curso");
                Console.WriteLine("5) Agregar estudiante a un curso");
                Console.WriteLine("6) Mostrar información de todas las personas");
                Console.WriteLine("0) Salir");
                Console.Write("Seleccione opción: ");

                if (!int.TryParse(Console.ReadLine(), out op)) op = -1;
                Console.WriteLine();

                switch (op)
                {
                    case 1: ListarCursos(); break;
                    case 2: VerDetalleCurso(); break;
                    case 3: RegistrarNota(); break;
                    case 4: AsignarProfesor(); break;
                    case 5: AgregarEstudiante(); break;
                    case 6: MostrarPersonas(); break;
                    case 0: Console.WriteLine("Hasta luego."); break;
                    default: Console.WriteLine("Opción inválida."); break;
                }

            } while (op != 0);
        }

        static void ListarCursos()
        {
            Console.WriteLine("== Cursos ==");
            foreach (var c in _cursos)
            {
                c.ImprimirResumen();
                Console.WriteLine();
            }
        }

        static void VerDetalleCurso()
        {
            var curso = SeleccionarCursoPorCodigo();
            if (curso == null) return;
            Console.WriteLine();
            curso.ImprimirDetalleConNotas();
        }

        static void RegistrarNota()
        {
            var curso = SeleccionarCursoPorCodigo();
            if (curso == null) return;

            var estudiante = SeleccionarEstudiantePorCarnet();
            if (estudiante == null) return;

            Console.Write("Ingrese la nota (0-100): ");
            if (float.TryParse(Console.ReadLine(), out var nota))
            {
                var ok = curso.registrarNota(estudiante, nota);
                if (ok)
                {
                    Console.WriteLine("Nota registrada correctamente.");
                    Console.WriteLine($"Promedio actualizado: {curso.calcularPromedio():0.00}");
                }
            }
            else
            {
                Console.WriteLine("Nota inválida.");
            }
        }

        static void AsignarProfesor()
        {
            var curso = SeleccionarCursoPorCodigo();
            if (curso == null) return;

            var profesor = SeleccionarProfesorPorNombre();
            if (profesor == null) return;

            curso.asignarProfesor(profesor);
            Console.WriteLine("Profesor asignado.");
        }

        static void AgregarEstudiante()
        {
            var curso = SeleccionarCursoPorCodigo();
            if (curso == null) return;

            var estudiante = SeleccionarEstudiantePorCarnet();
            if (estudiante == null) return;

            curso.agregarEstudiante(estudiante);
            Console.WriteLine("Estudiante agregado.");
        }

        static void MostrarPersonas()
        {
            Console.WriteLine("== Profesores ==");
            foreach (var p in _profesores) p.mostrarInformacion();

            Console.WriteLine();
            Console.WriteLine("== Estudiantes ==");
            foreach (var e in _estudiantes) e.mostrarInformacion();
        }

        // Helpers de selección
        static Curso? SeleccionarCursoPorCodigo()
        {
            Console.WriteLine("Cursos disponibles:");
            foreach (var c in _cursos) Console.WriteLine($"- {c.codigo}: {c.nombre}");
            Console.Write("Ingrese código del curso: ");
            var code = Console.ReadLine()?.Trim();
            var curso = _cursos.FirstOrDefault(x => x.codigo.Equals(code, StringComparison.OrdinalIgnoreCase));
            if (curso == null) Console.WriteLine("Curso no encontrado.");
            return curso;
        }

        static Estudiante? SeleccionarEstudiantePorCarnet()
        {
            Console.WriteLine("Estudiantes disponibles:");
            foreach (var e in _estudiantes) Console.WriteLine($"- {e.carnet}: {e.nombre}");
            Console.Write("Ingrese carnet del estudiante: ");
            var carnet = Console.ReadLine()?.Trim();
            var est = _estudiantes.FirstOrDefault(x => x.carnet.Equals(carnet, StringComparison.OrdinalIgnoreCase));
            if (est == null) Console.WriteLine("Estudiante no encontrado.");
            return est;
        }

        static Profesor? SeleccionarProfesorPorNombre()
        {
            Console.WriteLine("Profesores disponibles:");
            foreach (var p in _profesores) Console.WriteLine($"- {p.nombre} ({p.especialidad})");
            Console.Write("Ingrese el nombre EXACTO del profesor: ");
            var name = Console.ReadLine() ?? string.Empty;
            var prof = _profesores.FirstOrDefault(x => x.nombre.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (prof == null) Console.WriteLine("Profesor no encontrado.");
            return prof;
        }
    }
}