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
                Game.Instance.setControlsEnabled(true);
                Game.Instance.getManager().setBordersVisible(false);
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

        tile.sayText("No! They gonna kill us! ", 1f, brother);
        tile.sayText("I can’t go farther", 1f, brother);
        tile.sayText("We need to get out of this creepy forest.", 2.5f, player);
        tile.sayText("Stay here, I’ll trying to do something", 2.5f, player);
        tile.sayText("No. Don’t leave me!", 1.5f, brother);
        tile.sayText("I’ll be right there", 1.5f, player);

        Game.Instance.setReachedHandsAbility(true);
        Game.Instance.setHandsChangeEnabled(true);
        // show label with text to press button

        Game.Instance.getManager().setBordersVisible(true);
        Game.Instance.getManager().setLetGoHintVisible(true);
    }
}
