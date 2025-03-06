using System;
using UnityEngine;
using UnityEngine.UIElements;

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

        private VisualElement imagen;
        public VisualElement Imagen
        {
            get { return imagen; }
            set
            {
                if (value != imagen)
                {
                    Debug.Log("set imagen " + value);
                    imagen = value;
                    Cambio?.Invoke();
                }
            }
        }

        public Individuo(string nombre, string apellido, VisualElement imagen)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.imagen = imagen;
            Debug.Log("Imagen " + imagen);
            //imagen.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>("Imagenes/tortuga"));
        }
    }
}