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

        VisualTreeAsset template_cajas = Resources.Load<VisualTreeAsset>("Templates/Elementos");

        VisualElement cajasTop1        = template_cajas.Instantiate();

        top.Add(cajasTop1);

        Sprite img0 = Resources.Load<Sprite>("Imagenes/georgia");
        Sprite img1 = Resources.Load<Sprite>("Imagenes/madrid");
        Sprite img2 = Resources.Load<Sprite>("Imagenes/chile");
        Sprite img3 = Resources.Load<Sprite>("Imagenes/cadiz");
        Sprite img4 = Resources.Load<Sprite>("Imagenes/china");
        Sprite img5 = Resources.Load<Sprite>("Imagenes/filipinas");

        VisualElement caja0 = cajasTop1.Q("caja0");
        VisualElement caja1 = cajasTop1.Q("caja1");
        VisualElement caja2 = cajasTop1.Q("caja2");
        VisualElement caja3 = cajasTop1.Q("caja3");
        VisualElement caja4 = cajasTop1.Q("caja4");
        VisualElement caja5 = cajasTop1.Q("caja5");

        caja0.style.backgroundImage = new StyleBackground(img0);
        caja1.style.backgroundImage = new StyleBackground(img1);
        caja2.style.backgroundImage = new StyleBackground(img2);
        caja3.style.backgroundImage = new StyleBackground(img3);
        caja4.style.backgroundImage = new StyleBackground(img4);
        caja5.style.backgroundImage = new StyleBackground(img5);
    }
}