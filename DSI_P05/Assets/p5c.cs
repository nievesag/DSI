using UnityEngine.UIElements;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Windows;

namespace p5c_namespace
{
    public class p5c : MonoBehaviour
    {
        List<Individuo> individuos;
        Individuo selecIndividuo;

        VisualElement tarjeta1;
        VisualElement tarjeta2;
        VisualElement tarjeta3;
        VisualElement tarjeta4;

        VisualElement top1;
        VisualElement top2;
        VisualElement top3;
        VisualElement top4;

        TextField input_nombre;
        TextField input_apellido;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjeta1 = root.Q("Tarjeta1");
            tarjeta2 = root.Q("Tarjeta2");
            tarjeta3 = root.Q("Tarjeta3");
            tarjeta4 = root.Q("Tarjeta4");

            top1 = root.Q("top1");
            top2 = root.Q("top2");
            top3 = root.Q("top3");
            top4 = root.Q("top4");

            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");

            individuos = Basedatos.getData();

            VisualElement panelDcha = root.Q("Dcha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            VisualElement panelIzda = root.Q("Izda");
            panelIzda.RegisterCallback<ClickEvent>(seleccionImagen);

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
        void CambioImagen(ChangeEvent<string> evt)
        {
            selecIndividuo.Imagen = evt.newValue;
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;
            selecIndividuo = tarjeta.userData as Individuo;

            input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
            input_apellido.SetValueWithoutNotify(selecIndividuo.Apellido);
        }

        void seleccionImagen(ClickEvent e)
        {
            input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
        }

        void InitializeUI()
        {
            TarjetaC tar1 = new TarjetaC(tarjeta1, individuos[0]);
            TarjetaC tar2 = new TarjetaC(tarjeta2, individuos[1]);
            TarjetaC tar3 = new TarjetaC(tarjeta3, individuos[2]);
            TarjetaC tar4 = new TarjetaC(tarjeta4, individuos[3]);
        }
    }
}