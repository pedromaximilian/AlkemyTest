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
                        Image = "Image 1",
                        Age = 100,
                        Weight = 40,
                        History = "Mickey Mouse is a cartoon character created in 1928 at Walt Disney Animation Studios. The character serves as the mascot of The Walt Disney Company."

                    },
                    new Character()
                    {
                        Name = "Simba",
                        Image = "Image 2",
                        Age = 15,
                        Weight = 120,
                        History = "Simba es el protagonista de la película The Lion King. Hijo de Mufasa y Sarabi, Simba fue el siguiente a su padre en la línea para gobernar las Tierras del Reino."

                    },
                    new Character()
                    {
                        Name = "Elsa",
                        Image = "Image 3",
                        Age = 18,
                        Weight = 55,
                        History = "Elsa es un personaje que apareció en el clásico número 53 del canon de la compañía cinematográfica Walt Disney Pictures, Frozen. Y, en el año 2019 protagonista de Frozen 2.2​ Fue interpretada por la actriz y cantante de Broadway Idina Menzel. En el principio de la película, fue interpretada por Eva Bella cuando era niña y por Spencer Lacey Ganus cuando era adolescente."

                    },
                    new Character()
                    {
                        Name = "Stitch",
                        Image = "Image 4",
                        Age = 626,
                        Weight = 25,
                        History = "Conocido Como Experimento 626 , Es El protagonista de la saga. Es un pequeño alienígena azul que fue creado por el Dr. Jumba Jookiba , siendo el resultado 626. Él fue creado con un instinto de destilación todo lo que toca, pero el día que conocio a Lilo y se hizo una buena amistad con ella, comienza una covertirse en un ser bueno."

                    },
                    new Character()
                    {
                        Name = "Olaf",
                        Image = "Image 5",
                        Age = 1,
                        Weight = 38,
                        History = "Olaf el muñeco de nieve (conocido simplemente como Olaf) es uno de los personajes principales de película de animación  Frozen. Está basado en un muñeco de nieve que creo Elsa pero cobró vida con sus poderes."

                    });

                    context.SaveChanges();

                }
            }
        }
    }
}
