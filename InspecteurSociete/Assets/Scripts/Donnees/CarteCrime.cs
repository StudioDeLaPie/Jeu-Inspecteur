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
        string result = descriptionCrime.Replace("[sujet]", dico.SujetsAleatoire());
        result = result.Replace("[verbe]", dico.VerbesAleatoire());
        result = result.Replace("[verbeC]", dico.VerbesAvecComplementAleatoire());
        return result;
    }

    public Sprite GetSprite()
    {
        return Resources.Load<Sprite>("ImagesCartes/" + spriteName);
    }
}
