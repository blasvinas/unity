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

Also you should set the Z property of the background image to something like 5 so the other elements can sit on the top.

## Rigidbody

To add physics to the elements of the game add a RigidBody component or Rigidbody 2D for 2D games. There are three types of bodies:

- Dynamic:  Simulates gravity.
- Kinematic: Object that you will move manually.
- Static:  Static object.

If need to add a collider to an object, if you do not want other object to pass through.  Click on Add Component, look for collider and select the one more appropriated for the shape of the object for example Circle Collider 2D.  

If you need to make the object to bounce, you need to create a material and add it to the object.  To create the material go to Project windows, right click, create, Physics Material 2D.  Set the Bounciness property to a value between 0 and 1.  The high the value the higher the bounce.  Also, you can set the Friction property to 0, this will make the object to lose less speed when it collides with other objects.

Once the material has been created, added it to the Material property of the Rigidbody component of the object.

## Collider

A collider in an invisible shape that handle physical collisions for an object. If you need an object to pass through the collider, but to trigger an event you need to check the isTrigger property of for the collider. You can add collider to object in your game.  In this particular example we created an Empty Object named LoseCollider and add a Box Collider 2D to it.  The propose of this collider is that if the ball pass through it, the game is over.

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

## Gravity 

You can control the gravity for individual components with the Gravity Scale property in the Rigidbody group.  Also you can set the gravity for the whole project going to Edit->Project Setting->Physics 2D an change the Gravity field.

## Prefabs

You you create an object that you need to use multiple times, it is better if you make it a prefab.  To create a prefab, create the object as you normally do, with all the properties that you want.  Then drag the object to the project window.  The object should turn blue in the hierarchy.  For better organization you should create a prefabs folder.

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


## Audio

You can play a sound when a object collides with other objects.  To do that add a Audio Source component to the object and then drag a audio file to the AudioClip property.

Now you need to add a OnCollisionEnter2D method to script attached to the object.  In the method call : GetComponent<AudioSource>().Play().
