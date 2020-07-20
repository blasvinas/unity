- [Number Wizard Game](#number-wizard-game)
- [Canvas](#canvas)
- [Anchors](#anchors)
- [Adding Multiple Scenes](#adding-multiple-scenes)

# Number Wizard Game

In this game you need to think a number and then the game will start guessing the number.  UYou need to indicate if the guessed number is too high or low until the correct number is guessed.

# Canvas

When you create the canvas. set the UI Scale Mode to Scale With Screen Size and then set the reference resolution, for example: 1920 x 1080.

# Anchors

You can anchor element on the screen to they try to keep their position if the screen get resized.  To do that click on the anchor button on the left side of the transform position and then select the position where you want the element to be anchored.

# Adding Multiple Scenes

If you game has multiple scenes, if need to add them using File, Build Setting and then click on Add Open Scene.  On the script file managing the scenes yu need import UnityEngine.SceneManagement, then create a public method to load the scene and call the function SceneManager.LoadScene().

You can get the next scene running SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

To call a method from a button, look for the OnCLick() property and attach the game object that has the script and then select the function.

To quit the application run Application.Quit();
