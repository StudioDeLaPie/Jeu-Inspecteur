using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowContext : MonoBehaviour
{
    public GameObject contextMesh;

    public void ShowContextView()
    {
        contextMesh.SetActive(true);
    }

    public void HideContextView()
    {
        contextMesh.SetActive(false);
    }
}
