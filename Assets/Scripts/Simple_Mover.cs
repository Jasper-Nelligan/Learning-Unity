﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//A simple way of proving UI to control the character. Doesn't work great and colliding
//doesn't seem to work very well.

public class Box_Mover : MonoBehaviour
{
    [SerializeField]  
    private float speed = 1; 

    // Update is called once per frame
    void Update()
    { 

      float horizontal = Input.GetAxis("Horizontal");
      float vertical = Input.GetAxis("Vertical");

      Vector3 movement = new Vector3(horizontal, vertical);

      transform.position += movement * Time.deltaTime * speed;
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    SceneManager.LoadScene(0);  //Upon colliding with any object, reload the scene
    //}
}