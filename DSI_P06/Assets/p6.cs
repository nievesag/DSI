using p6_namespace;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.UIElements.VisualElement;

public class p6 : MonoBehaviour
{
    VisualElement botonCrear;

    Toggle toggleModificar;

    VisualElement contenedor_dcha;

    TextField input_nombre;

    TextField input_apellido;

    Individuo individuoSelec;

    List<Individuo> list_individuos = new List<Individuo>();
    private void OnEnable() {

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        contenedor_dcha = root.Q("Dcha");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");
        botonCrear = root.Q("BotonCrear");
        toggleModificar = root.Q<Toggle>("ToggleModificar");

        contenedor_dcha.RegisterCallback<ClickEvent>(SeleccionTarjeta);
        botonCrear.RegisterCallback<ClickEvent>(NuevaTarjeta);
        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);
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

            list_individuos.Add(individuo);
            //list_individuos.ForEach(elem => {
            //    Debug.Log(elem.Nombre + " " + elem.Apellido);
            //    string jsonIndividuo = JsonUtility.ToJson(elem);
            //    Debug.Log(jsonIndividuo);
            //});
            //ASÍ SOLO PRINTEA EL INSTANCEID FOOOK
            //queremos la info dentro d los individuos
            string listaToJson = JsonHelperIndividuo.ToJson(list_individuos, true);
            Debug.Log(listaToJson);
        }
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