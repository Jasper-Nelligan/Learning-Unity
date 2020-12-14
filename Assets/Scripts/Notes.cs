/*
VR UNITY

RESOURCES

http://ivl.calit2.net/wiki/images/3/35/UnityScripting.pdf 
Basic of unity scripting and application to VR

https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
Basic movement script

https://answers.unity.com/questions/1526897/what-does-it-mean-by-getcomponent-how-do-you-use-i.html
How to use GetComponent<>();

https://answers.unity.com/questions/129796/rigidbodoy-vs-collider.html
Collider vs RigidBody

https://medium.com/ironequal/unity-character-controller-vs-rigidbody-a1e243591483
Controller vs RigidBody

https://www.youtube.com/watch?v=4Qq7d9elXNA
How to implement player movement using Rigidbody

https://www.youtube.com/watch?v=kdkrjCF0KCo
How to implement button ui

https://www.youtube.com/watch?v=WFkbqdo2OI4
Collisions, Triggers, RigidBodies, and kinematics

CODING

private CharacterController _controller;

void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

This sequence of code is common in Unity.
If we want a script to have access to a certain component WITHIN the object, 
we first start by creating a private variable of type CharacterController and giving it the variable name _controller. 
This isn’t limited to just CharacterController, it works on any component, like RigidBody. Then, the start method is called 
when the script is instantiated. In this case, it assigns the variable _controller to be equal to the CharacterController 
component of that object using the GetComponent method. Now, we have a reference to the CharacterController component in 
this script and can use it however we want. The GetComponent searches for the generic type specified and returns that component 
if it’s found. If the component doesn’t exist in the object, then this produces a compilation error. 



KeyBoard Shortcuts
F: when an object is selected, press F in the scene view to automatically navigate to it


NOTES

Change appearance of object: to change the appearance of the object, you need to create a material. Use Assets->Create->Material. Then apply it by dragging to the object in the scene view. This can also be found in Mesh Renderer field. 

LateUpdate is called after all Update functions have been called. This is useful to order script execution. 
For example a follow camera should always be implemented in LateUpdate because it tracks objects that might have moved inside Update.

Multiplying by time.Deltatime makes movement in the game independant of time and rather dependant on frame rate, which results in
smoother movement in the game.

Apparently there's a way to find GameObjects by tag as well, so that's always an option.

Colliders: you can insert different colliders onto an object. THe objects created directly in Unity such as shapes
automatically have a collider attached to them. You can do a shaped collider or you can do a mesh collider which
forms a collider around the mesh of the object. THe mesh collider is more taxing so avoid when possible.


QUESTIONS

What are the alternatives to .FIND?

TO DO

Implement a flashlight for the player
implement a trigger button for +1 and -1 bomb
*/
