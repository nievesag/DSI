using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class dsiFinal : MonoBehaviour
{

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

        Debug.Log("cakeTaste: " + cakeTaste);
        Debug.Log("sliderR: " + sliderR);

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
    }

    void ChangeColor(ChangeEvent<int> evt)
    {
        Debug.Log("ChangeColor");
        cakeTaste.style.backgroundColor = new StyleColor(new Color(sliderR.value / 255f, sliderG.value / 255f, sliderB.value / 255f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
