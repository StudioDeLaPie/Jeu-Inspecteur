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


    private string SujetsAleatoire(FormatMot format)
    {
        int index = Aleatoire.AleatoireBetween(0, sujets.Count - 1);
        return FormatCase(sujets[index], format);
    }

    private string VerbesAleatoire(FormatMot format)
    {
        int index = Aleatoire.AleatoireBetween(0, verbes.Count - 1);
        return FormatCase(verbes[index], format);
    }

    private string VerbesAvecComplementAleatoire(FormatMot format)
    {
        int index = Aleatoire.AleatoireBetween(0, verbesAvecComplement.Count - 1);
        return FormatCase(verbesAvecComplement[index], format);
    }

    public string MotAleatoire(TypeMot type, FormatMot format)
    {
        switch (type)
        {
            case TypeMot.Sujet:
                return SujetsAleatoire(format);
            case TypeMot.Verbe:
                return VerbesAleatoire(format);
            case TypeMot.VerbeAvecComplement:
                return VerbesAvecComplementAleatoire(format);
            default:
                return string.Empty;
        }
    }

    /// <summary>
    /// Formate le mot donné en paramètre pour le mettre en minuscule / majsucule sur la première lettre / Tout en majuscule
    /// </summary>
    /// <param name="mot">Mot à formatter</param>
    /// <param name="format">méthode de formattage</param>
    /// <returns></returns>
    static public string FormatCase(string mot, FormatMot format)
    {
        switch (format)
        {
            case FormatMot.minuscule:
                mot = mot.ToLower();
                break;
            case FormatMot.Majuscule:
                if (mot[0].ToString() == "[") //Si le mot est [sujet] le script doit mettre le S en majuscule est non le [
                    mot = mot[0] + mot[1].ToString().ToUpper() + mot.Substring(2).ToLower();
                else
                    mot = mot[0].ToString().ToUpper() + mot.Substring(1).ToLower();
                break;
            case FormatMot.MAJUSCULE:
                mot = mot.ToUpper();
                break;
            default:
                break;
        }

        return mot;
    }
}
