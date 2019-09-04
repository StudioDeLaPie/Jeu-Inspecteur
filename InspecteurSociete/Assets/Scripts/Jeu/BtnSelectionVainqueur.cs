using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BtnSelectionVainqueur : MonoBehaviour
{
    public TextMeshProUGUI text;

    private Joueur joueur;
    private SelectionVainqueurManche selectionVainqueur;

    public void Init(SelectionVainqueurManche sV, Joueur j)
    {
        joueur = j;
        text.text = joueur.Name;
        selectionVainqueur = sV;
    }

    public void AfficherPopUpVerif()
    {
        selectionVainqueur.VainqueurSelectionne(joueur);
    }
}
