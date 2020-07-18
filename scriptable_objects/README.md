- [Canvas](#canvas)
- [ScriptableObjects](#scriptableobjects)
- [Script](#script)
- [TextMesh Pro](#textmesh-pro)

# Canvas

This project use a Canvas.  Canvas are use to display UI component in the game (text, buttons, etc.).  The canvas is on top of the game.

# ScriptableObjects

ScriptableObjects are data container.  In this example we are using a scriptableobject to keep the state of the project. To define a scriptable object you create a class derived from ScriptableObject as the one in State.cs. In this particular example the class has a title, text of the story, and an array with the next states.

Also the state class has the following decorator:  [CreateAssetMenu(menuName = "State")].  This allow to create a new State directly from Unity in the project window.

# Script

You can use the [SerializedField] decorator to make the field available in the inspector.  For example:  [SerializeField] Text storyTitle.  Also if you need a text field to have shows a text area in the inspector, you can add a decorator similar to this: [SerializeField] [TextArea(15, 10)] string storyText. In this example the text area has 15 rows but if will display only 10 and scroll after that.

# TextMesh Pro

In  Unity you can import your own fonts using the TextMesh Pro package.  To check if the package is installed, go to Windows, Package Manager, click on the In Project dropdown and look for TextMesh Pro.  If the package is not installed, click on In Project dropdown and select All Packages. Looks for TextMesh Pro and installed.

Once you have TextMesh Pro installed, go to Windows, TextMeshPro, Font Asset Creator and then click on Import TMP Essentials and when that is done click on Import TMP Examples & Extras.  In the Font Asset Creator dialog, drag the font file into the Source Font File field, click on Generate Font Atlas and then save the file.

Once the text has been generated, you can use TextMeshPro instead of regular text, selecting GameObject, UI, TextMeshPro.   In the properties on the TextMesh look for the Font Asset filed,  and select the font generated in the previous step.

To use the TextMeshPro in your scripts, you need to import TMPro with using TMPro. Your filed will be of type TextMeshProUGUI, fr example: [SerializeField] TextMeshProUGUI storyTitle. 