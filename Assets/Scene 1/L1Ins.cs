using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L1Ins : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

        void PrintInstructions()
    {
        Debug.Log("Level One: The wall is not your frined! You only can touch it 3 times!");
        Debug.Log("To move the player, use arrows (←↑↓→), or WASD.");
        Debug.Log("Press ESC to back to the menu");
    }
}