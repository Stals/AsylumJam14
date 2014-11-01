using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	[SerializeField]
	GameObject connectedExit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (!connectedExit) {
			return;
		}

		int i = 0;

		//coll.gameObject.SetActive (false);

		coll.transform.parent = connectedExit.transform.parent;
		coll.transform.position = connectedExit.transform.position;


		connectedExit.transform.parent.GetComponent<TileContainer>().moveCamera ();

		//coll.transform.position = 

		/*if (coll.gameObject.tag == "Line") {
			LineController lineController = coll.gameObject.GetComponent<LineController> ();
			if (lineController.state == LineController.State.active) {
				DestroySelf ();
			}
			
		} else if (coll.gameObject.tag == "Heart") {
			
			coll.gameObject.GetComponent<HeartController>().damage();
			Game.Instance.getManager().shake();
			DestroySelf ();
		}*/
	}
}
