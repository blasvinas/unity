using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Level : MonoBehaviour
{
    int breakableBlocks = 0;

    public void AddBlock()
    {
        breakableBlocks++;
    }

    public void RemoveBlock()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            //if (SceneManager.GetActiveScene().name == "Final Level")
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetActiveScene().buildIndex - 2)
            {
                SceneManager.LoadScene("Game Over");
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
