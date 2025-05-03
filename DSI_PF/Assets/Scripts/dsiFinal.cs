using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class dsiFinal : MonoBehaviour
{
    VisualElement objDeco1; // decoraciones
    VisualElement objDeco2; // velas

    VisualElement tarjeta; // tarjeta
    DropdownField tipoTarjeta; 

    VisualElement cakeTaste; // sabor tarta
    Slider sliderR;
    Slider sliderG;
    Slider sliderB;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // ------- Sabor
        cakeTaste = root.Q("CakeTaste");
        sliderR = root.Q<Slider>("SliderR");
        sliderG = root.Q<Slider>("SliderG");
        sliderB = root.Q<Slider>("SliderB");

        sliderR.RegisterCallback<ChangeEvent<float>>((evt) => {
            cakeTaste.style.backgroundColor 
                = new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));
        });

        sliderG.RegisterCallback<ChangeEvent<float>>((evt) => {
            cakeTaste.style.backgroundColor = 
                new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));
        });

        sliderB.RegisterCallback<ChangeEvent<float>>((evt) => {
            cakeTaste.style.backgroundColor =
                new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));
        });

        // ------- Decoraciones
        objDeco1 = root.Q("ObjDeco1");
        List<VisualElement> oD1List = objDeco1.Children().ToList();
        objDeco1.RegisterCallback<MouseDownEvent>(
        ev =>
        {
            // ha sido seleccionado antes
            if ((ev.target as VisualElement).style.unityBackgroundImageTintColor == Color.green) 
            {
                (ev.target as VisualElement).style.unityBackgroundImageTintColor = Color.white;
                root.Q("CakeFull").style.unityBackgroundImageTintColor = Color.white;
            }
            // no ha sido seleccionado
            else
            {
                (ev.target as VisualElement).style.unityBackgroundImageTintColor = Color.green;
                root.Q("CakeFull").style.unityBackgroundImageTintColor = Color.green;

                for (int i = 0; i < objDeco1.childCount; i++)
                {
                    if ((objDeco1[i].style.unityBackgroundImageTintColor == Color.green) &&
                        ((ev.target as VisualElement) != objDeco1[i]))
                    {
                        objDeco1[i].style.unityBackgroundImageTintColor = Color.white;
                    }
                }
            }
        });

        // ------- Velas
        objDeco2 = root.Q("velas");
        List<VisualElement> oD2List = objDeco2.Children().ToList();
        oD2List.ForEach(elem => elem.AddManipulator(new Dragger()));

        // ------- Tarjeta
        Sprite normal = Resources.Load<Sprite>("Images/tarjeta1");
        Sprite elegante = Resources.Load<Sprite>("Images/tarjeta2");
        Sprite punki = Resources.Load<Sprite>("Images/tarjeta3");

        tarjeta = root.Q<Label>("TarjetaIcon");
        tipoTarjeta = root.Q<DropdownField>("TipoEtiqueta");

        tipoTarjeta.RegisterValueChangedCallback(x =>
        {
            if (tipoTarjeta.index == 0)
            {
                tarjeta.style.backgroundImage = new StyleBackground(normal);
            }
            else if (tipoTarjeta.index == 1)
            {
                tarjeta.style.backgroundImage = new StyleBackground(elegante);
            }
            else if (tipoTarjeta.index == 2)
            {
                tarjeta.style.backgroundImage = new StyleBackground(punki);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
