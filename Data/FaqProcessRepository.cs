using ClasificadorComents.Models;
using System.Collections.Generic;

namespace ClasificadorComents.Data
{
    public static class FaqProcessRepository
    {
        public static List<FaqProcess> GetAll() => new List<FaqProcess>
        {
            new FaqProcess
            {
                Title = "Pasos para inscribir materias",
                Intro = "Sigue estos 5 pasos para la inscripción de tus materias en el semestre:",
                Steps = new List<ProcessStep>
                {
                    new ProcessStep { Text = "Ingresa al portal académico.", Screenshot="img/inscripcion/1.png", Alt="Portal inicio" },
                    new ProcessStep { Text = "Selecciona el semestre que deseas inscribir.", Screenshot="img/inscripcion/2.png", Alt="Selección de semestre" },
                    new ProcessStep { Text = "Marca las materias que quieras cursar.", Screenshot="img/inscripcion/3.png", Alt="Selección de materias" },
                    new ProcessStep { Text = "Confirma tu horario y cupos disponibles.", Screenshot="img/inscripcion/4.png", Alt="Confirmación" },
                    new ProcessStep { Text = "Descarga tu comprobante de inscripción.", Screenshot="img/inscripcion/5.png", Alt="Comprobante" }
                }
            },

            new FaqProcess
            {
                Title = "Pasos para inscribir verano",
                Intro = "Este proceso exprés de inscribirte en cursos de verano consta de 3 pasos:",
                Steps = new List<ProcessStep>
                {
                    new ProcessStep { Text = "Accede al portal de verano.", Screenshot="img/verano/1.png", Alt="Portal verano" },
                    new ProcessStep { Text = "Elige el curso y el horario.", Screenshot="img/verano/2.png", Alt="Selección curso verano" },
                    new ProcessStep { Text = "Realiza el pago de matrícula.", Screenshot="img/verano/3.png", Alt="Pago matrícula verano" }
                }
            }

            // Agrega más procesos según necesites…
        };
    }
}

