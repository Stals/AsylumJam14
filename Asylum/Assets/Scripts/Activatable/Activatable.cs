using UnityEngine;
using System.Collections;

public class Activatable : MonoBehaviour {

    bool isTriggered = false;

	// Use this for initialization
	void Start () {
	    // TODO add image to center
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isTriggered)
        {
            if (Input.GetKey (KeyCode.Space)) {
                activate();
            }
        }
	}

    /*
        ifistrigger - run overloaded activate
     */
    protected virtual void activate(){
        // overriden method will be called
    }

    void OnTriggerEnter2D(Collider2D coll) {
        isTriggered = true;
    }
    
    void OnTriggerExit2D(Collider2D coll) {
        isTriggered = false;
    }
}
