using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LigneScoreJoueur : MonoBehaviour
{
    public TextMeshProUGUI nomJoueur;
    public TextMeshProUGUI scoreJoueur;

    public void AfficherScore(Joueur j)
    {
        nomJoueur.text = j.Name;
        scoreJoueur.text = j.Points.ToString();
    }
}
