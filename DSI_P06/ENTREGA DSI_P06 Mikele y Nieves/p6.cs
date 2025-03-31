using p6_namespace;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.VisualElement;
using static System.Collections.Specialized.BitVector32;

public class p6 : MonoBehaviour
{
    VisualElement botonCrear;
    VisualElement botonGuardar;

    Toggle toggleModificar;

    VisualElement contenedor_dcha;

    TextField input_nombre;

    TextField input_apellido;

    Individuo individuoSelec;

    VisualElement tarjetaSeleccionada;

    int defaultImgId = 0;

    VisualElement header;
    VisualElement header1;
    VisualElement header2;
    VisualElement header3;

    //ref a img para cabezeras
    private Texture2D headerImg01;
    private Texture2D headerImg02;
    private Texture2D headerImg03;

    List<Individuo> list_individuos = new List<Individuo>();

    string jsonPath;

    private void OnEnable() {

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        contenedor_dcha = root.Q("Dcha");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");
        botonCrear = root.Q("BotonCrear");
        botonGuardar = root.Q("BotonGuardar");
        toggleModificar = root.Q<Toggle>("ToggleModificar");

        header = root.Q("top");
        header1 = root.Q("cabeza1");
        header2 = root.Q("cabeza2");
        header3 = root.Q("cabeza3");
        headerImg01 = Resources.Load<Texture2D>("Imagenes/madrid");
        headerImg02 = Resources.Load<Texture2D>("Imagenes/cadiz");
        headerImg03 = Resources.Load<Texture2D>("Imagenes/chile");

        contenedor_dcha.RegisterCallback<ClickEvent>(SeleccionTarjeta);
        botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
        botonGuardar.RegisterCallback<ClickEvent>(Guardar);
        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
        header.RegisterCallback<ClickEvent>(CambioImagen);
        header1.RegisterCallback<ClickEvent>(CambioImagen);
        header2.RegisterCallback<ClickEvent>(CambioImagen);
        header3.RegisterCallback<ClickEvent>(CambioImagen);

        jsonPath = System.IO.Path.Combine(Application.persistentDataPath, "individuos");
    }

    void CambioNombre(ChangeEvent<string> evt)
    {
        if (toggleModificar.value)
        {
            individuoSelec.Nombre = evt.newValue;
        }
    }

    void CambioApellido(ChangeEvent<string> evt)
    {
        if (toggleModificar.value)
        {
            individuoSelec.Apellido = evt.newValue;
        }
    }

    void CambioImagen(ClickEvent e)
    {
        VisualElement imgClickada = e.target as VisualElement;
        header1.style.unityBackgroundImageTintColor = Color.white;
        header2.style.unityBackgroundImageTintColor = Color.white;
        header3.style.unityBackgroundImageTintColor = Color.white;
        imgClickada.style.unityBackgroundImageTintColor = Color.green;
        string aux = imgClickada.name[imgClickada.name.Length - 1] + "";
        defaultImgId = Int32.Parse(aux);
        defaultImgId--;

        if (tarjetaSeleccionada != null)
        {
            if (imgClickada != null)
            {
                VisualElement topTarjeta = tarjetaSeleccionada.Q("cabeza");

                if (imgClickada.name == "cabeza1")
                {
                    topTarjeta.style.backgroundImage = new StyleBackground(headerImg01);
                }
                else if (imgClickada.name == "cabeza2")
                {
                    topTarjeta.style.backgroundImage = new StyleBackground(headerImg02);
                }
                else if (imgClickada.name == "cabeza3")
                {
                    topTarjeta.style.backgroundImage = new StyleBackground(headerImg03);
                }
            }
        }
    }

    void NuevaTarjeta(ClickEvent evt) {
        if (!toggleModificar.value)
        {
            VisualTreeAsset plantilla = Resources.Load<VisualTreeAsset>("tarjeta");
            VisualElement tarjetaPlantilla = plantilla.Instantiate();
            
            contenedor_dcha.Add(tarjetaPlantilla);
            tarjetas_borde_negro();
            tarjetas_borde_blanco(tarjetaPlantilla);
            
            Individuo individuo = new Individuo(input_nombre.value, input_apellido.value);
            Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
            individuoSelec = individuo;
            tarjetaSeleccionada = tarjeta.tarjetaRoot;
            if (defaultImgId == 0)
                tarjetaSeleccionada.Q("cabeza").style.backgroundImage = new StyleBackground(headerImg01);
            else if (defaultImgId == 1)
                tarjetaSeleccionada.Q("cabeza").style.backgroundImage = new StyleBackground(headerImg02);
            else //(defaultImgId == 2)
                tarjetaSeleccionada.Q("cabeza").style.backgroundImage = new StyleBackground(headerImg03);
            list_individuos.Add(individuo);
            //list_individuos.ForEach(elem => {
            //    Debug.Log(elem.Nombre + " " + elem.Apellido);
            //    string jsonIndividuo = JsonUtility.ToJson(elem);
            //    Debug.Log(jsonIndividuo);
            //});
            string listaToJson = JsonHelperIndividuo.ToJson(list_individuos, true);

            List<Individuo> JsonToLista = JsonHelperIndividuo.FromJson<Individuo>(listaToJson);
            /*foreach (Individuo i in JsonToLista)
            {
                Debug.Log(i);
                Debug.Log(i.Nombre + " " + i.Apellido);
            }*/
        }
    }

    void Guardar(ClickEvent e)
    {
        string listaToJson = JsonHelperIndividuo.ToJson(list_individuos, true);
        System.IO.StreamWriter file = System.IO.File.CreateText(jsonPath);
        file.WriteLine(listaToJson);
        file.Close();
        Debug.Log(listaToJson);
    }

    void SeleccionTarjeta(ClickEvent e)
    {
        VisualElement miTarjeta = e.target as VisualElement;
        individuoSelec = miTarjeta.userData as Individuo;

        input_nombre.SetValueWithoutNotify(individuoSelec.Nombre);
        input_apellido.SetValueWithoutNotify(individuoSelec.Apellido);
        toggleModificar.value = true;

        tarjetas_borde_negro();
        tarjetas_borde_blanco(miTarjeta);

        tarjetaSeleccionada = e.target as VisualElement;
    }

    void tarjetas_borde_negro()
    {
        List<VisualElement> lista_tarjetas = contenedor_dcha.Children().ToList();
        lista_tarjetas.ForEach(elem =>
        {
            VisualElement tarjeta = elem.Q("Tarjeta");

            tarjeta.style.borderBottomColor = Color.black;
            tarjeta.style.borderRightColor = Color.black;
            tarjeta.style.borderTopColor = Color.black;
            tarjeta.style.borderLeftColor = Color.black;
        });
    }

    void tarjetas_borde_blanco(VisualElement tar)
    {
        VisualElement tarjeta = tar.Q("Tarjeta");

        tarjeta.style.borderBottomColor = Color.white;
        tarjeta.style.borderRightColor = Color.white;
        tarjeta.style.borderTopColor = Color.white;
        tarjeta.style.borderLeftColor = Color.white;
    }
}