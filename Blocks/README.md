# Block Game

## Camera

Since this is a 2D Game, it uses a orthographic camera. Below are the formulas to calculate the height and width in units:

- height = size * 2
- width = heigh *aspect ratio.  For example if the aspect  ratio is set to 4:3, the width will be height x 4 / 3.

Using the formulas above, if the camera size is set to 3 and the aspect ratio is 4:3 then the height is 6 (3 x 2) and the width is 8 (6 x 4 / 3)

If you attached an image to the camera, by default the 0,0 will be at the center of the image.  If you want to make the 0,0 at the bottom left (so you do not have to deal with negative numbers), click on the image  in the project window and change the pivot property to Bottom Left.  Also make sure that you reset the position of the image so it is 0,0,0.

You define the number of pixels per unit in the property Pixels per Unit.

In this example we are using an image with a size of 1920 x 1080.  If we want the image to fill the camera the pixels per unit should be 90.  This is how the 90 is calculated:  height of the image / heigh of the camera = 1080 / 12 = 90.

The width of camera is height x aspect ratio = 12 x 16 / 9 = 21.3.  

We need to position the camera at width / 2 and heigh / 2 so 21.3 /2 and 12/6 = 10.6 and 6.

Also you should set the Z property of the background image to something like -5 so the other elements can sit on the top.

In summary for a 10:6 aspect ratio using a camera size of 6 use: x: 10.6, y: 6, z: -5.

## Canvas

This project use a Canvas.  Canvas are use to display UI component in the game (text, buttons, etc.).  The canvas is on top of the game.  To add a Canvas to your game go to GameObject -> UI->Canvas.  

## TextMesh Pro

In  Unity you can import your own fonts using the TextMesh Pro package.  To check if the package is installed, go to Windows, Package Manager, click on the In Project dropdown and look for TextMesh Pro.  If the package is not installed, click on In Project dropdown and select All Packages. Looks for TextMesh Pro and installed.

Once you have TextMesh Pro installed, go to Windows, TextMeshPro, Font Asset Creator and then click on Import TMP Essentials and when that is done click on Import TMP Examples & Extras.  In the Font Asset Creator dialog, drag the font file into the Source Font File field, click on Generate Font Atlas and then save the file.

Once the text has been generated, you can use TextMeshPro instead of regular text, selecting GameObject, UI, TextMeshPro.   In the properties on the TextMesh look for the Font Asset filed,  and select the font generated in the previous step.

To use the TextMeshPro in your scripts, you need to import TMPro with using TMPro. Your filed will be of type TextMeshProUGUI, fr example: [SerializeField] TextMeshProUGUI storyTitle.

## Audio

If you need to add a ambiance sound, create a Audio Source object.  In the AudioClip property select the audio file to play, check Play On Awake and Loop.

You can play a sound when a object collides with other objects.  To do that add a Audio Source component to the object and then drag a audio file to the AudioClip property.

Now you need to add a OnCollisionEnter2D method to script attached to the object.  In the method call : GetComponent\<AudioSource>().Play().

## Scene Management

To load the next scene, create a script named SceneLoader (or any other name) with a content similar to this:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
```

On the scene create a GameObject and attach the script to it.  On the button that is going to load the next scene, look for the OnClick property, add the GameObject to it and select the appropriated function.

If you need to get the name of the active scene call SceneManager.GetActiveScene().name.  Also you can get the total number of scenes in the game with SceneManager.sceneCountInBuildSettings.

## Collider

A collider in an invisible shape that handle physical collisions for an object. If you need an object to pass through the collider, but to trigger an event you need to check the isTrigger property of for the collider. You can add collider to object in your game.  In this particular example we created an Empty Object named LoseCollider and add a Box Collider 2D to it.  The propose of this collider is that if the ball pass through it, the game is over.  You need to attach and script to the collider to handle the trigger even.  The example below load the "Game Over" scene.

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
    }
}
```

## Sprite

To add an sprite, select GameComponent -> 2D Object -> Sprite.  Then in the sprite property select or drag the sprite.  If you need to add physics to the object, attach a Rigidbody component.

## Rigidbody

To add physics to the elements of the game add a RigidBody component or Rigidbody 2D for 2D games. There are three types of bodies:

- Dynamic:  Simulates gravity.
- Kinematic: Object that you will move manually.
- Static:  Static object.

