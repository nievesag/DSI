using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace p6_namespace
{
    public static class JsonHelperIndividuo
    {
        public static List<Individuo> FromJson<Individuo>(string json)
        {
            ListaIndividuo<Individuo> listaIndividuo = JsonUtility.FromJson<ListaIndividuo<Individuo>>(json);
            return listaIndividuo.Individuos; 
        }

        public static string ToJson<Individuo>(List<Individuo> lista)
        {
            ListaIndividuo<Individuo> listaIndividuo = new ListaIndividuo<Individuo>();
            listaIndividuo.Individuos = lista;
            return JsonUtility.ToJson(listaIndividuo);
        }
        public static string ToJson<Individuo>(List<Individuo> lista, bool prettyPrint)
        {
            ListaIndividuo<Individuo> listaIndividuo = new ListaIndividuo<Individuo>();
            listaIndividuo.Individuos = lista;
            return JsonUtility.ToJson(listaIndividuo, prettyPrint);
        }

        [System.Serializable]
        private class ListaIndividuo<Individuo>
        {
            [SerializeField]
            public List<Individuo> Individuos;
        }
    }
}