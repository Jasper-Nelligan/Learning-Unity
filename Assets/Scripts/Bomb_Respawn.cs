using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Respawn : MonoBehaviour
{
    private void OnEnable(){
        /*I forget what this does, but I assume it's whenever a new ball object is created
        then the OnEnable method gets called, and so when a new ball is spawned it'll spawn
        randomly according to the respawn method*/
        Respawn();
    }

    // Update is called once per frame
    void Update(){
        if (transform.position.y < -10)
            Respawn();  //checks if the ball has fallen off the platform  
    }

    private void Respawn(){

        float randomX = UnityEngine.Random.Range(-8,8);
        float randomY = UnityEngine.Random.Range(10,20);

        transform.position = new Vector3(randomX,randomY);

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
    }
}
