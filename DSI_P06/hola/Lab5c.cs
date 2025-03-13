using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;

namespace Lab5c_namespace
{
    public class Lab5c : MonoBehaviour
    {
        List<Individuo> individuos;
        Individuo selecIndividuo;

        VisualElement tarjetal;
        VisualElement tarjeta2;
        VisualElement tarjeta3;
        VisualElement tarjeta4;

        TextField input_nombre;
        TextField Input_apellido;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjetal root.Q("Tarjeta1");
            tarjeta2 root.Q("Tarjeta2");
            tarjeta3 root.Q("Tarjeta3");
            tarjeta4 root.Q("Tarjeta4");

            input nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");

            individuos = Basedatos.getData();

            VisualElement panelDcha = root.Q("Dcha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

            InitializeUI();
        }

        void CambioNombre(ChangeEvent<string> evt)
        {
            selecIndividuo.Nombre = evt.newValue;
        }

        void CambioApellido(ChangeEvent<string> evt)
        {
            selecIndividuo.Apellido = evt.newValue;
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;
            selecIndividuo        = tarjeta.userData as Individuo;

            input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
            input_apellido.SetValueWithoutNotify(selecIndividuo.Apellido);
        }

        void InitializeUI()
        {
            Tarjeta tar1 = new Tarjeta(tarjetal, individuos[0]);
            Tarjeta tar2 = new Tarjeta(tarjeta2, individuos[1]);
            Tarjeta tar3 = new Tarjeta(tarjeta3, individuos[2]);
            Tarjeta tar4 = new Tarjeta(tarjeta4, individuos[3]);
        }
    }
}