using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
	public float jumpForce = 5f;
	public float forwardForce = 0f;

	private Rigidbody2D myRB;
	private bool canJump;

    // Start is called before the first frame update
    void Start() {
        myRB = GetComponent<Rigidbody2D> ();
    }

    // Jump Funktion
    public void Jump(){
    	
    	//is player allowed to jump?
    	if (canJump){
    		canJump = false;

    		//is players position in the left third?
    		if (transform.position.x < -5) {
    			//player can jump forward
    			forwardForce = 0.5f;
    		} else {
    			//player can't jump forward
    			forwardForce = 0f;
    		}

    		myRB.velocity = new Vector2 (forwardForce, jumpForce);

    	}
    }

    void OnCollisionEnter2D(Collision2D other) {
    	canJump = true;
    }
}