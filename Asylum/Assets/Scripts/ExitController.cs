using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	[SerializeField]
	GameObject connectedExit;

    bool isTriggered = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTriggered(bool v)
    {
        isTriggered = v;
    }

	void OnTriggerEnter2D(Collider2D coll) {
		if (isTriggered) {
			return;
		}

		if (!connectedExit) {
			return;
		}

		coll.transform.parent = connectedExit.transform.parent;
		coll.transform.position = connectedExit.transform.position;

		connectedExit.GetComponent<ExitController> ().setTriggered(true);
		connectedExit.transform.parent.GetComponent<TileContainer>().moveCamera ();
		/*if (coll.gameObject.tag == "Line") {
		}*/
	}

    void OnTriggerExit2D(Collider2D coll) {
        isTriggered = false;
    }
}
