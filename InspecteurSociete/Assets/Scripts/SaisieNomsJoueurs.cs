﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaisieNomsJoueurs : MonoBehaviour
{
    public Transform grid;
    public GameManager manager;
    public GameObject prefabInputField;

    private int nbJoueurs;
    private List<TMP_InputField> inputFields = new List<TMP_InputField>();


    // Start is called before the first frame update
    private void OnEnable()
    {
        nbJoueurs = manager.nbJoueurs;
        for (int i = 0; i < nbJoueurs; i++)
        {
            inputFields.Add(Instantiate(prefabInputField, grid).GetComponent<TMP_InputField>());
            inputFields[i].text = "Joueur " + (i + 1);
        }
    }

    public void ClickNext()
    {
        List<Joueur> joueurs = new List<Joueur>();

        for ( int i = 0; i < nbJoueurs; i++)
        {
            Joueur j = new Joueur(i, inputFields[i].text);
            joueurs.Add(j);
        }

        manager.NomsJoueursOK(joueurs);
    }
}