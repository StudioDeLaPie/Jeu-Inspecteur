using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauScores : MonoBehaviour
{

    public GameObject prefabLigneScore;
    public Transform grid;

    public void RefreshTableau(List<Joueur> joueurs)
    {
        Utilities.Utilities.ClearTransformChildren(grid);

        foreach (Joueur j in joueurs)
        {
            Instantiate(prefabLigneScore, grid).GetComponent<LigneScoreJoueur>().AfficherScore(j);
        }
    }
}
