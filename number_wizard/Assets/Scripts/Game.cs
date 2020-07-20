using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] Text guessText;

    int min;
    int max;
    int guess;

    // Start is called before the first frame update
    void Start()
    {
        min = 1;
        max = 1000;
        CalculateGuess();
    }

    public void onHigher()
    {
        min = guess + 1;
        CalculateGuess();
    }

    public void onLower()
    {
        max = guess - 1;
        CalculateGuess();
    }

    public void OnCorrect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void CalculateGuess()
    {
        guess = Random.Range(min, max);
        guessText.text = guess.ToString();
    }

}
