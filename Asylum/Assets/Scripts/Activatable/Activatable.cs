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

        setImageOpactiy(0.5f);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (isTriggered)
        {
            setImageOpactiy(1f);
            if (Input.GetKey(KeyCode.Space))
            {
                activate();
            }
        } else
        {
            setImageOpactiy(0.5f);
        }
	}

    void setImageOpactiy(float opacity){
        Color color = img.renderer.material.color;
        color.a = opacity;
        img.renderer.material.color = color;
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
