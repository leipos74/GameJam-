using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteSandwich : MonoBehaviour
{
    public GameObject[] ingredients;

    public PlayerMovement player;

    void Update()
    {
        for(int i = 0; i < ingredients.Length; i++)
        {
            if (player.ingredientId == i)
            {
                ingredients[i].SetActive(true);
            }
        }
    }
}
