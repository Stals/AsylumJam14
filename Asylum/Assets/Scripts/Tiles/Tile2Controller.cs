using UnityEngine;
using System.Collections;

public class Tile2Controller : TileContainer {

    bool showedNormalDialog = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
        if (!showedNormalDialog)
        {
            showedNormalDialog = true;

            GameObject player = Game.Instance.getManager().player;
            GameObject brother = Game.Instance.getManager().brother;
        
            StartCoroutine(startCutscene(1f));
            sayText("We haven’t been here", 2f, brother);
            sayText("We’re lost", 2f, brother);
            sayText("It’s gonna be ok", 2f, player);
            sayText("Please, don’t cry sweetie", 2f, player);
            StartCoroutine(endCutscene(0f));

        }
    }
    
    public override void darkWorldEntered()
    {
        
    }
}
