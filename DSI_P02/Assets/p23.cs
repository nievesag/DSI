using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class p23 : MonoBehaviour
{
    private VisualElement item1;


    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        item1 = rootve.Q("item1");
        Label texto = rootve.Q<Label>("texto");
        item1.style.backgroundColor = Color.white;
        texto.text =
            @"<line-indent=15%>En un lugar de <smallcaps>La Mancha</smallcaps> </line-indent><br> 
            de cuyo nombre <rotate=""45""> no quiero acordarme</rotate>,
            <b><gradient=""gradiente1"">no hacia mucho que vivia un hidalgo</gradient></b> 
            de los de lanza en astillero, 
            <b><color=""black""><gradient=""gradiente2"">adarga antigua</gradient></b>,
            <i>rocin flaco y galgo corredor.";
    }
}