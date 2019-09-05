using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionVainqueurManche : MonoBehaviour
{
    public GameMainScript gameMainScript;
    public GameObject prefabBtnJoueur;
    public Transform grid;
    public GameObject popUpVerif;
    public Text textNomJoueurPopUp;

    private List<Joueur> suspects;
    private Joueur vainqueur;

    public List<Joueur> SuspectsActuels
    {
        set
        {
            suspects = value;
            RefreshBtnSuspects();
        }
    }

    private void RefreshBtnSuspects()
    {
        popUpVerif.SetActive(false);

        Utilities.ClearTransformChildren(grid);

        foreach (Joueur j in suspects)
        {
            GameObject btn = Instantiate(prefabBtnJoueur, grid);
            btn.GetComponent<BtnSelectionVainqueur>().Init(this, j);
        }
    }

    public void VainqueurSelectionne(Joueur j)
    {
        vainqueur = j;
        textNomJoueurPopUp.text = j.Name + " ?";
        popUpVerif.SetActive(true);
    }

    public void PopUpConfirmer()
    {
        gameMainScript.VainqueurMancheSelectionne(vainqueur);
    }

    public void PopUpAnnuler()
    {
        vainqueur = null;
        popUpVerif.SetActive(false);
    }
}
