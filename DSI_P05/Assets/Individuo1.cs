using System;
using UnityEngine;

namespace p5c_namespace
{
    public class Individuo
    {
        public event Action Cambio;

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value != nombre)
                {
                    nombre = value;
                    Cambio?.Invoke();
                }
            }
        }

        private string apellido;
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value != apellido)
                {
                    apellido = value;
                    Cambio?.Invoke();
                }
            }
        }

        private string imagen;
        public string Imagen
        {
            get { return imagen; }
            set
            {
                if (value != imagen)
                {
                    imagen = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Individuo(string nombre, string apellido, string imagen)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.imagen = imagen;
        }
    }
}