# ScriptableObject Sample

## Canvas

This project use a Canvas.  Canvas are use to display UI component in the game (text, buttons, etc.).  The canvas is on top of the game.

## ScriptableObjects

ScriptableObjects are data container.  In this example we are using a scriptableobject to keep the state of the project.
To define a scriptable object you create a class derived from ScriptableObject as the one in State.cs.
In this particular example the class has a title, text of the story, and an array with the next states.

Also the state class has the following decorator:  CreateAssetMenu(menuName = "State")].  This allow to create a new State directly from Unity in the
projec t window.