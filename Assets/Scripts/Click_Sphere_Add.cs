using System.Collections;
using System.Collections.Generic; //used for generic ADT's (I believe)
using UnityEngine;
using UnityEngine.UI;  //used so "Text" is recognized as a paramater in GetComponent<Text>


/* To use buttons, you gotta drag the object containing this script to the OnClick() method in the button object. Then, we can
specify what method of this script can be activated when the button is clicked. Make sure that the method is public
so that it can be accessed by the button*/

public class Click_Sphere_Add : MonoBehaviour{

    private GameObject BombClone;
    private Stack<GameObject> bomb_Stack; //a stack for holding all the bomb objects
    [SerializeField] private GameObject player; //for detecting if the collision was from the player
    [SerializeField] private GameObject Bomb;  //I serialized this field so I could drag and drop the Bomb prefab into the inspector
    //this allows for Bomb to be instantiated without needed to exist in the game beforehand. Note that Bomb as a prefab still has
    //all it's normal properties including it's spawn script.
    public AudioSource add_Sphere_Sound;

    //this method is public so it can be used by the button
    /*public void button_click(){
        //Debug.Log ("Sphere +1 pressed");
        BombClone = Instantiate(Bomb);
        BombClone.name = "Bomb" + bomb_Stack.Count;
        bomb_Stack.Push(BombClone); //note that "Push" has to be capitalized
    }*/

    void Start(){
        bomb_Stack = transform.parent.gameObject.GetComponent<Bomb_Stack_Script>().bomb_Stack;
    }

    void OnCollisionEnter(Collision playerCollider){
    //Debug.Log ("Sphere +1 pressed");
        var collidedObject = playerCollider.gameObject;

        if (collidedObject == player){  //if collided body is player
            Debug.Log("Triggered");
            add_Sphere_Sound.Play();
            
            BombClone = Instantiate(Bomb);
            BombClone.name = "Bomb" + bomb_Stack.Count;
            bomb_Stack.Push(BombClone); //note that "Push" has to be capitalized
        }
    }
}