using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
using static Unity.VisualScripting.LudiqRootObjectEditor;

public class dsiFinal : MonoBehaviour
{
    VisualElement objDeco1;     // menu decoraciones
    VisualElement objDeco2;     // menu velas

    // -- tarjeta
    Label tarjeta;              
    DropdownField tipoTarjeta;

    // -- sabor tarta
    VisualElement cakeTaste;    
    Slider sliderR;
    Slider sliderG;
    Slider sliderB;

    // -- guardar tarta
    TextField inputNombre;      
    DropdownField cargarNombre;
    Button guardarTarta;
    Button cargarTarta;

    // -- decoraciones
    VisualElement cereza;       // 0
    VisualElement estrella0;    // 1
    VisualElement arandanos;    // 2
    VisualElement flor2;        // 3
    VisualElement flor0;        // 4
    VisualElement fresa;        // 5
    VisualElement estrella1;    // 6
    VisualElement flor1;        // 7
    VisualElement sirope;       // 8
    VisualElement nata;         // 9
    VisualElement chocolate;    // 10


    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        // ------- Sabor
        cakeTaste = root.Q("CakeTaste");
        sliderR = root.Q<Slider>("SliderR");
        sliderG = root.Q<Slider>("SliderG");
        sliderB = root.Q<Slider>("SliderB");

        cakeTaste.style.backgroundColor
            = new StyleColor(new Color(0f, 0f, 0f, 0.4f));

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

        cereza = root.Q("cereza");          // 0
        estrella0 = root.Q("estrella0");    // 1
        arandanos = root.Q("arandanos");    // 2
        flor2 = root.Q("flor2");            // 3
        flor0 = root.Q("flor0");            // 4
        fresa = root.Q("fresa");            // 5
        estrella1 = root.Q("estrella1");    // 6
        flor1 = root.Q("flor1");            // 7
        sirope = root.Q("sirope");          // 8
        nata = root.Q("nata");              // 9
        chocolate = root.Q("chocolate");    // 10

        // para ocultar =>
        // chocolate.style.visibility = Visibility.Hidden;

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

        // ------- Guardar tarta
        inputNombre = root.Q<TextField>("NombreTarta");
        cargarNombre = root.Q<DropdownField>("Cargar");
        guardarTarta = root.Q<Button>("Guardar");
        cargarTarta = root.Q<Button>("CargarButton");
        List<string> nombres = new List<string>();

        guardarTarta.RegisterCallback<ClickEvent>(x =>
        {
            if ((nombres.Count() != 0) && (nombres.Last() != ""))
            {
                cargarNombre.choices.Add(nombres.Last());
                tarjeta.text = nombres.Last();
            }
        });

        cargarTarta.RegisterCallback<ClickEvent>(x =>
        {
            if(cargarNombre.index > -1)
            {
                tarjeta.text = cargarNombre.choices[cargarNombre.index];
            }
        });

        inputNombre.RegisterCallback<ChangeEvent<string>>(x =>
        {
            nombres.Add(x.newValue);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
