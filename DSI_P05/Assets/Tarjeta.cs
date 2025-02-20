using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace p5b_namespace
{
    public class Tarjeta : MonoBehaviour
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;
        Label nombreLabel;
        Label apellidoLabel;

        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot;
            this.miIndividuo = individuo;
            nombreLabel = tarjetaRoot.Q<Label>("Nombre");
            apellidoLabel = tarjetaRoot.Q<Label>("Apellido");

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text  =  miIndividuo.Nombre;
            apellidoLabel.text = miIndividuo.Apellido;
        }
    }
}
