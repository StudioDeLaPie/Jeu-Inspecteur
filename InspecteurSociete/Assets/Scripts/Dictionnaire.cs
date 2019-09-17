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

    public string JSONStringDico;

    private void Start()
    {
        //Debug.Log("simple dataPath-> " + Application.dataPath); //Git_JeuxInspecteur/Jeu-Inspecteur/InspecteurSociete/Assets
        //Debug.Log("persistentDataPath-> " + Application.persistentDataPath); //Studio/AppData/LocalLow/StudioDeLaPie/InspectorGame  (Utilise le ssd donc pour l'instant on utilise le simple data path)

        JsonUtility.FromJsonOverwrite(lireUnFichier(Application.streamingAssetsPath + "/dictionnaire.pie"), this); // récupère les mots à partir du JSON
    }

    public string lireUnFichier(string pathFichier)
    {
        try
        {
            // Création d'une instance de StreamReader pour permettre la lecture de notre fichier
            StreamReader monStreamReader = new StreamReader(pathFichier);
            string ligne = monStreamReader.ReadToEnd();

            // Fermeture du StreamReader, très important pour libérer la ressource
            monStreamReader.Close();

            return ligne;
        }
        catch (Exception ex)
        {
            // Code exécuté en cas d'exception
            Debug.LogError("Erreur lecture JSON dictionnary");
            return string.Empty;
        }
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
