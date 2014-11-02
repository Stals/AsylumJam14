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
                StartCoroutine(tile.endCutscene(0.1f));
                Game.Instance.getManager().setLetGoHintVisible(false);
                // двигаем брата
                // hide text to press button
            }
        }
	}

    override protected void activate(){
        activated = true;

        Game.Instance.setControlsEnabled(false);


        tile.startCutscene(0);

        tile.sayText("monsters", 0.5f, brother);
        tile.sayText("me stay=)", 0.5f, brother);
        tile.sayText("ok", 1f, player);
        tile.sayText("lets separate", 0.1f, player);


        Game.Instance.setReachedHandsAbility(true);
        Game.Instance.setHandsChangeEnabled(true);
        // show label with text to press button

        Game.Instance.getManager().setBordersVisible(true);
        Game.Instance.getManager().setLetGoHintVisible(true);
    }
}
