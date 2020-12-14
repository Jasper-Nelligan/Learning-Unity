using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Simple_Trigger : MonoBehaviour
{
    /*this is the rigid body object input into the inspector. Seeing that the variable is public hints that this
    object will show up in the inspector.*/
    public GameObject player;
    private GameObject Bomb;

    /*This method is to detect collisions ONLY from the player */
    void OnCollisionEnter(Collision playerCollider){ 
        /* Collision information is passed into this method, which includes information such as where exactly
        the collision was detected and at what velocity it was going etc. To gain access to the object
        that caused the collision you can do so by doing collisionname.gameObject and then dot whatever.

        For the OnTrigger method, be sure to use the keyword Collider instead of Collision! Also to gain access to
        the rigid body that triggered it you can do so by doing collidername.attachedRigidbody. Also if
        you want something to be a trigger you need to check the "Is Trigger" on the collider
        of the game object. */

        //only trigger if the triggerBody matches
        var collidedObject = playerCollider.gameObject; 
        /*I believe "var" is only used here because we don't yet know what this variable will be assigned to.
        But I believe that "Rigidbody" might work instead of Var here. */
        if (collidedObject == player){  //if collided body is player
            Debug.Log("Triggered");
        }
    }
    //for this project I'm not going to use this script because this is just a simple collision detection script.
    //I'm gonna continue to use the Sphere Add and Subtract scripts and just add the OnCollisionEnter methods
    //to them instead of the button click methods. Also for a future note I could have just combined the two
    //methods in one script so that it could include both the Collision method and the button_click method
}
