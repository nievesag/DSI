using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace p6_namespace
{
    public static class JsonHelperIndividuo
    {
        public static List<Individuo> FromJson<Individuo>(string jsonTxt)
        {
            ListaIndividuo<Individuo> listaIndividuo = JsonUtility.FromJson<ListaIndividuo<Individuo>>(jsonTxt);
            return listaIndividuo.Individuos; 
        }

        public static string ToJson<Individuo>(List<Individuo> lista)
        {
            ListaIndividuo<Individuo> listaIndividuo = new ListaIndividuo<Individuo>();
            listaIndividuo.Individuos = lista;
            string jsonTxt = "{\n\"Individuos\": [\n";
            foreach (Individuo i in lista)
            {
                jsonTxt += JsonUtility.ToJson(i);
                jsonTxt += ",\n";
            }
            jsonTxt = jsonTxt.Substring(0, jsonTxt.Length - 2);
            jsonTxt += "\n]\n}";
            return jsonTxt;
        }
        public static string ToJson<Individuo>(List<Individuo> lista, bool prettyPrint)
        {
            ListaIndividuo<Individuo> listaIndividuo = new ListaIndividuo<Individuo>();
            listaIndividuo.Individuos = lista;
            string jsonTxt = "{\n\"Individuos\": [\n";
            foreach (Individuo i in lista)
            {
                jsonTxt += JsonUtility.ToJson(i, prettyPrint);
                jsonTxt += ",\n";
            }
            jsonTxt = jsonTxt.Substring(0, jsonTxt.Length - 2);
            jsonTxt += "\n]\n}";
            return jsonTxt;
        }

        [System.Serializable]
        public class ListaIndividuo<Individuo>
        {
            [SerializeField]
            public List<Individuo> Individuos;
        }
    }
}