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
    private Color rosa = new Color(1f, 0.408f, 0.624f, 0.9f);


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

        List<VisualElement> oD1List = objDeco1.Children().ToList();
        objDeco1.RegisterCallback<MouseDownEvent>(
        ev =>
        {
            // ha sido seleccionado antes
            if ((ev.target as VisualElement).style.unityBackgroundImageTintColor == rosa) 
            {
                (ev.target as VisualElement).style.unityBackgroundImageTintColor = Color.white;

                VisualElement aux = null;
                switch ((ev.target as VisualElement).name)
                {
                    case "00": aux = nata; break;
                    case "01": aux = chocolate; break;
                    case "02": aux = sirope; break;
                    case "03": aux = fresa; break;
                    case "04": aux = cereza; break;
                    case "05": aux = arandanos; break;
                    case "06": aux = flor0; break;
                    case "07": aux = flor1; break;
                    case "08": aux = flor2; break;
                    case "09": aux = estrella0; break;
                    case "010": aux = estrella1; break;
                }
                aux.style.visibility = Visibility.Hidden; // se oculta

            }
            // no ha sido seleccionado
            else
            {
                (ev.target as VisualElement).style.unityBackgroundImageTintColor = rosa;

                VisualElement aux = null;
                switch ((ev.target as VisualElement).name)
                {
                    case "00": aux = nata; break;
                    case "01": aux = chocolate; break;
                    case "02": aux = sirope; break;
                    case "03": aux = fresa; break;
                    case "04": aux = cereza; break;
                    case "05": aux = arandanos; break;
                    case "06": aux = flor0; break;
                    case "07": aux = flor1; break;
                    case "08": aux = flor2; break;
                    case "09": aux = estrella0; break;
                    case "010": aux = estrella1; break;
                }
                aux.style.visibility = Visibility.Visible; // se muestra

                // HOLA
                // no se si queremos que se queden seleccionados???? igual con el funcionamiento de ahora si????
                // limpia los ya seleccionados (deja solo el ultimo)
                /*
                for (int i = 0; i < objDeco1.childCount; i++)
                {
                    if ((objDeco1[i].style.unityBackgroundImageTintColor == rosa) &&
                        ((ev.target as VisualElement) != objDeco1[i]))
                    {
                        objDeco1[i].style.unityBackgroundImageTintColor = Color.white;
                    }
                }
                */
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
                GuardarJson(nombres.Last());
            }
        });

        cargarTarta.RegisterCallback<ClickEvent>(x =>
        {
            if(cargarNombre.index > -1)
            {
                tarjeta.text = cargarNombre.choices[cargarNombre.index];
                CargarJson(tarjeta.text);
            }
        });

        inputNombre.RegisterCallback<ChangeEvent<string>>(x =>
        {
            nombres.Add(x.newValue);
            tarjeta.text = x.newValue;
        });
    }

    void GuardarJson(string tartaName)
    {
        string jsonPath = System.IO.Path.Combine(Application.persistentDataPath, tartaName);

        TartaData tarta = new TartaData();
        tarta.Nombre = tartaName;
        tarta.r = sliderR.value;
        tarta.g = sliderG.value;
        tarta.b = sliderB.value;
        tarta.TarjetaType = tipoTarjeta.index;
        string toTxt = JsonUtility.ToJson(tarta);

        System.IO.StreamWriter file = System.IO.File.CreateText(jsonPath);
        file.WriteLine(toTxt);
        file.Close();
    }

    void CargarJson(string tartaName)
    {
        string jsonPath = System.IO.Path.Combine(Application.persistentDataPath, tartaName);
        if (System.IO.File.Exists(jsonPath))
        {
            string jsonString = System.IO.File.ReadAllText(jsonPath);
            TartaData tarta = JsonUtility.FromJson<TartaData>(jsonString);
            sliderR.value = tarta.r;
            sliderG.value = tarta.g;
            sliderB.value = tarta.b;
            tipoTarjeta.index = tarta.TarjetaType;
        }
    }
}

[System.Serializable]
public class TartaData
{
    public string Nombre;
    public float r;
    public float g;
    public float b;
    public int TarjetaType;
}
