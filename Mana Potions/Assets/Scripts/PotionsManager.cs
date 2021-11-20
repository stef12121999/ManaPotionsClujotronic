using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionsManager : MonoBehaviour
{

    public static PotionsManager Instance { get; private set; }

    public GameObject potionPrefab;

    private int currentNumberOfPotions;
    private List<Potion> currentPotions;
    private bool[] slotsAvailabilty;

    private Potion combineQueue = null;

    public void CombinePotion(Potion pot)
    {
        if(combineQueue == null)
        {
            combineQueue = pot;
        } 
        else
        {
            int slot = GetFirstAvailableSlot();
            if ( slot >= 0)
            {
                //play mixing animation and sound

                Vector3 position = new Vector3(slot/5 * 10, 0, slot % 5 * 10);
                GameObject newPotion = Instantiate(potionPrefab, position, Quaternion.identity) as GameObject;
                newPotion.GetComponent<Potion>().Init(CombineColors(combineQueue.GetColor(), pot.GetColor()));

                slotsAvailabilty[slot] = false;
                combineQueue = null;
            }
        }
    }

    private int GetFirstAvailableSlot()
    {
        for (int i = 0; i < 30 ; i++)
        {
            if (this.slotsAvailabilty[i])
            {
                return i;
            }
        }
        return -1;
    }

    private Color CombineColors(Color first, Color second)
    {

        float r = (first.r + second.r) / 2;
        float g = (first.g + second.g) / 2;
        float b = (first.b + second.b) / 2;

        return new Color(r, g, b);
    }

}
