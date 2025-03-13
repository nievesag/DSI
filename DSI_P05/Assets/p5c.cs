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

        VisualElement tarjetaSeleccionada = null;

        VisualElement izda;
        VisualElement header;
        VisualElement header1;
        VisualElement header2;
        VisualElement header3;

        TextField input_nombre;
        TextField input_apellido;

        //ref a img para cabezeras
        private Texture2D headerImg01;
        private Texture2D headerImg02;
        private Texture2D headerImg03;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;

            tarjeta1 = root.Q("Tarjeta1");
            tarjeta2 = root.Q("Tarjeta2");
            tarjeta3 = root.Q("Tarjeta3");
            tarjeta4 = root.Q("Tarjeta4");

            izda = root.Q("izda");
            header = root.Q("header");
            header1 = root.Q("cabeza1");
            header2 = root.Q("cabeza2");
            header3 = root.Q("cabeza3");


            input_nombre = root.Q<TextField>("InputNombre");
            input_apellido = root.Q<TextField>("InputApellido");

            individuos = Basedatos.getData();

            headerImg01 = Resources.Load<Texture2D>("Imagenes/madrid");
            headerImg02 = Resources.Load<Texture2D>("Imagenes/cadiz");
            headerImg03 = Resources.Load<Texture2D>("Imagenes/chile");

            VisualElement panelDcha = root.Q("Dcha");
            panelDcha.RegisterCallback<ClickEvent>(seleccionTarjeta);

            input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
            input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
            izda.RegisterCallback<ClickEvent>(CambioImagen);
            header.RegisterCallback<ClickEvent>(CambioImagen);
            header1.RegisterCallback<ClickEvent>(CambioImagen);
            header2.RegisterCallback<ClickEvent>(CambioImagen);
            header3.RegisterCallback<ClickEvent>(CambioImagen);

            if (headerImg01 == null) Debug.Log("No se ha cargado la imagen 1");
            if (headerImg02 == null) Debug.Log("No se ha cargado la imagen 2");
            if (headerImg03 == null) Debug.Log("No se ha cargado la imagen 3");

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
        void CambioImagen(ClickEvent e)
        {
            Debug.Log("CambioImagen");
            if (tarjetaSeleccionada != null)
            {
                Debug.Log("tarjetaSeleccionada != null");
                VisualElement imgClickada = e.target as VisualElement;
                if (imgClickada != null)
                {
                    VisualElement topTarjeta = tarjetaSeleccionada.Q("top");

                    if (imgClickada.name == "cabeza1")
                    {
                        Debug.Log("imgClickada = 1 y topTarjeta.name = " + topTarjeta.name);
                        topTarjeta.style.backgroundImage = new StyleBackground(headerImg01);
                    }
                    else if (imgClickada.name == "cabeza2")
                    {
                        Debug.Log("imgClickada = 2 y topTarjeta.name = " + topTarjeta.name);
                        topTarjeta.style.backgroundImage = new StyleBackground(headerImg02);
                    }
                    else if (imgClickada.name == "cabeza3")
                    {
                        Debug.Log("imgClickada = 3 y topTarjeta.name = " + topTarjeta.name);
                        topTarjeta.style.backgroundImage = new StyleBackground(headerImg03);
                    }
                }
            }
        }

        void seleccionTarjeta(ClickEvent e)
        {
            VisualElement tarjeta = e.target as VisualElement;
            selecIndividuo = tarjeta.userData as Individuo;

            input_nombre.SetValueWithoutNotify(selecIndividuo.Nombre);
            input_apellido.SetValueWithoutNotify(selecIndividuo.Apellido);

            tarjetaSeleccionada = e.target as VisualElement;
            Debug.Log("Seleccionada tarjeta de " + selecIndividuo.Nombre + " " + selecIndividuo.Apellido);
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