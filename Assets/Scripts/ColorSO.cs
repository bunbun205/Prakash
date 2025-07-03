using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorSO", menuName = "Game/ColorSO")]
public class ColorSO : ScriptableObject
{
    [SerializeField] private List<Color> colors;
    public float level5PercentageChange, betweenLevelPercentageChange;

    public void Add(Color color)
    {
        if(!colors.Contains(color))
            colors.Add(color);
    }

    public Color[] GetArray()
    {
        return colors.ToArray();
    }
}
