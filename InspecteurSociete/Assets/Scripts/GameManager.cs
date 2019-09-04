using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject selectionNbJoueurs;
    public GameObject saisieNomsJoueurs;
    public GameObject ecranJeu;


    [HideInInspector] public int nbJoueurs;
    [HideInInspector] public List<Joueur> joueurs;
    private List<GameObject> ecrans;

    private void Start()
    {
        ecrans = new List<GameObject>() { menuPrincipal, selectionNbJoueurs, saisieNomsJoueurs, ecranJeu };
        Show(menuPrincipal);
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
        ecrans.ForEach(go => go.SetActive(false));
        ecran.SetActive(true);
    }
}
