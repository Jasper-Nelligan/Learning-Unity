using System.Collections;
using System.Collections.Generic; //used for generic ADT's (I believe)
using UnityEngine;
using UnityEngine.UI;  //used so "Text" is recognized as a paramater in GetComponent<Text>


/* To use buttons, you gotta drag the object containing this script to the OnClick() method in the button object. Then, we can
specify what method of this script can be activated when the button is clicked. Make sure that the method is public
so that it can be accessed by the button. I belive the method could be called anything but it makes the most sense to 
name it something like "button_click"*/

public class Click_Sphere_Subtract : MonoBehaviour
{

    private GameObject Bomb;
    [SerializeField] private GameObject player;
    private Stack<GameObject> bomb_Stack;
    private GameObject parent;
    //private Click_Sphere_Add script;
    
    public AudioSource bomb_subtract_sound;
    void Start()
    {
        parent = transform.parent.gameObject;
        bomb_Stack = transform.parent.gameObject.GetComponent<Bomb_Stack_Script>().bomb_Stack;
    
        //Bomb = GameObject.Find("Bomb"); //apparently Find is a bad practice because it is slower
        //bomb_Stack = GameObject.Find("Sphere_Collider_Add").GetComponent<Click_Sphere_Add>().bomb_Stack;
        //this is apparently how to use the GetComponent<>() method to get access to a certain variable of another script
        //on another object
        //bomb_Stack = Sphere_Collider_Add.GetComponent<Click_Sphere_Add>().bomb_Stack;
        //test = GameObject.Find("Sphere_Collider_Add");
        //Click_Sphere_Add script = test.GetComponent<Click_Sphere_Add>();
    }
    
    void OnCollisionEnter(Collision playerCollider){
    //Debug.Log ("Sphere +1 pressed");
        Debug.Log("Subtract parent is " + parent.name);

        Debug.Log("Subtract count is changed: " + transform.parent.gameObject.GetComponent<Bomb_Stack_Script>().bomb_Stack.Count);
        Debug.Log("Subtract count is changed: " + bomb_Stack.Count);

        var collidedObject = playerCollider.gameObject;
        if (collidedObject == player){  //if collided body is player
            Debug.Log("Triggered");
            bomb_subtract_sound.Play();
            if (bomb_Stack.Count >= 0){
                Destroy(bomb_Stack.Pop());
            }
        }
    }
}
