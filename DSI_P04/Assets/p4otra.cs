using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class p4otra : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement rootve = GetComponent<UIDocument>().rootVisualElement;
        
        VisualElement top       = rootve.Q("Top");
        VisualElement bottom    = rootve.Q("Bottom");

        VisualTreeAsset template_cajas = Resources.Load<VisualTreeAsset>("Templates/ContenedorCajas");
        VisualElement cajasTop1        = template_cajas.Instantiate();
        VisualElement cajasTop2        = template_cajas.Instantiate();
        VisualElement cajasBottom      = template_cajas.Instantiate();

        top.Add(cajasTop1);
        top.Add(cajasTop2);
        bottom.Add(cajasBottom);

        /*
        for (int i = 0; i < 6; i++)
        {
            topChild = template_cajas.Instantiate();
            top.Add(topChild);
            bottom.Add(template_cajas.Instantiate());
        }
        */

        Sprite img = Resources.Load<Sprite>("Imagenes/georgia.png");

        VisualElement caja1 = cajasTop1.Q("Caja3").Q("ContenedorCajas").Q("Contenedor").Q("Caja1");

        caja1.style.backgroundImage = new StyleBackground(img);
    }
}