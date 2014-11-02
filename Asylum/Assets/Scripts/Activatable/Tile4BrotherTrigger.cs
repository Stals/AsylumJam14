using UnityEngine;
using System.Collections;

public class Tile4BrotherTrigger : Activatable {

    bool activated = false;

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

        if (activated)
        {
           //палим что ты нажал кнопку и тогда
            // расцепляем тебя с братом

            if (Input.GetKeyDown(KeyCode.Tab)) 
            {
                StartCoroutine(tile.endCutscene(0f));
                // двигаем брата
                // hide text to press button
            }
        }
	}

    override protected void activate(){
        activated = true;

        Game.Instance.setControlsEnabled(false);


        tile.startCutscene(0);

        StartCoroutine(tile.say("monsters", 0.5f, brother));
        StartCoroutine(tile.say("me stay=)", 0.5f, brother));
        StartCoroutine(tile.say("ok", 1f, player));
        StartCoroutine(tile.say("lets separate", 1f, player));

        StartCoroutine(tile.say("", 1f, player));

        Game.Instance.setReachedHandsAbility(true);
        Game.Instance.setHandsChangeEnabled(true);
        // show label with text to press button
    }
}
