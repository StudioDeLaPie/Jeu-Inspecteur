﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSelectionVainqueur : MonoBehaviour
{
    public Text text;

    private Joueur joueur;
    private SelectionVainqueurManche selectionVainqueur;

    private void OnEnable()
    {
        GetComponent<Button>().onClick.AddListener(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>().PlaySoundButton);
    }

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
