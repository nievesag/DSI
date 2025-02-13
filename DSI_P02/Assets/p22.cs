using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class p22 : MonoBehaviour
{
    private VisualElement contenido_azul;
    private VisualElement contenido_verde;
    private VisualElement contenido_ambar;
    private VisualElement pestanya_azul;
    private VisualElement pestanya_verde;
    private VisualElement pestanya_ambar;

    private void NoContenido()
    {
        contenido_azul.style.display  = DisplayStyle.None;
        contenido_verde.style.display = DisplayStyle.None;
        contenido_ambar.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement contenido = rootve.Q("contenido");
        VisualElement pestanyas = rootve.Q("pestanyas");

        pestanya_azul = pestanyas.Q("azul");
        pestanya_verde = pestanyas.Q("verde");
        pestanya_ambar = pestanyas.Q("ambar");

        contenido_azul = contenido.Q("azul");
        contenido_verde = contenido.Q("verde");
        contenido_ambar = contenido.Q("ambar");

        pestanya_azul.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña azul");
            NoContenido();
            contenido_azul.style.display = DisplayStyle.Flex;
        });

        pestanya_verde.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña verde");
            NoContenido();
            contenido_verde.style.display = DisplayStyle.Flex;
        });

        pestanya_ambar.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña ámbar");
            NoContenido();
            contenido_ambar.style.display = DisplayStyle.Flex;
        });
    }
}