using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class p3 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement verde = root.Q("ContenedorVerde");
        VisualElement azul = root.Q("ContenedorAzul");
        VisualElement amarillo = root.Q("ItemAmarillo");

        verde.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("“Contenedor Verde. Fase: " + ev.propagationPhase);
                Debug.Log("“Contenedor Verde. Current target: " + (ev.currentTarget as VisualElement).name);
                Debug.Log("“Contenedor Verde. Target: " + (ev.target as VisualElement).name);
            }/*, TrickleDown.NoTrickleDown*/);

        azul.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("“Contenedor Azul. Fase: " + ev.propagationPhase);
                Debug.Log("“Contenedor Azul. Current target: " + (ev.currentTarget as VisualElement).name);
                Debug.Log("“Contenedor Azul. Target: " + (ev.target as VisualElement).name);
            });

        amarillo.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("Contenedor Amarillo. Fase: " + ev.propagationPhase);
                Debug.Log("“Contenedor Amarillo. Current target: " + (ev.currentTarget as VisualElement).name);
                Debug.Log("“Contenedor Amarillo. Target: " + (ev.target as VisualElement).name);
            });
    }
}

