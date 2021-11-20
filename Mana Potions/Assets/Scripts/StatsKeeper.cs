using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "StatsTracker")]
public class StatsTracker : ScriptableObject
{

    private List<Color> colorsObtainedSoFar;
    private int numberOfDifferentColorsObtainedSoFar;


    // Update is called once per frame
    private void AddColor(Color color)
    {
        foreach (Color c in colorsObtainedSoFar)
        {
            if (c.Equals(color))
            {
                return;
            }
        }

        colorsObtainedSoFar.Add(color);
        numberOfDifferentColorsObtainedSoFar++;
    }
}
