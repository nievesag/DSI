using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class dsiFinal : MonoBehaviour
{
    VisualElement objDeco1; //slider
    VisualElement objDeco2; //velas

    VisualElement cakeTaste;
    Slider sliderR;
    Slider sliderG;
    Slider sliderB;

    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        cakeTaste = root.Q("CakeTaste");
        sliderR = root.Q<Slider>("SliderR");
        sliderG = root.Q<Slider>("SliderG");
        sliderB = root.Q<Slider>("SliderB");

        sliderR.RegisterCallback<ChangeEvent<float>>((evt) =>
        {
            cakeTaste.style.backgroundColor = new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));
        });
        sliderG.RegisterCallback<ChangeEvent<float>>((evt) =>
        {
            cakeTaste.style.backgroundColor = new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));
        });
        sliderB.RegisterCallback<ChangeEvent<float>>((evt) =>
        {
            cakeTaste.style.backgroundColor = new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f, 0.4f));        
        });

        objDeco1 = root.Q("ObjDeco1");
        List<VisualElement> oD1List = objDeco1.Children().ToList();
        objDeco1.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                if ((ev.target as VisualElement).style.unityBackgroundImageTintColor == Color.green) //ha sido seleccionado antes
                {
                    (ev.target as VisualElement).style.unityBackgroundImageTintColor = Color.white;
                    root.Q("CakeFull").style.unityBackgroundImageTintColor = Color.white;
                }
                else //no habia sido seleccionado
                {
                    (ev.target as VisualElement).style.unityBackgroundImageTintColor = Color.green;
                    root.Q("CakeFull").style.unityBackgroundImageTintColor = Color.green;
                }
            });


        objDeco2 = root.Q("MenuDeco2");
        List<VisualElement> oD2List = objDeco2.Children().ToList();
        oD2List.ForEach(elem => elem.AddManipulator(new Dragger()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
