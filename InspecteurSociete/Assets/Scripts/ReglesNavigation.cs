using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReglesNavigation : MonoBehaviour
{
    public GameObject nextBtn;
    public GameObject previousBtn;

    private int indexPage;
    [SerializeField] private List<GameObject> pages;

    private void OnEnable()
    {
        indexPage = 0;
        pages.ForEach(page => page.SetActive(false));
        pages[indexPage].SetActive(true);
        previousBtn.SetActive(false);
        nextBtn.SetActive(true);
    }

    /// <summary>
    /// Appelé par le nextBtn
    /// </summary>
    public void NextPage()
    {
        if (indexPage < pages.Count - 1)
        {
            pages[indexPage].SetActive(false);
            indexPage++;
            pages[indexPage].SetActive(true);
            if (indexPage == 1)
                previousBtn.SetActive(true);
            if (indexPage == pages.Count - 1)
                nextBtn.SetActive(false);
        }
    }

    /// <summary>
    /// Appelé par le previousBtn
    /// </summary>
    public void PreviousPage()
    {
        if (indexPage > 0)
        {
            pages[indexPage].SetActive(false);
            indexPage--;
            pages[indexPage].SetActive(true);
            if (indexPage == 0)
                previousBtn.SetActive(false);
            if (indexPage < pages.Count - 1)
                nextBtn.SetActive(true);
        }
    }

    /// <summary>
    /// Appelé par la flèche de retour, pour quitter les règles
    /// </summary>
    public void Back()
    {
        gameObject.SetActive(false);
    }
}
