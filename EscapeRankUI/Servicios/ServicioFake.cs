using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EscapeRankUI.Modelos;
using Xamarin.Forms;

namespace EscapeRankUI.Servicios
{
    public static class ServicioFake
    {
        public static List<Noticia> Noticias;
        public static List<Usuario> Usuarios;
        public static List<Equipo> Equipos;
        public static List<Companyia> Companyias;
        public static List<Sala> Salas;
        public static List<Categoria> Categorias;
        public static List<Partida> Partidas;
        public static List<Dificultad> Dificultades;
        public static List<Publico> Publico;
        public static Perfil Perfil;
        public static Provincia Provincia;

        public static void RellenarDatos()
        {

            GetNoticiasFake();
            GetCompanyiasFake();
            GetSalasFake();
            GetPartidasFake();
            GetEquiposFake();
            GetUsuariosFake();
            GetCategoriasFake();
            GetPublicoFake();
            GetDificultadesFake();
        }

        private static void GetNoticiasFake()
        {
            Noticias = new List<Noticia>();

            for (int i = 1; i <= 3; i++)
            {

                Noticia n = new Noticia
                {
                    Id = i,
                    Imagen = "https://picsum.photos/id/" + i + "/200/300",
                    Fecha = new DateTime(2018, i, 27),
                    Titular = string.Format("TITULAR NOTICIA {0}", i),
                    TextoCorto = string.Format("Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} ", i),
                    TextoLargo = string.Format("Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0}Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} " +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}", i),
                    Promocionada = true,
                    CompanyiaId = "0",
                    Link = "http://www.google.es"
                };


                Noticias.Add(n);
            }
            for (int i = 4; i <= 7; i++)
            {

                Noticia n = new Noticia
                {
                    Id = i,
                    Imagen = "https://picsum.photos/id/1" + i + "/200/300",
                    Fecha = new DateTime(2018, i, 24),
                    Titular = string.Format("TITULAR NOTICIA {0}", i),
                    TextoCorto = string.Format("Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} ", i),
                    TextoLargo = string.Format("Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0}Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} " +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}", i),
                    Promocionada = true,
                    CompanyiaId = "2",
                    Link = "http://www.google.es"
                };


                Noticias.Add(n);
            }
            for (int i = 8; i <= 10; i++)
            {

                Noticia n = new Noticia
                {
                    Id = i,
                    Imagen = "https://picsum.photos/id/2" + i + "/200/300",
                    Fecha = new DateTime(2018, i, 23),
                    Titular = string.Format("TITULAR NOTICIA {0}", i),
                    TextoCorto = string.Format("Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} Texto corto noticia {0} ", i),
                    TextoLargo = string.Format("Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0}Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}" +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0} " +
                          "Texto largo noticia {0} Texto largo noticia {0} Texto largo noticia {0}", i),
                    Promocionada = true,
                    CompanyiaId = "1",
                    Link = "http://www.google.es"
                };


                Noticias.Add(n);
            }
        }

        private static void GetCompanyiasFake()
        {
            Companyias = new List<Companyia>();

            for (int i = 1; i <= 3; i++)
            {
                Companyia c = new Companyia
                {
                    Id = i.ToString(),
                    Nombre = "Compañía " + i,
                    Direccion = "Dirección Compañía " + i,
                    CiudadId = "i",
                    Web = "http://www.google.es"
                };
                Companyias.Add(c);
            }
        }

        private static void GetPartidasFake()
        {
            List<Partida> pa = new List<Partida>();
            for (int x = 1; x <= 9; x++)
            {
                pa.Add(new Partida
                {
                    Sala = Salas[x],
                    Fecha = new DateTime(2019, x, 10),
                    Id = x,
                    Horas = 0,
                    Minutos = 40 + x,
                    Segundos = 20
                });
            }
            Partidas = pa;
        }

        private static void GetEquiposFake()
        {
            Equipos = new List<Equipo>();


            for (int j = 1; j <= 10; j++)
            {
                Equipo t = new Equipo
                {
                    Id = j,
                    Nombre = "Equipo " + j,
                    Avatar = "https://picsum.photos/id/3" + j + "/200/300",
                    Partidas = Partidas,
                    Usuarios = new List<Usuario>()
                };
                Equipos.Add(t);
            }

        }

