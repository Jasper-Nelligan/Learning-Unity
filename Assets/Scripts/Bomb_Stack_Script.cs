using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Stack_Script : MonoBehaviour{
    
    public Stack<GameObject> bomb_Stack; //a stack for holding all the bomb objects
    
    void Start(){
        /*Below we are getting a reference to the bomb object so we can instantiate more of them. This is the scripted way of doing this,
        but the way I did it for this script was to Serialize the Bomb GameObject field so that I could obtain a reference to it by
        directly dragging and dropping it into the inspector of the Sphere_Add_Button.*/

        //Bomb = GameObject.Find("Bomb");
        //here we are getting a reference to the bomb object so we can instantiate more of them

        /*Below is a method of getting a reference to the text of the button pressed. Previously I was using this to check if the
        add or subtract button was pressed since each button refered to the same script, but after ceating seperate scripts for
        each button this was no longer neccesary*/

        //txt = GetComponentInChildren<Text>();

        bomb_Stack = new Stack<GameObject>(); //creates a stack storing GameObjects
    }
}

