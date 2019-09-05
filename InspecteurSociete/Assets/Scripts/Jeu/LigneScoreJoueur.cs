using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LigneScoreJoueur : MonoBehaviour
{
    public Text nomJoueur;
    public Text scoreJoueur;

    public void AfficherScore(Joueur j)
    {
        nomJoueur.text = j.Name;
        scoreJoueur.text = j.Points.ToString();
    }
}
