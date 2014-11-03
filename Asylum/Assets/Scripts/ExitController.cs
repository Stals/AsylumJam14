using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	[SerializeField]
	GameObject connectedExit;

    bool isTriggered = false;

	// Use this for initialization
	void Start () {
        Color color = renderer.material.color;
        color.a = 0f;
        renderer.material.color = color;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setTriggered(bool v)
    {
        isTriggered = v;
    }

	void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {

    		if (isTriggered) {
    			return;
    		}

    		if (!connectedExit) {
    			return;
    		}

    		coll.transform.parent = connectedExit.transform.parent;
    		coll.transform.position = connectedExit.transform.position;

    		connectedExit.GetComponent<ExitController> ().setTriggered(true);
            TileContainer tile = connectedExit.transform.parent.GetComponent<TileContainer>();
            tile.moveCamera();
            tile.tileEntered();

              WalkingPlayerController player = Game.Instance.getManager().player.GetComponent<WalkingPlayerController>();
              BrotherController brother = Game.Instance.getManager().brother.GetComponent<BrotherController>();

            if(player.CurrentBrotherState is WalkingPlayerController.WithBrother){
                Vector3 myPos = player.transform.position;

                myPos = myPos - 0.5f * player.GetComponent<WalkingPlayerController>().lastV.normalized;
                brother.transform.position = myPos; 
            }
        }
	}

    void OnTriggerExit2D(Collider2D coll) {
        isTriggered = false;
    }
}
