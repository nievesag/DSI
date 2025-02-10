using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class p2 : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("coñete");
        
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        UQueryBuilder<VisualElement> builder = new(rootve);
        //List<VisualElement> lista_ve = builder.ToList();
        //List<VisualElement> lista_ve = rootve.Query().ToList();
        //List<VisualElement> lista_ve = rootve.Query(className: "azul").ToList();

        //VisualElement contenedor = builder.Name("mid");
        //List<VisualElement> lista_ve = contenedor.Children().ToList();

        // esto
        //VisualElement ve = rootve.Query(className: "azul").First();
        //Debug.Log(ve.name);
        //ve.AddToClassList("amarillo");
        // es equivalente a esto
        //VisualElement ve2 = rootve.Q(className: "azul");
        //Debug.Log(ve2.name);
        //ve2.AddToClassList("amarillo");

        // pone el último botón amarillo
        //VisualElement button = rootve.Query<Button>().Last();
        //Debug.Log(button.name);
        //button.AddToClassList("amarillo");
        // lo mismo pero de otra manera
        //VisualElement button = rootve.Query<Button>().AtIndex(1);
        //Debug.Log(button.name);
        //button.AddToClassList("amarillo");

        List<VisualElement> lista_contenedor = rootve.Query(className: "azul").ToList();
        List<VisualElement> lista_ve = lista_contenedor.SelectMany(elem => elem.Children())
            .Where(elem => elem.GetType() == typeof(Button)).ToList();
        lista_ve.ForEach(elem => {Debug.Log(elem.name); elem.AddToClassList("amarillo");});



        //lista_ve.ForEach(elem => Debug.Log(elem.name));
        //lista_ve.ForEach(elem => { Debug.Log(elem.name); elem.AddToClassList("amarillo");});
    }
}