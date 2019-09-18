using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Utilities;

public class Dictionnaire : MonoBehaviour
{
    [SerializeField] private List<string> sujets = new List<string>();
    [SerializeField] private List<string> verbes = new List<string>();
    [SerializeField] private List<string> verbesAvecComplement = new List<string>();

    public TextAsset dictionnaireFile;

    private void Start()
    {

        JsonUtility.FromJsonOverwrite(dictionnaireFile.text, this); // récupère les mots à partir du JSON
    }


    public string SujetsAleatoire(TypeMot type)
    {
        int index = Aleatoire.AleatoireBetween(0, sujets.Count - 1);
        return FormatCase(sujets[index], type);
    }

    public string VerbesAleatoire(TypeMot type)
    {
        int index = Aleatoire.AleatoireBetween(0, verbes.Count - 1);
        return FormatCase(verbes[index], type);
    }

    public string VerbesAvecComplementAleatoire(TypeMot type)
    {
        int index = Aleatoire.AleatoireBetween(0, verbesAvecComplement.Count - 1);
        return FormatCase(verbesAvecComplement[index], type);
    }

    /// <summary>
    /// Formate le mot donné en paramètre pour le mettre en minuscule / majsucule sur la première lettre / Tout en majuscule
    /// </summary>
    /// <param name="mot">Mot à formatter</param>
    /// <param name="type">méthode de formattage</param>
    /// <returns></returns>
    private string FormatCase(string mot, TypeMot type)
    {
        switch (type)
        {
            case TypeMot.minuscule:
                mot = mot.ToLower();
                break;
            case TypeMot.Majuscule:
                mot = mot[0].ToString().ToUpper() + mot.Substring(1).ToLower();
                break;
            case TypeMot.MAJUSCULE:
                mot = mot.ToUpper();
                break;
            default:
                break;
        }

        return mot;
    }
}
