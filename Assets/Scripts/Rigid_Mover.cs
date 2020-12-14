using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*This class uses a rigid body as a means to move the character, instead of using a Character Controller.
The difference between the two is:

Character Controller: The core concept behind the Character Controller is that it provides 
basic collider responses without any physics. Basically, you will move your player like 
you would do with a Transform, but you can’t go through colliders.The main advantage of using this 
technique is the amount of control we’ll have on how your player behaves, but the downfall is that 
you’ll have to code practically everything. So basically use this if you want your character to act
in accordance to custom physics.

Rigid Body: rigidbody will more precisely follow physics, and inherits many physics elements so we don't
have to program physics ourselves. This is the go to method if you don't need your character to behave outside
normal physics.

If there's no rigidbody then Unity assumes the object is static, non-moving. Unity does not bother testing 
for collisions BETWEEN static objects. So the purpose of having a kinematic rigidbody, rather than no rigidbody, 
is to turn on collision detection between this object and all other colliders in the scene (even the static ones.)
Effectively you are letting Unity know that this object moves around, so Unity will then do collision-detection 
between it and everything else.

*/
public class Rigid_Mover : MonoBehaviour{
    private Rigidbody playerBody;

    private Vector3 inputVector;
    
    private float speed = 8f;
    [SerializeField]
    private float jumpSpeed = 20f; //used for jumping method 1
    private float jumpHeight = 1f; //used for jumping method 2
    [SerializeField]
    private float gravityMultiplier = 2f; //used for jumping method 3
    [SerializeField]
    private float lowJumpMultiplier = 1.5f;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Ground" && isJumping == true)
        {
            isJumping = false; //Player has hit the ground and is done jumping
        }
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * speed,playerBody.velocity.y,0);
        if (transform.position.y < -10)  //if player falls off the map
        {
            Respawn();
        }
    }

    // FixedUpdate is where the physics related code is supposed to go
    private void FixedUpdate()
    {

        //GetKey is different from GetKeyDown. GetKey searches for if the specific key is being held down. GetKeyDown checks
        //if the button was pressed once, so holding it down will have no effect.
        if (Input.GetKey(KeyCode.UpArrow) && isJumping == false)  //controls for jump effect  
        {
            //First way of implementing jump
            playerBody.AddForce(Vector3.up * jumpSpeed * jumpSpeed); //squaring jumpSpeed here because jumpSpeed too low otherwise

            /*Second way of implementing jump. VelocityChange is instant and mass independant, and is used here for an
            instant reaction. Not using VelocityChange results in cube barely jumping*/
            //playerBody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y),ForceMode.VelocityChange);

            isJumping = true;

        }
        else{  //not having an else here seems to make the cube jump higher when it is already moving
            playerBody.velocity = inputVector;  //move character left or right
        }
        //Third way of implementing jump. This is a less "floaty" way of jumping.
        
        if (isJumping == true && playerBody.velocity.y == 0){  //if player is falling, apply extra gravity
            playerBody.AddForce(Vector3.up * Physics.gravity.y * gravityMultiplier * Time.deltaTime);
            //Debug.Log("Gravity multiplied");
        } else if (isJumping == true && playerBody.velocity.y > 0 && !Input.GetKey(KeyCode.UpArrow)){
            playerBody.AddForce(Vector3.up * Physics.gravity.y * lowJumpMultiplier * Time.deltaTime);
            //Debug.Log("lowfallmuliplied");
        }
        
    }

    private void Respawn()
    {
        transform.position = new Vector3(0,0,0);

        var rigidbody = GetComponent<Rigidbody>();   //this is so that when the player respawns, their velocity is reset to 0
        rigidbody.velocity = Vector3.zero;
    }
}
