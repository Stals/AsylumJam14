using UnityEngine;
using System.Collections;

public class Activatable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    // TODO add image to center
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*
        ifistrigger - run overloaded activate
     */
    protected virtual void activate(){
        // overriden method will be called
    }
}
