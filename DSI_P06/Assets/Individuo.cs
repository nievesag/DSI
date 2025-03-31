using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace p6_namespace
{
    [System.Serializable]
    public class Individuo : MonoBehaviour
    {
        public event Action Cambio;

        
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
        [FormerlySerializedAs("Nombre")]
        [SerializeField] private string nombre;

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
        [FormerlySerializedAs("Apellido")]
        [SerializeField] private string apellido;


        public Individuo(string nombre, string apellido)
        {
            Debug.Log("Individuo creado");
            this.nombre = nombre;
            this.apellido = apellido;
        }
    }
}