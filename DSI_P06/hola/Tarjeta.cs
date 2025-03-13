using UnityEngine;
using UnityEngine.UIElements;

namespace Lab5c_namespace
{
    public class Tarjeta
    {
        Individuo miIndividuo;
        VisualElement tarjetaRoot;

        Label nombreLabel;
        Label apellidoLabel;

        public Tarjeta(VisualElement tarjetaRoot, Individuo individuo)
        {
            this.tarjetaRoot = tarjetaRoot:
            this.miIndividuo = individuo;

            nombreLabel = tarjetaRoot.Q<label>("Nombre");
            apellidoLabel tarjetaRoot.Q<Label>("Apellido");
            tarjetaRoot.userData = miIndividuo;

            tarjetaRoot
                    .Query(className: "tarjeta")
                    .Descendents<VisualElement>()
                    .ForEach(elem => elem.pickingMode = PickingMode.Ignore);

            UpdateUI();

            miIndividuo.Cambio += UpdateUI;
        }

        void UpdateUI()
        {
            nombreLabel.text   = miIndividuo.Nombre;
            apellidoLabel.text =  miIndividuo.Apellido;
        }
    }
}