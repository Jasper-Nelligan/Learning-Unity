using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private Light light;
    private static bool on = true;
    private static bool pointing_Right = true;

    void Start(){
        light = GetComponent<Light>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && on == true){
            //Debug.Log("Flashlight off");
            light.enabled = false;
            on = false;
        }
        else if(Input.GetKeyDown(KeyCode.F) && on == false){
            //Debug.Log("Flashlight on");
            light.enabled = true;
            on = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && pointing_Right == true){
            //Debug.Log("Rotating to left");
            transform.Rotate(180,0,0);
            pointing_Right = false;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && pointing_Right == false){
            //Debug.Log("Rotating to right");
            transform.Rotate(-180,0,0);
            pointing_Right = true;
        }
    }
    /*
    void Flashlight_Button(){
        if(Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Key was pressed");
            if(flashlight_On == true){
                this.enabled = false;
                flashlight_On = false;
            }
            else{
                this.enabled = true;
                flashlight_On = true;
            }
        }        
    }*/
}