        private static void GetUsuariosFake()
        {
            Usuarios = new List<Usuario>();

            for (int i = 0; i <= 5; i++)
            {
                Usuario u = new Usuario
                {
                    Id = i,
                    Nombre = "User " + i,
                    Avatar = "https://picsum.photos/id/3" + i + "/200/300",
                    Telefono = "69989893" + i,
                    Email = "usuario" + i + "@mail.com",
                    Nacido = DateTime.Now.AddDays(-8000),

                    Equipos = new List<Equipo>
                    {
                        Equipos[0], Equipos[1]
                    },
                    Perfil = new Perfil
                    {
                        Nick = "Nick " + i,
                        NumeroPartidas = 20,
                        PartidasGanadas = 18,
                        PartidasPerdidas = 2,
                        MejorTiempo = DateTime.Now
                    }
                };
                Usuarios.Add(u);

                Equipos[i].Usuarios.Add(u);
                Equipos[5 - i].Usuarios.Add(u);
            }
            for (int i = 6; i < 10; i++)
            {
                Usuario u = new Usuario
                {
                    Id = i,
                    Nombre = "Usuario " + i,
                    Avatar = "https://picsum.photos/id/4" + i + "/200/300",
                    Telefono = "69989893 " + i,
                    Email = "usuario" + i + "@mail.com",
                    Nacido = DateTime.Now.AddDays(-50000),

                    Equipos = new List<Equipo>
                    {
                        Equipos[2],Equipos[3]
                    },
                    Perfil = new Perfil
                    {
                        Nick="Nick "+i,
                        NumeroPartidas = 10,
                        PartidasGanadas = 7,
                        PartidasPerdidas = 3,
                        MejorTiempo = DateTime.Now
                    }
                };
                Usuarios.Add(u);

                Equipos[i].Usuarios.Add(u);
                Equipos[10 - i].Usuarios.Add(u);
            }

            for (int i = 0; i <= 6; i++)
            {
                Usuarios[i].Amigos = Usuarios.GetRange(i + 0, 4);
            }

            for (int i = 6; i < 10; i++)
            {
                Usuarios[i].Amigos = Usuarios.GetRange(i - 6, 3);
            }

        }

        private static void GetSalasFake()
        {
            Salas = new List<Sala>();
            for (int i = 1; i <= 5; i++)
            {
                Sala e = new Sala
                {
                    Id = i.ToString(),
                    Nombre = "Sala " + i,
                    ImagenAncha = "https://picsum.photos/id/5" + i + "/200/300",
                    CompanyiaId = new Random().Next(4).ToString(),
                    Icono = (FontImageSource)Utils.GetResourceValue("icono_cat_misterio"),
                    Categorias = new List<Categoria> {
                        new Categoria {
                            Id = "1",
                            Tipo = "Escape Room"
                        }
                    }, 
                    Tematicas = new List<Tematica>
                    {
                        new Tematica
                        {
                            Id = "1",
                            Tipo = "Egipto"

                        }
                    },
                    Publico = new List<Publico>
                    {
                        new Publico
                        {
                            Id = "1",
                            Tipo = "Adultos"

                        }
                    },
                    Ciudad = new Ciudad
                    {
                        Nombre = "Ciudad " + i
                    }
                    ,
                    MinimoJugadores = new Random().Next(4),
                    Companyia = new Companyia
                    {
                        Nombre = "Companyia " + new Random().Next(4)
                    }
                };
                Salas.Add(e);
            }
            for (int i = 6; i <= 10; i++)
            {
                Sala e = new Sala
                {
                    Id = i.ToString(),
                    Nombre = "Sala " + i,
                    ImagenAncha = "https://picsum.photos/id/6" + i + "/200/300",
                    CompanyiaId = new Random().Next(4).ToString(),
                    Icono = (FontImageSource)Utils.GetResourceValue("icono_cat_misterio"),
                    Categorias = new List<Categoria> {
                        new Categoria {
                            Id = "1",
                            Tipo = "Escape Room"
                        }
                    },
                    Tematicas = new List<Tematica>
                    {
                        new Tematica
                        {
                            Id = "1",
                            Tipo = "Misterio"
                        }
                    },
                    Publico = new List<Publico>
                    {
                        new Publico
                        {
                            Id = "1",
                            Tipo = "Niños"

                        }
                    },
                    Ciudad = new Ciudad
                    {
                        Nombre = "Ciudad " + i
                    }
                    ,
                    MinimoJugadores = new Random().Next(4),
                    Companyia = new Companyia
                    {
                        Nombre = "Companyia " + new Random().Next(4)
                    }
                };
                Salas.Add(e);
            }
        }

        

        private static void GetCategoriasFake()
        {
            //(FontImageSource)Application.Current.Resources["icono_cat_misterio"]

            Categorias = new List<Categoria>
            {
                new Categoria {
                  Tipo="Misterio",
                  NumeroSalas = 500
                },
                new Categoria {
                  Tipo="Miedo",
                  NumeroSalas=350
                },
                 new Categoria {
                  Tipo="Niños",
                  NumeroSalas=100
                },
                 new Categoria {
                  Tipo="Familiar",
                  NumeroSalas=150
                }
            };
        }

        private static void GetPublicoFake()
        {
            Publico = new List<Publico>
            {
                new Publico {
                  Tipo="Estándar",
                  NumeroSalas= 500
                },
                new Publico {
                  Tipo="Familiar",
                  NumeroSalas=350
                },
                 new Publico {
                  Tipo="Empresas",
                  NumeroSalas=100
                },
                 new Publico {
                  Tipo="Niños",
                  NumeroSalas=150
                },
                  new Publico {
                  Tipo="Grupos grandes",
                  NumeroSalas=150
                }
            };
        }

        private static void GetDificultadesFake()
        {
            Dificultades = new List<Dificultad>
            {
                new Dificultad {
                  Tipo="Alta",
                  NumeroSalas=500
                },
                new Dificultad {
                  Tipo="Media",
                  NumeroSalas=350
                },
                 new Dificultad {
                  Tipo="Baja",
                  NumeroSalas=100
                }
            };
        }
    }


}
