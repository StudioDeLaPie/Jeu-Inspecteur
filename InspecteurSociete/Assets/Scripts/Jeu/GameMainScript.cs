using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMainScript : MonoBehaviour
{
    public GameManager manager;
    public AffichageCarteSuspect affichageCarte;
    public AffichageInspecteur affichageInspecteur;
    public SelectionVainqueurManche selectionVainqueur;
    public TableauScores tableauScores;
    private List<CarteCrime> deck;

    private Joueur inspecteur;
    private CarteCrime carteActuelle;
    private List<Joueur> joueursEnJeu;
    private List<MonoBehaviour> menus;

    private void OnEnable()
    {
        if (deck == null)
            deck = Deck.GetDeck();

        joueursEnJeu = new List<Joueur>(manager.joueurs);
        inspecteur = joueursEnJeu[joueursEnJeu.Count - 1]; //Sélectione le dernier joueur pour qu'à la sélection ça revienne au premier
        menus = new List<MonoBehaviour>() { affichageCarte, affichageInspecteur, selectionVainqueur, tableauScores };
        ShuffleDeck();

        AfficherNouvelInspecteur();
    }

    public void AfficherNouvelInspecteur()
    {
        inspecteur = joueursEnJeu[(joueursEnJeu.IndexOf(inspecteur) + 1) % joueursEnJeu.Count]; //Sélectionne les inspecteurs l'un après l'autre en boucle

        affichageInspecteur.nomInspecteur.text = inspecteur.Name;
        Show(affichageInspecteur);
    }

    public void AfficherNouveauSuspect()
    {
        if (carteActuelle == null || deck.IndexOf(carteActuelle) == deck.Count - 1) //Si premier tour OU toutes les cartes sont passées on re-mélange
        {
            ShuffleDeck();
            carteActuelle = deck[0];
        }
        else
        {
            carteActuelle = deck[deck.IndexOf(carteActuelle) + 1];
        }

        affichageCarte.AfficherCarte(carteActuelle);
        Show(affichageCarte);
    }

    public void AfficherSelectionVainqueur()
    {
        List<Joueur> suspectsActuels = new List<Joueur>(joueursEnJeu); //Copie les joueurs en jeu
        suspectsActuels.Remove(inspecteur);   //On retire l'inspecteur parce que il ne peut pas gagner de point
        selectionVainqueur.SuspectsActuels = suspectsActuels;
        Show(selectionVainqueur);
    }

    public void VainqueurMancheSelectionne(Joueur vainqueur)
    {
        vainqueur.Points++;
        AfficherTableauDesScores();
    }

    public void AfficherTableauDesScores()
    {
        tableauScores.RefreshTableau(joueursEnJeu);
        Show(tableauScores);
    }

    private void Show(MonoBehaviour menu)
    {
        menus.ForEach(m => m.gameObject.SetActive(false));
        menu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Mélange le deck de cartes de suspects et sélectionne comme nouvelle carte actuelle 
    /// </summary>
    private void ShuffleDeck()
    {
        System.Random rnd = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rnd.Next(n + 1);
            CarteCrime carte = deck[k];
            deck[k] = deck[n];
            deck[n] = carte;
        }
    }
}
