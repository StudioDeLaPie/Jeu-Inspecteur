using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Carte Suspect")]
public class CarteSuspect : ScriptableObject
{
    public string victime;
    public string suspectPrincipal;
    [TextArea] public string descriptionCrime;
    public Sprite sprite;
}
