using SistemaAcademico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAcademico.Data
{
    public static class DatosIniciales
    {
        //Creacion de profesarores, estudiantes y cursos quemados
        public static (List<Profesor> profesores, List<Estudiante> estudiantes, List<Curso> cursos)
            CrearDatos()
        {
            // Profesores
            var prof1 = new Profesor
            {
                nombre = "Ing.Ana López",
                dpi = "3012345670101",
                correo = "ana.lopez@upana.edu",
                especialidad = "Ingeniería en sistemas"
            };

            var prof2 = new Profesor
            {
                nombre = "Lic.Carlos Díaz",
                dpi = "2011122233301",
                correo = "carlos.diaz@upana.edu",
                especialidad = "Educador en materias básicas"
            };

            // Estudiantes
            var e1 = new Estudiante
            {
                nombre = "Juan Pérez",
                dpi = "1000111122223",
                correo = "juan.perez@correo.com",
                carnet = "20210001"
            };

            var e2 = new Estudiante
            {
                nombre = "María Gómez",
                dpi = "1000222233334",
                correo = "maria.gomez@correo.com",
                carnet = "20210002"
            };

            var e3 = new Estudiante
            {
                nombre = "Luis Ramírez",
                dpi = "1000333344445",
                correo = "luis.ramirez@correo.com",
                carnet = "20210003"
            };

            var e4 = new Estudiante
            {
                nombre = "Sofía Hernández",
                dpi = "1000444455556",
                correo = "sofia.hernandez@correo.com",
                carnet = "20210004"
            };

            // Cursos
            var c1 = new Curso("CS102", "progra");
            var c2 = new Curso("CS201", "mate");
            var c3 = new Curso("CS301", "ingles");

            // agregar
            c1.asignarProfesor(prof1);
            c2.asignarProfesor(prof2);
            c3.asignarProfesor(prof2);

            c1.agregarEstudiante(e1);
            c1.agregarEstudiante(e2);
            c1.agregarEstudiante(e3);

            c2.agregarEstudiante(e1);
            c2.agregarEstudiante(e4);

            c3.agregarEstudiante(e2);
            c3.agregarEstudiante(e3);
            c3.agregarEstudiante(e4);

            // Notas de ejemplo
            c1.registrarNota(e1, 85f);
            c1.registrarNota(e2, 90f);
            c1.registrarNota(e3, 78f);

            return (
                new List<Profesor> { prof1, prof2 },
                new List<Estudiante> { e1, e2, e3, e4 },
                new List<Curso> { c1, c2, c3 }
            );
        }
    }
}
