using UnityEngine;
using System.Collections;

public class Activatable : MonoBehaviour {

    [SerializeField]
    bool isPressable = true; // if false - just entering will triger

    [SerializeField]
    bool isOnce = true; // activatable only once

    bool isTriggered = false;
    GameObject img;

    bool wasActivated = false;

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

        setImageOpactiy(0.5f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (wasActivated)
        {
            setImageOpactiy(0f);
            return;
        }

        if (isPressable)
        {
            if (isTriggered)
            {
                setImageOpactiy(1f);
                if (Input.GetKey(KeyCode.Space))
                {
                    wasActivated = true;
                    activate();
                }
            } else
            {
                setImageOpactiy(0.5f);
            }
        } else
        {
            if(isTriggered){
                wasActivated = true;
                activate();
            }
        }
	}

    void setImageOpactiy(float opacity){
        if (img)
        {
            Color color = img.renderer.material.color;
            color.a = opacity;
            img.renderer.material.color = color;
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
