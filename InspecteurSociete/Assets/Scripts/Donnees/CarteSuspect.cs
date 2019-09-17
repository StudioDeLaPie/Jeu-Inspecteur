using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Carte Suspect")]
public class CarteSuspect : ScriptableObject
{
    public string victime;
    public string crimeCommis;
    public string lieu;
    public List<string> ListeSuspects;
    [TextArea, SerializeField] private string descriptionCrime;
    public Sprite sprite;

    /// <summary>
    /// Renvoie la description en remplacant les mots Dynamiques
    /// </summary>
    /// <returns></returns>
    public string GetDescriptionCrime(Dictionnaire dico)
    {
        string result = descriptionCrime.Replace("[sujet]", dico.SujetsAleatoire());
        result = result.Replace("[verbe]", dico.VerbesAleatoire());
        result = result.Replace("[verbeC]", dico.VerbesAvecComplementAleatoire());
        return result;
    }
}
