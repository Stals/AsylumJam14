using UnityEngine;
using System.Collections;

public class DialogTrigger : Activatable {

    [SerializeField]
    GameObject speaker;

    [SerializeField]
    string text;

	// Use this for initialization
	void Start () {
        init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override protected void activate(){
        GameObject player = Game.Instance.getManager().player;
        GameObject brother = Game.Instance.getManager().brother;
        TileContainer tile = player.GetComponent<WalkingPlayerController>().getCurrentTile();

        tile.sayText(text, 2f, speaker);
    }
}
