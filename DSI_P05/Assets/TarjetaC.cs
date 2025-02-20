using p5b_namespace;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;
using Label = UnityEngine.UIElements.Label;

namespace p5c_namespace
{
    public class TarjetaC
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;

        public TarjetaC(VisualElement tr, Individuo individuo)
        {
            tarjetaRoot = tr;
            miIndividuo = individuo;

            nombreLabel = tr.Q<Label>("Nombre");
            apellidoLabel = tr.Q<Label>("Apellido");

            tr.userData = miIndividuo;

            tr
                    .Query(className: "tarjeta")
                    .Descendents<VisualElement>()
                    .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

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