using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] Text minText;
    [SerializeField] Text maxText;

    // Start is called before the first frame update
    void Start()
    {
        minText.text = "1";
        maxText.text = "1000";
    }

    public void LoadStartScreen()
    {
        SceneManager.LoadScene(1);
    }
}
