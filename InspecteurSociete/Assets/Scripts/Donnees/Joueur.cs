using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur
{
    private int index;
    private string name;
    private int points;

    public Joueur(int index, string name)
    {
        this.index = index;
        this.name = name;
        points = 0;
    }

    public int Index { get => index; set => index = value; }
    public string Name { get => name; set => name = value; }
    public int Points { get => points; set => points = value; }
}
