using AlkemyTest.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlkemyTest.Data
{
    public class DbSeeder
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) 
            {
                var context = serviceScope.ServiceProvider.GetService<DataContext>();


                //dont forget to run update database

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(new Character()
                    {
                        Name = "Mickey Mouse",
                        Image = "Image1.jpg",
                        Age = 100,
                        Weight = 40,
                        History = "Mickey Mouse is a cartoon character created in 1928 at Walt Disney Animation Studios. The character serves as the mascot of The Walt Disney Company."

                    },
                    new Character()
                    {
                        Name = "Simba",
                        Image = "Image2.jpg",
                        Age = 15,
                        Weight = 120,
                        History = "Simba es el protagonista de la película The Lion King. Hijo de Mufasa y Sarabi, Simba fue el siguiente a su padre en la línea para gobernar las Tierras del Reino."

                    },
                    new Character()
                    {
                        Name = "Elsa",
                        Image = "Image3.jpg",
                        Age = 18,
                        Weight = 55,
                        History = "Elsa es un personaje que apareció en el clásico número 53 del canon de la compañía cinematográfica Walt Disney Pictures, Frozen. Y, en el año 2019 protagonista de Frozen 2.2​ Fue interpretada por la actriz y cantante de Broadway Idina Menzel. En el principio de la película, fue interpretada por Eva Bella cuando era niña y por Spencer Lacey Ganus cuando era adolescente."

                    },
                    new Character()
                    {
                        Name = "Stitch",
                        Image = "Image4.jpg",
                        Age = 626,
                        Weight = 25,
                        History = "Conocido Como Experimento 626 , Es El protagonista de la saga. Es un pequeño alienígena azul que fue creado por el Dr. Jumba Jookiba , siendo el resultado 626. Él fue creado con un instinto de destilación todo lo que toca, pero el día que conocio a Lilo y se hizo una buena amistad con ella, comienza una covertirse en un ser bueno."

                    },
                    new Character()
                    {
                        Name = "Olaf",
                        Image = "Image5.jpg",
                        Age = 1,
                        Weight = 38,
                        History = "Olaf el muñeco de nieve (conocido simplemente como Olaf) es uno de los personajes principales de película de animación  Frozen. Está basado en un muñeco de nieve que creo Elsa pero cobró vida con sus poderes."

                    });

                    context.SaveChanges();

                }

                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new Movie()
                    {
                        Image = "Image_Movie1.jpg",
                        Title = "Fantasia",
                        CreatedAt = DateTime.Parse("13 / 10 / 1940"),
                        Qualification = 3

                    },
                    new Movie()
                    {
                        Image = "Image_Movie2.jpg",
                        Title = "Frozen",
                        CreatedAt = DateTime.Parse("02 / 01 / 2014"),
                        Qualification = 5

                    },
                    new Movie()
                    {
                        Image = "Image_Movie3.jpg",
                        Title = "Steamboat Willie",
                        CreatedAt = DateTime.Parse("18 / 10 / 1928"),
                        Qualification = 5

                    },
                    new Movie()
                    {
                        Image = "Image_Movie4.jpg",
                        Title = "Dumbo",
                        CreatedAt = DateTime.Parse("23 / 10 / 1941"),
                        Qualification = 5

                    },
                    new Movie()
                    {
                        Image = "Image_Movie5.jpg",
                        Title = "The Lion King",
                        CreatedAt = DateTime.Parse("15 / 6 / 1994"),
                        Qualification = 5

                    },
                    new Movie()
                    {
                        Image = "Image_Movie6.jpg",
                        Title = "Raya and the Last Dragon",
                        CreatedAt = DateTime.Parse("5 / 3 / 2021"),
                        Qualification = 5

                    });
                    context.SaveChanges();

                    

                }

                if (!context.Genres.Any())
                {
                    context.Genres.AddRange(new Genre()
                    {
                        Image = "Image_Fantasy.jpg",
                        Name = "fantasy",
                    },
                    new Genre()
                    {
                        Image = "Image_Romance.jpg",
                        Name = "Romance"
                    },
                    new Genre()
                    {
                        Image = "Image_Terror.jpg",
                        Name = "Terror"
                    },
                    new Genre()
                    {
                        Image = "Image_Adventure.jpg",
                        Name = "Adventure",
                    },
                    new Genre()
                    {
                        Image = "Image_Action.jpg",
                        Name = "Action"
                    });
                    context.SaveChanges();

                }
            }
        }
    }
}
