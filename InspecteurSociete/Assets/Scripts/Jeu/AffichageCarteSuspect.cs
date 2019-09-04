using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AffichageCarteSuspect : MonoBehaviour
{
    public GameMainScript mainScript;
    public TextMeshProUGUI victime;
    public TextMeshProUGUI suspect;
    public TextMeshProUGUI description;
    public Image image;

    public GameObject popUpVerif;

    public void AfficherCarte(CarteSuspect carte)
    {
        victime.text = carte.victime;

        suspect.text = string.Empty;
        foreach (var nomSuspect in carte.ListeSuspects)
        {
            suspect.text += nomSuspect + "\n";
        }

        description.text = carte.descriptionCrime;
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
