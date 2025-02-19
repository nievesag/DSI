using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class p3b : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement izda = root.Q("ContenedorIzqda");
        VisualElement dcha = root.Q("ContenedorDrch");

        izda.AddManipulator(new p3bManipulator());
        dcha.AddManipulator(new p3bManipulator());

        
        List<VisualElement> lveizda = izda.Children().ToList();
        List<VisualElement> lvedcha = dcha.Children().ToList();
        lveizda.ForEach(elem => elem.AddManipulator(new p3bManipulator()));
        lvedcha.ForEach(elem => elem.AddManipulator(new p3bManipulator()));

        izda.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("Contenedor Izquierda. Fase: " + ev.propagationPhase);
                Debug.Log("Contenedor Izquierda.Target: " + (ev.target as VisualElement).name);
                (ev.target as VisualElement).style.backgroundColor = Color.green;
            }, TrickleDown.TrickleDown);

        dcha.RegisterCallback<MouseDownEvent>(
            ev =>
            {
                Debug.Log("Contenedor Derecha. Fase: " + ev.propagationPhase);
                Debug.Log("Contenedor Derecha. Target: " + (ev.target as VisualElement).name);
                    (ev.target as VisualElement).style.backgroundColor = Color.blue;
            }, TrickleDown.TrickleDown);
    }
}
