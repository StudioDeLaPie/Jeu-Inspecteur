using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AffichageCarteSuspect : MonoBehaviour
{
    public GameMainScript mainScript;
    public Text victime;
    public Text crimeCommis;
    public Text suspect;
    public Text lieu;
    public Text contexte;
    public Image image;

    public GameObject popUpVerif;

    public void AfficherCarte(CarteSuspect carte)
    {
        victime.text = carte.victime;

        crimeCommis.text = carte.crimeCommis;

        suspect.text = string.Empty;
        foreach (var nomSuspect in carte.ListeSuspects)
        {
            suspect.text += nomSuspect + "\n";
        }

        lieu.text = carte.lieu;

        contexte.text = carte.descriptionCrime;
        image.sprite = carte.sprite;
        popUpVerif.SetActive(false);
    }

    public void AffichagePopUpVerif()
    {
        popUpVerif.SetActive(true);
    }

    public void MasquerPopUpVerif()
    {
        popUpVerif.SetActive(false);
    }

    public void ConfirmerFinManche()
    {
        mainScript.AfficherSelectionVainqueur();
    }

}
