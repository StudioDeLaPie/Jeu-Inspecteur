using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteCrime
{
    public string victime;
    public string crimeCommis;
    public string lieu;
    public List<string> ListeSuspects;
    [TextArea, SerializeField] public string descriptionCrime;

    public string DescriptionCrime { set => descriptionCrime = value; }

    public string spriteName;

    /// <summary>
    /// Renvoie la description en remplacant les mots Dynamiques
    /// </summary>
    /// <returns></returns>
    public string GetDescriptionCrime(Dictionnaire dico)
    {
        string result = descriptionCrime;

        for (int i = 0; i <= Enum.GetValues(typeof(TypeMot)).Length - 1; i++)
        {
            result = Replace(result, (TypeMot)i, dico);
        }

        return result;
    }

    public Sprite GetSprite()
    {
        return Resources.Load<Sprite>("ImagesCartes/" + spriteName);
    }


    /// <summary>
    /// Remplace les type de mots donné par des mots du dictionnaire dans la phrase
    /// </summary>
    /// <param name="phrase"></param>
    /// <param name="type"></param>
    /// <param name="dico"></param>
    /// <returns></returns>
    private string Replace(string phrase, TypeMot type, Dictionnaire dico)
    {
        string motCle;

        switch (type)
        {
            case TypeMot.Sujet:
                motCle = "[sujet]";
                break;
            case TypeMot.Verbe:
                motCle = "[verbe]";
                break;
            case TypeMot.VerbeAvecComplement:
                motCle = "[verbeC]";
                break;
            default:
                motCle = string.Empty;
                break;
        }

        string tempDescription = phrase;
        string result = string.Empty;

        //On Remplace les mots cle dans tout les formats
        for (int i = 0; i <= Enum.GetValues(typeof(FormatMot)).Length - 1; i++)
        {
            motCle = Dictionnaire.FormatCase(motCle, (FormatMot)i);

            while (tempDescription.IndexOf(motCle) != -1)
            {
                result += tempDescription.Substring(0, tempDescription.IndexOf(motCle));
                result += dico.MotAleatoire(type, (FormatMot)i);
                tempDescription = tempDescription.Remove(0, tempDescription.IndexOf(motCle) + motCle.Length);
            }
            result += tempDescription;

            tempDescription = result;
            result = string.Empty;

        }
        return tempDescription;
    }
}
