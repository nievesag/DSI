using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace p5c_namespace
{
    public class Basedatos
    {
        public static List<Individuo> getData()
        {

            VisualElement aux = new VisualElement();
            aux.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Imagenes/tortuga"));
            aux.style.width = 100;

            List<Individuo> datos = new List<Individuo>();

            Individuo perico = new Individuo(
                "Perico",
                "Palotes",
                aux
            );

            Individuo tornasol = new Individuo(
                "Torno",
                "Tornasolado",
                aux
            );

            Individuo luca = new Individuo(
                "Luca", 
                "Lucatelli",
                aux
            );

            Individuo ivan = new Individuo(
                "Ivan", 
                "Ivanovich",
                aux
            );

            datos.Add(perico); 
            datos.Add(tornasol); 
            datos.Add(luca); 
            datos.Add(ivan);
            
            return datos;
        }
    }
}