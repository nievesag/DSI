using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UIElements.VisualElement;
using UnityEngine.UIElements;
public class p4custom : VisualElement
{
    VisualElement dif0 = new VisualElement();
    VisualElement dif1 = new VisualElement();
    VisualElement dif2 = new VisualElement();
    VisualElement dif3 = new VisualElement();
    VisualElement dif4 = new VisualElement();
    VisualElement dif5 = new VisualElement();

    private Color gris = new Color(0.4f, 0.4f, 0.4f);
    private Color blanco = new Color(1f, 1f, 1f);

    Sprite img = Resources.Load<Sprite>("Imagenes/georgia");

    int estado;
    public int Estado
    {
        get => estado;
        set
        {
            estado = value;
            cambiarDificultad();
        }
    }

    string icon;
    public string Icon
    {
        get => icon;
        set
        {
            icon = value;
            cambiarDificultad();
        }
    }

    void cambiarDificultad()
    {
        // imagenes
        dif0.style.backgroundImage = new StyleBackground(img);
        dif1.style.backgroundImage = new StyleBackground(img);
        dif2.style.backgroundImage = new StyleBackground(img);
        dif3.style.backgroundImage = new StyleBackground(img);
        dif4.style.backgroundImage = new StyleBackground(img);
        dif5.style.backgroundImage = new StyleBackground(img);

        // colores
        dif0.style.unityBackgroundImageTintColor = gris;
        dif1.style.unityBackgroundImageTintColor = gris;
        dif2.style.unityBackgroundImageTintColor = gris;
        dif3.style.unityBackgroundImageTintColor = gris;
        dif4.style.unityBackgroundImageTintColor = gris;
        dif5.style.unityBackgroundImageTintColor = gris;

        // --- cambios de estado ---
        if (Estado == 0)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = gris;
            dif2.style.unityBackgroundImageTintColor = gris;
            dif3.style.unityBackgroundImageTintColor = gris;
            dif4.style.unityBackgroundImageTintColor = gris;
            dif5.style.unityBackgroundImageTintColor = gris;
        }

        if (Estado == 1)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = blanco;
            dif2.style.unityBackgroundImageTintColor = gris;
            dif3.style.unityBackgroundImageTintColor = gris;
            dif4.style.unityBackgroundImageTintColor = gris;
            dif5.style.unityBackgroundImageTintColor = gris;
        }

        if (Estado == 2)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = blanco;
            dif2.style.unityBackgroundImageTintColor = blanco;
            dif3.style.unityBackgroundImageTintColor = gris;
            dif4.style.unityBackgroundImageTintColor = gris;
            dif5.style.unityBackgroundImageTintColor = gris;
        }

        if (Estado == 3)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = blanco;
            dif2.style.unityBackgroundImageTintColor = blanco;
            dif3.style.unityBackgroundImageTintColor = blanco;
            dif4.style.unityBackgroundImageTintColor = gris;
            dif5.style.unityBackgroundImageTintColor = gris;
        }

        if (Estado == 4)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = blanco;
            dif2.style.unityBackgroundImageTintColor = blanco;
            dif3.style.unityBackgroundImageTintColor = blanco;
            dif4.style.unityBackgroundImageTintColor = blanco;
            dif5.style.unityBackgroundImageTintColor = gris;
        }

        if (Estado == 5)
        {
            dif0.style.unityBackgroundImageTintColor = blanco;
            dif1.style.unityBackgroundImageTintColor = blanco;
            dif2.style.unityBackgroundImageTintColor = blanco;
            dif3.style.unityBackgroundImageTintColor = blanco;
            dif4.style.unityBackgroundImageTintColor = blanco;
            dif5.style.unityBackgroundImageTintColor = blanco;
        }
    }

    public new class UxmlFactory : UxmlFactory<p4custom, UxmlTraits> { };

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription myEstado = new UxmlIntAttributeDescription { name = "estado", defaultValue = 0 };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var dificultad = ve as p4custom;
            dificultad.Estado = myEstado.GetValueFromBag(bag, cc);
            Debug.Log("dificultad.Estado: " + dificultad.Estado);
        }
    }

    public p4custom()
    {
        dif0.style.width = 100;
        dif0.style.height = 100;

        dif1.style.width = 100;
        dif1.style.height = 100;

        dif2.style.width = 100;
        dif2.style.height = 100;

        dif3.style.width = 100;
        dif3.style.height = 100;

        dif4.style.width = 100;
        dif4.style.height = 100;

        dif5.style.width = 100;
        dif5.style.height = 100;

        styleSheets.Add(Resources.Load<StyleSheet>("p4custom"));

        dif0.AddToClassList("panel_round");
        dif1.AddToClassList("panel_round");
        dif2.AddToClassList("panel_round");
        dif3.AddToClassList("panel_round");
        dif4.AddToClassList("panel_round");
        dif5.AddToClassList("panel_round");

        hierarchy.Add(dif0);
        hierarchy.Add(dif1);
        hierarchy.Add(dif2);
        hierarchy.Add(dif3);
        hierarchy.Add(dif4);
        hierarchy.Add(dif5);
    }

    /*
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
        panelRojo.style.width = 100;
        panelRojo.style.height = 100;

        panelAmbar.style.width = 100;
        panelAmbar.style.height = 100;

        panelVerde.style.width = 100;
        panelVerde.style.height = 100;

        styleSheets.Add(Resources.Load<StyleSheet>("p4custom"));
        
        panelRojo.AddToClassList("panel_round");
        panelAmbar.AddToClassList("panel_round");
        panelVerde.AddToClassList("panel_round");

        hierarchy.Add(panelRojo);
        hierarchy.Add(panelAmbar);
        hierarchy.Add(panelVerde);
    }
    */
}