using p5b_namespace;
using p5c_namespace;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class p5 : MonoBehaviour
{
    VisualElement botonCrear;

    Toggle toggleModificar;

    VisualElement contenedor_dcha;

    TextField input_nombre;

    TextField input_apellido;

    Individuo individuoSelec;

    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        botonCrear = root.Q("BotonCrear");
        toggleModificar = root.Q<Toggle>("ToggleModificar");
        contenedor_dcha = root.Q("Dcha");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");

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
            Individuo individuo = new Individuo(input_nombre.value, input_apellido.value);
            Tarjeta tarjeta = new Tarjeta(tarjetaPlantilla, individuo);
            individuoSelec = individuo;
        }
    }
}