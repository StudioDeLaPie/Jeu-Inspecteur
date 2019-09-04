using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectionNbJoueurs : MonoBehaviour
{
    public TextMeshProUGUI nbJoueursText;
    public Slider slider;
    public GameManager manager;

    public void ValueChanged()
    {
        nbJoueursText.text = slider.value.ToString();
    }

    public void ClickNext()
    {
        manager.NbJoueursOK((int)slider.value);
    }
}
