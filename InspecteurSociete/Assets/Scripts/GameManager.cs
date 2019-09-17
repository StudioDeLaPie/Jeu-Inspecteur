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


    [HideInInspector] public int nbJoueurs;
    [HideInInspector] public List<Joueur> joueurs;
    private List<GameObject> ecrans;
    private GameObject displayedEcran;

    private void Start()
    {
        ecrans = new List<GameObject>() { menuPrincipal, selectionNbJoueurs, saisieNomsJoueurs, ecranJeu };
        Show(menuPrincipal);
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

    private void Show(GameObject ecran)
    {
        displayedEcran?.SetActive(false);
        //ecrans.ForEach(go => go.SetActive(false));
        displayedEcran = ecran;
        ecran.SetActive(true);
    }
}
