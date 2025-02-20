using p5b_namespace;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

public class p5b : MonoBehaviour
{
    VisualElement plantilla;
    TextField input_nombre;
    TextField input_apellido;
    Individuo individuoPreba;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        plantilla = root.Q("plantilla");
        input_nombre = root.Q<TextField>("InputNombre");
        input_apellido = root.Q<TextField>("InputApellido");

        individuoPreba = new Individuo("Perico", "Palotes");

        Tarjeta tarjetaPrueba = new Tarjeta(plantilla, individuoPreba);

        input_nombre.RegisterCallback<ChangeEvent<string>>(CambioNombre);
        input_apellido.RegisterCallback<ChangeEvent<string>>(CambioApellido);

        input_nombre.SetValueWithoutNotify(individuoPreba.Nombre);
        input_apellido.SetValueWithoutNotify(individuoPreba.Apellido);
    }

    /*
    void SeleccionIndividuo(ClickEvent evt)
    {
        string nombre = plantilla.Q<Label>("Nombre").text;
        string apellido = plantilla.Q<Label>("Apellido").text;

        Debug.Log(nombre);

        input_nombre.SetValueWithoutNotify(nombre);
        input_apellido.SetValueWithoutNotify(apellido);
    }
    */

    void CambioNombre(ChangeEvent<string> evt)
    {
        /*
        Label nombreLabel = plantilla.Q<Label>("Nombre");
        nombreLabel.text = evt.newValue;
        */
        individuoPreba.Nombre = evt.newValue;
    }

    void CambioApellido(ChangeEvent<string> evt)
    {
        /*
        Label apellidoLabel = plantilla.Q<Label>("Apellido");
        apellidoLabel.text = evt.newValue;
        */
        individuoPreba.Apellido = evt.newValue;
    }
}