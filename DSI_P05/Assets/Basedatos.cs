using UnityEngine;
using System.Collections.Generic;

namespace p5c_namespace
{
    public class Basedatos
    {
        public static List<Individuo> getData()
        {
            List<Individuo> datos = new List<Individuo>();

            Individuo perico = new Individuo(
                "Perico",
                "Palotes",
                "georgia"
            );

            Individuo tornasol = new Individuo(
                "Tornasol",
                "Tornasolado",
                "filipinas"
            );

            Individuo luca = new Individuo(
                "Luca", 
                "Lucatelli",
                "china"
            );

            Individuo ivan = new Individuo(
                "Ivan", 
                "Ivanovich",
                "chile"
            );

            datos.Add(perico); 
            datos.Add(tornasol); 
            datos.Add(luca); 
            datos.Add(ivan);
            
            return datos;
        }
    }
}