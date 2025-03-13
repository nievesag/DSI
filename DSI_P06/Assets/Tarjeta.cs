using p5b_namespace;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;

namespace p5c_namespace
{
    public class Tarjeta
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;

        public Tarjeta(VisualElement tr, Individuo individuo)
        {
            tarjetaRoot = tr;
            miIndividuo = individuo;

            nombreLabel = tr.Q<Label>("Nombre");
            apellidoLabel = tr.Q<Label>("Apellido");

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text = miIndividuo.Nombre;
            apellidoLabel.text = miIndividuo.Apellido;
        }
    }
}