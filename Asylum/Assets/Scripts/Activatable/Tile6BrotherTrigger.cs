using UnityEngine;
using System.Collections;

public class Tile6BrotherTrigger : Activatable {

    GameObject player;
    GameObject brother;
    TileContainer tile;

	// Use this for initialization
	void Start () {
        init();

        player = Game.Instance.getManager().player;
        brother = Game.Instance.getManager().brother;
        
        tile = player.GetComponent<WalkingPlayerController>().getCurrentTile();
	}
	
	// Update is called once per frame
	void Update () {


	}

    override protected void activate(){

        Game.Instance.setControlsEnabled(false);

        tile.startCutscene(0);

        tile.sayText("Aaaaaaa!", 0.5f, brother);
        StartCoroutine(tile.changeBrotherState(new BrotherController.RunningFromSister(), 0.1f));

        StartCoroutine(tile.endCutscene(0f));
        // move brother
    }
}
