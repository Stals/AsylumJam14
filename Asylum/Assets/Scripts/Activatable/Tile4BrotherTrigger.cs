using UnityEngine;
using System.Collections;

public class Tile4BrotherTrigger : Activatable {

    bool activated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (activated)
        {
           //палим что ты нажал кнопку и тогда
            // расцепляем тебя с братом
            // двигаем брата

        }
	}

    override protected void activate(){
        Game.Instance.setControlsEnabled(false);

        GameObject player = Game.Instance.getManager().player;
        GameObject brother = Game.Instance.getManager().brother;

        TileContainer tile = player.GetComponent<WalkingPlayerController>().getCurrentTile();
        StartCoroutine(tile.startCutscene(0));

        StartCoroutine(tile.say("monsters", 0.5f, brother));
        StartCoroutine(tile.say("me stay=)", 0.5f, brother));
        StartCoroutine(tile.say("ok", 1f, player));
        StartCoroutine(tile.say("lets separate", 1f, player));

        StartCoroutine(tile.say("", 1f, player));
        StartCoroutine(tile.endCutscene(0f));
    }


}
