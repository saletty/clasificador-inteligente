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
                    Intro = "Sigue estos pasos para inscribir las materias del semestre en la UAGRM.",
                    Steps = new List<ProcessStep>
                    {
                        new ProcessStep {
                            Text       = "Consulta tu fecha y hora de inscripción."
                        },
                        new ProcessStep {
                            Text       = "Verifica el pago de matrícula y otros conceptos accediendo al portal, luego haz clic en «Otros Servicios» → «Pago Matrícula y Otros»."
                        },
                        new ProcessStep {
                            Text       = "Revisa que no tengas ningún bloqueo, en cuyo caso sea así puedes consultar preguntando: ¿Cómo saber si tengo un bloqueo?"
                        },
                        new ProcessStep {
                            Text       = "Revisa que no tengas ningún bloqueo académico."
                        },
                        new ProcessStep {
                            Text       = "Consulta las fechas de inscripción en el foro de Facebook.",
                            Url        = "https://www.facebook.com/profile.php?id=61567216448008&locale=es_LA"
                        },
                        new ProcessStep {
                            Text       = "Entra al portal de Inscripción Web.",
                            Url        = "https://inscripcion.uagrm.edu.bo/idxLogin.aspx",
                            Screenshot = "paginas/img/retiro/13.png",
                            Alt        = "Portal de Inscripción Web"
                        },
                        new ProcessStep {
                            Text       = "Inicia sesión con tu registro y contraseña., antes de inscribir, debes recalcular tus materias, dando en la opción “otros servicios”",
                            Screenshot = "paginas/img/retiro/23.png",
                            Alt        = "Pantalla de login"
                        },
                        new ProcessStep {
                            Text       = "Selecciona “Recalcular materias” antes de inscribir.",
                            Screenshot = "paginas/img/retiro/24.png",
                            Alt        = "Recalcular materias"
                        },
                        new ProcessStep {
                            Text       = "Ahora verás las materias que cursarás en el semestre.",
                            Screenshot = "paginas/img/retiro/25.png",
                            Alt        = "Listado de materias"
                        },
                        new ProcessStep {
                            Text       = "Haz clic en “Volver a carreras” para elegir tu plan de estudios.",
                            Screenshot = "paginas/img/retiro/26.png",
                            Alt        = "Volver a carreras"
                        },
                        new ProcessStep {
                            Text       = "Selecciona tu carrera y “periodo normal”, luego elige “personalizada”.",
                            Screenshot = "paginas/img/retiro/27.png",
                            Alt        = "Seleccionar carrera"
                        },
                        new ProcessStep {
                            Text       = "Marca la columna OK junto a las materias que deseas inscribir.",
                            Screenshot = "paginas/img/retiro/28.png",
                            Alt        = "Marcar materias"
                        },
                        new ProcessStep {
                            Text       = "Verifica grupos, docentes, horarios y cupos habilitados para cada materia.",
                            Screenshot = "paginas/img/retiro/29.png",
                            Alt        = "Detalles de materias"
                        },
                        new ProcessStep {
                            Text       = "Haz clic en “Confirmar grupos marcados”, luego en “Grabar materias seleccionadas”.",
                            Screenshot = "paginas/img/retiro/30.png",
                            Alt        = "Confirmar inscripción"
                        },
                        new ProcessStep {
                            Text       = "Imprime tu boleta de inscripción una vez finalizado el proceso.",
                            Screenshot = "paginas/img/retiro/31.png",
                            Alt        = "Boleta de inscripción"
                        }
                    }
                },
            //adicion de materias
            new FaqProcess
                {
                    Title = "Adición de materias",
                    Intro = "Sigue estos pasos para adicionar materias en el sistema de inscripción de la UAGRM.",
                    Steps = new List<ProcessStep>
                    {
                        new ProcessStep {
                            Text       = "Verificar que no tengas ningún bloqueo. Puedes consultar preguntando: ¿Cómo saber si tengo un bloqueo?"
                        },
                        new ProcessStep {
                            Text       = "Consulta las fechas habilitadas para hacer adiciones de materias.",
                            Url        = "https://www.facebook.com/profile.php?id=61567216448008&locale=es_LA"
                        },
                        new ProcessStep {
                            Text       = "Accede al Sistema de Inscripción Web e inicia sesión con tu registro y contraseña.",
                            Url        = "https://inscripcion.uagrm.edu.bo/idxDefault.aspx",
                            Screenshot = "paginas/img/retiro/13.png",
                            Alt        = "Inicio de sesión"
                        },
                        new ProcessStep {
                            Text       = "Selecciona la opción «ADICIÓN» en el menú principal.",
                            Screenshot = "paginas/img/retiro/32.png",
                            Alt        = "Opción de adición"
                        },
                        new ProcessStep {
                            Text       = "Busca la materia que deseas adicionar y consulta los grupos ofertados por docente y horario.",
                            Screenshot = "paginas/img/retiro/33.png",
                            Alt        = "Grupos ofertados"
                        },
                        new ProcessStep {
                            Text       = "Elige el grupo que deseas y haz clic en «Confirmar Grupos Seleccionados».",
                            Screenshot = "paginas/img/adicion/34.png",
                            Alt        = "Confirmar grupo"
                        },
                        new ProcessStep {
                            Text       = "Si te equivocas al seleccionar una materia, puedes volver al menú de carreras haciendo clic en «Volver a Carreras» en la parte superior..",
                        },
                        new ProcessStep {
                            Text       = "Selecciona el tipo de boleta, confirma la adición y verifica que las materias se hayan actualizado.",
                            Screenshot = "paginas/img/adicion/31.png",
                            Alt        = "Boleta de adición"
                        }
                    }
             },

            // habilitar retiro de materias
             new FaqProcess
             {
                Title = "Pasos para habilitar retiro de materia",
                Intro  = "Si ya usaste tu primer retiro gratuito del semestre, sigue estos pasos para volver a habilitar el retiro de materias.",
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
                        Screenshot = "paginas/img/retiro/3.png",
                        Alt = "Solicitar servicio"
                    },
                    new ProcessStep {
                        Text = "Haz clic en el botón verde para abrir el Sistema de Consultas de Caja.",
                        Screenshot = "paginas/img/retiro/4.png",
                        Alt = "Botón verde para habilitar servicios"
                    },
                    new ProcessStep {
                        Text = "Dirígete a 'Pagos / Servicios'.",
                        Screenshot = "paginas/img/retiro/5.png",
                        Alt = "Menú pagos y servicios"
                    },
                    new ProcessStep {
                        Text = "Selecciona 'Solicitar Servicios'.",
                        Screenshot = "paginas/img/retiro/6.png",
                        Alt = "Opción solicitar servicios"
                    },
                    new ProcessStep {
                        Text = "Haz clic en 'Solicitar Nuevo Servicio'.",
                        Screenshot = "paginas/img/retiro/7.png",
                        Alt = "Solicitud nuevo servicio"
                    },
                    new ProcessStep {
                        Text = "Elige la opción 'Retiro De Materias'.",
                        Screenshot = "paginas/img/retiro/8.png",
                        Alt = "Selección retiro de materias"
                    },
                    new ProcessStep {
                        Text = "Presiona el botón 'Generar Servicio' para habilitar el trámite.",
                        Screenshot = "paginas/img/retiro/9.png",
                        Alt = "Generar servicio de retiro"
                    },
                    new ProcessStep {
                        Text = "Seleccionamos el método de pago.",
                        Screenshot = "paginas/img/retiro/10.png",
                        Alt = "Selección método de pago"
                    },
                    new ProcessStep {
                        Text = "Una vez ya realizado debe al cabo de un rato debe aparecer en Pagos Realizados",
                        Screenshot = "paginas/img/retiro/11.png",
                        Alt = "Selección método de pago"
                    }
                }
            },

             //retiro de materia
             new FaqProcess
             {
                Title = "Pasos para hacer retiro de materia",
                Intro  = "Sigue los siguientes pasos para retirar materias:",
                Steps = new List<ProcessStep>
                 {
                     new ProcessStep {
                        Text = "Verificar que la cantidad de estudiantes.Para esto podrías verificarlo en Presencial UAGRM inicias sesión, " +
                        "seleccionas la materia y verificas en “Participantes” que la cantidad sea mayor a 41 tomando en cuenta al docente.",
                        Url = "https://presencial.uagrm.edu.bo"
                    },
                    new ProcessStep {
                        Text = "Verificar que no tengas ningún bloqueo. Puedes consultar preguntando: ¿Cómo saber si tengo un bloqueo?"
                    },
                    new ProcessStep {
                        Text = "Tienes que verificar que días son los retiro de materias, puedes verificar en: ",
                        Url = "https://www.facebook.com/profile.php?id=61567216448008&locale=es_LA "
                    },
                    new ProcessStep {
                        Text = "Ingresamos a Sistema De Inscripción Web e iniciamos sesión con nuestro registro y contraseña. ",
                        Url = "https://inscripcion.uagrm.edu.bo/idxDefault.aspx",
                        Screenshot = "paginas/img/retiro/13.png",
                        Alt = "Ingresar al sistema"
                    },
                    new ProcessStep {
                        Text = "Nos debería salir de esta manera y selecciona:  RETIRO'.",
                        Screenshot = "paginas/img/retiro/14.png",
                        Alt = "Selección retiro"
                    },
                    new ProcessStep {
                        Text = "Debes saber que, si la materia que deseas retirar fue levantada y tiene prerrequisitos en cadena, el sistema impide el retiro. Por Ejemplo: Si inscribiste Estructura de datos 1 y haces levantamiento para agarrar Base de datos 1, entonces no podrás retirar Estructura de datos 1 por que es prerrequisito para Base de datos 1."
                    }
                    new ProcessStep {
                        Text = "Luego puedes seleccionar la materia que quieres retirar.",
                        Screenshot = "paginas/img/retiro/15.png",
                        Alt = "Selección materias a retirar"
                    },
                    new ProcessStep {
                        Text = "Puedes seleccionar más de una materia para retirar. Luego de seleccionar la materia o materias, te debe mostrar asi:",
                        Screenshot = "paginas/img/retiro/16.png",
                        Alt = "Selección retiro de materias"
                    },
                    new ProcessStep {
                        Text = "Bien puedes darle a Grabar Materias a Retirar, pero si no es la que quieres retirar, dale a eliminar y volverá a materia inscrita. Para completar el retiro de materia debes dar al botón de  Grabar Materias a Retirar y te debe mostrar esto:"
                    },
                    new ProcessStep {
                        Text = "Seleccionas el tipo de boleta y te saldrán solo las materias inscritas, sin las que retiraste:",
                        Screenshot = "paginas/img/retiro/17.png",
                        Alt = "Selección de tipo de boleta"
                    },
                    new ProcessStep {
                        Text = "Una vez hayas realizados todos los pasos ya completaste el retiro de materias."
                    }
                }
                },
               //VERANO
             new FaqProcess
            {
                Title = "Pasos para inscribir verano",
                Intro = "Este proceso exprés de inscribirte en cursos de verano consta de 3 pasos:",
                Steps = new List<ProcessStep>
                {
                        new ProcessStep {
                            Text       = "Verificar que la cantidad de estudiantes.\r\nPara esto podrías verificarlo en las aulas virtuales. Inicias sesión, seleccionas la materia y verificas en “Participantes” que la cantidad sea mayor a 41 tomando en cuenta al docente.\r\n",
                            Url        = "https://presencial.uagrm.edu.bo "
                    },
                        new ProcessStep {
                            Text       = "Verificar que no tengas ningún bloqueo. Puedes consultar preguntando: ¿Cómo saber si tengo un bloqueo?"
                    },
                        new ProcessStep {
                            Text       = "Tienes que verificar que días son los retiro de materias, puedes verificar en:",                 
                            Url        = "https://www.facebook.com/profile.php?id=61567216448008&locale=es_LA"

                    },
                        new ProcessStep {
                            Text       = "Ingresamos a Sistema De Inscripción Web e iniciamos sesión con nuestro registro y contraseña.",
                            Url        = "https://inscripcion.uagrm.edu.bo/idxDefault.aspx"

                        },
                        new ProcessStep {
                            Text       = "Nos debería salir de esta manera y selecciona:  VERANO.",
                            Screenshot = "paginas/img/retiro/4.png",
                            Alt        = "Portal Presencial UAGRM"
                        },
                        new ProcessStep {
                            Text       = "Debes saber que, si la materia que deseas retirar fue levantada y tiene prerrequisitos en cadena, el sistema impide el retiro. \r\nPor Ejemplo: Si inscribiste Estructura de datos 1 y haces levantamiento para agarrar Base de datos 1, entonces no podrás retirar Estructura de datos 1 por que es prerrequisito para Base de datos 1.\r\n"
                        },
                        new ProcessStep {
                            Text       = "Luego puedes seleccionar la materia que quieres retirar.",
                            Screenshot = "paginas/img/retiro/6.png",
                            Alt        = "Fechas de retiro"
                        },
                        new ProcessStep {
                            Text       = "Puedes seleccionar más de una materia para retirar. Luego de seleccionar la materia o materias, te debe mostrar asi:",
                            Screenshot = "paginas/img/retiro/7.png",
                            Alt        = "Sistema de Inscripción Web"
                        },
                        new ProcessStep {
                            Text       = "Elige el tipo de boleta de retiro y verifica que solo aparezcan las materias restantes.",
                            Screenshot = "paginas/img/retiro/8.png",
                            Alt        = "Opción RETIRO"
                        }
                   
                    
                }
            },
             new FaqProcess
{
    Title = "Verificar bloqueo académico",
    Intro = "Sigue estos pasos para consultar si tienes algún bloqueo que impida trámites como retiro o adición de materias.",
    Steps = new List<ProcessStep>
    {
        new ProcessStep {
            Text       = "Accede al portal de perfil de estudiante.",
            Url        = "https://perfil.uagrm.edu.bo"
       
        },
        new ProcessStep {
            Text       = "Selecciona “Estudiante” como tipo de cuenta e inicia sesión con tu registro y contraseña.",
            Screenshot = "paginas/img/retiro/1.png",
            Alt        = "Inicio de sesión estudiante"
        },
        new ProcessStep {
            Text       = "En la barra lateral izquierda, haz clic en “Bloqueos”.",
            Screenshot = "paginas/img/retiro/2.png",
            Alt        = "Opción Bloqueos"
        },
        new ProcessStep {
            Text       = "Revisa la lista de bloqueos que aparece para confirmar si existe alguno que impida tus trámites.",
            Screenshot = "paginas/img/retiro/22.png",
            Alt        = "Lista de bloqueos"
        },
        new ProcessStep {
            Text       = "Si tienes algún bloqueo, acércate al centro interno de tu facultad o al CPD para gestionarlo."
        }
    }
},



            // Agrega más procesos según necesites…
        };
    }
}

