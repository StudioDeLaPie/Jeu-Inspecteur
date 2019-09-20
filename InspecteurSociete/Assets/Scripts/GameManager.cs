using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject selectionNbJoueurs;
    public GameObject saisieNomsJoueurs;
    public GameObject ecranJeu;
    public GameObject regles;
    public GameObject popUpBackButton;


    [HideInInspector] public int nbJoueurs;
    [HideInInspector] public List<Joueur> joueurs;
    private GameObject displayedEcran;

    private void Start()
    {
        Show(menuPrincipal);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            popUpBackButton.SetActive(!popUpBackButton.activeInHierarchy);
        }
    }

    public void ShowRegles()
    {
        regles.SetActive(true);
    }

    public void StartGame()
    {
        Show(selectionNbJoueurs);
    }

    public void NbJoueursOK(int nbJ)
    {
        nbJoueurs = nbJ;
        Show(saisieNomsJoueurs);
    }


    public void NomsJoueursOK(List<Joueur> joueurs)
    {
        this.joueurs = joueurs;
        Show(ecranJeu);
    }

    public void BackToMenu()
    {
        popUpBackButton.SetActive(false);
        Show(menuPrincipal);
    }

    private void Show(GameObject ecran)
    {
        displayedEcran?.SetActive(false);
        displayedEcran = ecran;
        ecran.SetActive(true);
    }
}
