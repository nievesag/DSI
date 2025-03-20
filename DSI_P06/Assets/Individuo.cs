using System;
using UnityEngine;

namespace p6_namespace
{
    [System.Serializable]
    public class Individuo : MonoBehaviour
    {
        public event Action Cambio;

        [SerializeField] private string nombre;
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

        [SerializeField] private string apellido;
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

        public Individuo(string nombre, string apellido)
        {
            Debug.Log("Individuo creado");
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}