using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsManager : MonoBehaviour
{
    public static EffectsManager Instance { get; private set; }

    private List<Effect.Effects> currentEffects;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Use this function when the player wants to drink a potion to determine if he already tried that one, and if so he sais "Oh, not again..." and refuses to drink it
    public bool HasEffect(Effect.Effects effect)
    {
        if (currentEffects.Contains(effect))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// When drinking add the curent potion Effect to the list of current Effects
    /// </summary>
    /// <param name="effect"></param>
    public void AddEffect(Effect.Effects effect)
    {
        if (!currentEffects.Contains(effect))
        {
            currentEffects.Add(effect);
        }
    }

}
