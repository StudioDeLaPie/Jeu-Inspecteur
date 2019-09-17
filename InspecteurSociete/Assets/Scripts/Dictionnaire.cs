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

    public string SujetsAleatoire()
    {
        int index = Aleatoire.AleatoireBetween(0, sujets.Count-1);
        return sujets[index];
    }

    public string VerbesAleatoire()
    {
        int index = Aleatoire.AleatoireBetween(0, verbes.Count-1);
        return verbes[index];
    }

    public string VerbesAvecComplementAleatoire()
    {
        int index = Aleatoire.AleatoireBetween(0, verbesAvecComplement.Count-1);
        return verbesAvecComplement[index];
    }
}
