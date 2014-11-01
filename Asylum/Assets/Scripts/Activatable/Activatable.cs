using UnityEngine;
using System.Collections;

public class Activatable : MonoBehaviour {

    bool isTriggered = false;
    GameObject img;

	// Use this for initialization
	void Start () {
        init();
	}

    protected void init()
    {
        Vector2 currentPosition = transform.position;
        img = (GameObject)(Instantiate(Game.Instance.getManager().activatableImagePrefab,
                                                  new Vector3(currentPosition.x,
                    currentPosition.y,
                    0), transform.rotation));
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
