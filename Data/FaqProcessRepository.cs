using ClasificadorComents.Models;
using System.Collections.Generic;
using static System.Net.WebRequestMethods;

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
            },

             new FaqProcess
             {
                Title = "Pasos para habilitar retiro de materia",
                Intro = "Cabe decir que en cada semestre el primer retiro y adición de materia es gratuito. A continuación se detallan los pasos para habilitar el retiro:",
                Steps = new List<ProcessStep>
                {
                    new ProcessStep {
                        Text = "Accede al portal como estudiante.",
                        Url = "https://perfil.uagrm.edu.bo",
                        Screenshot = "paginas/img/retiro/1.png",
                        Alt = "Portal UAGRM"
                    },
                    new ProcessStep {
                        Text = "Inicia sesión utilizando tu código de registro estudiantil y contraseña.",
                        Screenshot = "paginas/img/retiro/2.png",
                        Alt = "Inicio de sesión"
                    },
                    new ProcessStep {
                        Text = "Selecciona 'Solicitar servicio' desde la barra lateral izquierda.",
                        Screenshot = "img/retiro/3.png",
                        Alt = "Solicitar servicio"
                    },
                    new ProcessStep {
                        Text = "Haz clic en el botón verde para abrir el Sistema de Consultas de Caja.",
                        Screenshot = "img/retiro/4.png",
                        Alt = "Botón verde para habilitar servicios"
                    },
                    new ProcessStep {
                        Text = "Dirígete a 'Pagos / Servicios'.",
                        Screenshot = "img/retiro/5.png",
                        Alt = "Menú pagos y servicios"
                    },
                    new ProcessStep {
                        Text = "Selecciona 'Solicitar Servicios'.",
                        Screenshot = "img/retiro/6.png",
                        Alt = "Opción solicitar servicios"
                    },
                    new ProcessStep {
                        Text = "Haz clic en 'Solicitar Nuevo Servicio'.",
                        Screenshot = "img/retiro/7.png",
                        Alt = "Solicitud nuevo servicio"
                    },
                    new ProcessStep {
                        Text = "Elige la opción 'Retiro De Materias'.",
                        Screenshot = "img/retiro/8.png",
                        Alt = "Selección retiro de materias"
                    },
                    new ProcessStep {
                        Text = "Presiona el botón 'Generar Servicio' para habilitar el trámite.",
                        Screenshot = "img/retiro/9.png",
                        Alt = "Generar servicio de retiro"
                    }
                }
            }



            // Agrega más procesos según necesites…
        };
    }
}

