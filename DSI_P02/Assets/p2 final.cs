using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class p2final : MonoBehaviour
{
    // pestanya
    private VisualElement pes1;
    private VisualElement pes2;

    // contenido
    private VisualElement con1;
    private VisualElement con2;
    private void NoContenido()
    {
        con1.style.display = DisplayStyle.None;
        con2.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement contenido = rootve.Q("contenido");
        VisualElement pestanyas = rootve.Q("pestanyas");

        pes1 = pestanyas.Q("pes1");
        pes2 = pestanyas.Q("pes2");

        con1 = contenido.Q("con1");
        con2 = contenido.Q("con2");

        pes1.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña trucos");
            NoContenido();
            con1.style.display = DisplayStyle.Flex;
        });

        pes2.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("Pestaña nv1");
            NoContenido();
            con2.style.display = DisplayStyle.Flex;
        });

        con2 = rootve.Q("con2");
        Label texto = rootve.Q<Label>("texto");
        con2.style.backgroundColor = Color.white;
        texto.text =
            @"<line-indent=15%>Aún no tienes suficiente <smallcaps>NiVeL</smallcaps> para desbloquear estos conjuros</line-indent><br> 
            Necesitas más <rotate=""45""> experiencia</rotate><br>
            para <b><gradient=""gradiente1"">desbloquearlos</gradient></b><br>
            Consíguela <b><color=""black""><gradient=""gradiente2"">jugando más</gradient></b><br>
            <i>¡Mucho ánimo!";
    }
}
