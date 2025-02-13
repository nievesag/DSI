using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.VisualElement;
using UnityEngine.UIElements;

public class p4custom : VisualElement
{
    VisualElement panelRojo = new VisualElement();
    VisualElement panelAmbar = new VisualElement();
    VisualElement panelVerde = new VisualElement();

    int estado;

    public int Estado
    {
        get => estado;
        set
        {
            estado = value;
            encenderColor();
        }
    }
        void encenderColor()
        {
        panelRojo.style.backgroundColor = new Color(0.27f, 0f, 0f);
        panelAmbar.style.backgroundColor = new Color(0.27f, 0.27f, 0f);
        panelVerde.style.backgroundColor = new Color(0f, 0.27f, 0f);

        if (Estado == 0) { panelRojo.style.backgroundColor = Color.red; }
        if (Estado == 1) { panelAmbar.style.backgroundColor = Color.yellow; }
        if (Estado > 1) { panelVerde.style.backgroundColor = Color.green; }
    }

    public new class UxmlFactory : UxmlFactory<p4custom, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEstado = new UxmlIntAttributeDescription { name = "estado", defaultValue = 0 };

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);
                var semaforo = ve as p4custom;
                semaforo.Estado = myEstado.GetValueFromBag(bag, cc);
                Debug.Log("semaforo.Estado: " + semaforo.Estado);
            }
    }

    public p4custom()
    {
    /*
        VisualElement panelRojo = new VisualElement();
        VisualElement panelAmbar = new VisualElement();
        VisualElement panelVerde = new VisualElement();
    */
            
        panelRojo.style.width = 100;
        panelRojo.style.height = 100;
        //panelRojo.style.backgroundColor = Color.red;

        panelAmbar.style.width = 100;
        panelAmbar.style.height = 100;
        //panelAmbar.style.backgroundColor = Color.yellow;

        panelVerde.style.width = 100;
        panelVerde.style.height = 100;
        //panelVerde.style.backgroundColor = Color.green;

        styleSheets.Add(Resources.Load<StyleSheet>("p4custom"));
        
        panelRojo.AddToClassList("panel_round");
        panelAmbar.AddToClassList("panel_round");
        panelVerde.AddToClassList("panel_round");

        hierarchy.Add(panelRojo);
        hierarchy.Add(panelAmbar);
        hierarchy.Add(panelVerde);
    }
}