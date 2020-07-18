using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [SerializeField] string storyTitle;
    [SerializeField] [TextArea(15, 10)] string storyText;
    [SerializeField] State[] nextStages;

    public string GetTitle()
    {
        return storyTitle;
    }

    public string  GetStory()
    {
        return storyText;
    }

    public State[] GetNextStages()
    {
        return nextStages;
    }
}
