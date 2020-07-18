using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryGame : MonoBehaviour
{

    [SerializeField] Text storyTitle;
    [SerializeField] Text storyText;
    [SerializeField] State initialState;

    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = initialState;
        storyTitle.text= state.GetTitle();
        storyText.text = state.GetStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageStates();
    }

    void ManageStates()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            state = state.GetNextStages()[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            state = state.GetNextStages()[1];
        }
        storyTitle.text = state.GetTitle();
        storyText.text = state.GetStory();
    }
}