If need to add a collider to an object, if you do not want other object to pass through.  Click on Add Component, look for collider and select the one more appropriated for the shape of the object for example Circle Collider 2D.  

## Material

If you need to make the object to bounce, you need to create a material and add it to the object.  To create the material go to Project windows, right click, create, Physics Material 2D.  Set the Bounciness property to a value between 0 and 1.  The high the value the higher the bounce.  Also, you can set the Friction property to 0, this will make the object to lose less speed when it collides with other objects.

Once the material has been created, added it to the Material property of the Rigidbody component of the object.

## Prefabs

You you create an object that you need to use multiple times, it is better if you make it a prefab.  To create a prefab, create the object as you normally do, with all the properties that you want.  Then drag the object to the project window.  The object should turn blue in the hierarchy.  For better organization you should create a prefabs folder.

## Gravity

You can control the gravity for individual components with the Gravity Scale property in the Rigidbody group.  Also you can set the gravity for the whole project going to Edit->Project Setting->Physics 2D an change the Gravity field.

## Game Speed

You can control the speed of your game adding  Time.timeScale = gameSpeed to your update method. gameSpeed is a float variable.  If you want to be able to specify a range from the inspector add the following line to your script:  Range(0.1f, 10.0f)][SerializeField] float gameSpeed = 1.0f.  Normally you create a Game.cs script and attached to a GameObject in the scene.

## Tag

You can tag your game objects so you can add some logic to your scripts depending on the tag.  In this example, we are tagging the blocks as breakable or unbreakable so in the script we can control weather or not to destroy the block.  To tag an object click on the tag dropdown in the inspector and select Add Tag.

## Mouse Movement

In this game we want to move the paddle with the mouse.  To get the current position of the mouse you call Input.mousePosition.  Since we are only interested in te X axis we use Input.mousePosition.x.

Now to calculate the mouse position in Units use the following formula:

mousePosition = Input.MousePosition.X / Screen.width * widthScreenInUnits.

The widthScreenInUnit is the width  of the camera how it is calculated in the camera section above.

Also to limit the InputMousePosition.x to the width of the camera use the function Mathf.Clamp as follow:

Mathf.Clamp(paddlePosition.x, minX, maxX)

To prevent the paddle to go outside the camera, The value of minX is usually a little bigger that 0, like 1 or 2, and the value of maxX is a little less that widthScreenInUnits.

The line below show all the calculations

```csharp
    void Update()
    {
        float mousePositionInUnits =  Input.mousePosition.x / Screen.width * widthScreenWidthInUnits;
        Vector2 paddlePosition = new Vector2(mousePositionInUnits, transform.position.y);
        paddlePosition.x = Mathf.Clamp(paddlePosition.x, minX, maxX);
        transform.position = paddlePosition;
    }
```

The code above show should be  part of a script attached to the paddle object.

## Destroy Object Programmatically

To destroy an object programmatically create an script and attached to the object.  Add a private method OnCollisionEnter2D and inside this method run the Destroy command.  Below is an example.

```csharp
public class Block : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
```

## Particle Systems

Import the particle system.  Then in the script that is going to display the particle system create a SerializedFiled GameObject variable similar to this:  [SerializeField] GameObject blockSparklesVFX.  On the object that have the script associated attache the particle system to the serializefield variable.  To display the particle system call execute:

```csharp
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);  //destroy the particle system after a second
```

## Score

To keep the score between levels, follow the next steps:

- Create a GameObject and called it Game (or any name you want).  
- As child of the Game object create the Canvas with the text filed for the  score.
- Create a script to keep the score and attached to the Game object.
- The script should have a Serialized filed and it should be linked to the sore text filed in the canvas.
- The script should look similar to this:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    [Range(0.1f, 10.0f)][SerializeField] float gameSpeed = 1.0f;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameCount = FindObjectsOfType<Game>().Length;
        if (gameCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {
        currentScore++;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
```

Only one Game  object should exist during the game.  The Awake is the first method that runs when an object is created.  The Awake method checks idf there is more that one instance of  this object running, if if that s the case it will destroy it, otherwise if won't destroy the previous instance when it loads.

Also make sure that you include a ResetGame methid and call it when you restart the games.  In this example we are calling in in the SceneLoad class in the PlayAgain methid as shown below.

```csharp
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level 1");
        FindObjectOfType<Game>().ResetGame();
    }
```
