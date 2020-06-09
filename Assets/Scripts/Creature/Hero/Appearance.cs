using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Appearance
{
    public Color BodyColor { get; private set; }
    public Color HeirColor { get; private set; }
    public Color EyeColor { get; private set; }
    
    public Appearance(Color Body, Color Heir, Color Eye)
    {
        BodyColor = Body;
        HeirColor = Heir;
        EyeColor = Eye;
    }
}
