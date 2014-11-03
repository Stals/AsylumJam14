using UnityEngine;
using System.Collections;

public class Tile9Controller : TileContainer {

    bool showedNormalDialog = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
        if (!Game.Instance.BadFather)
        {
            GameObject player = Game.Instance.getManager().player;
            GameObject brother = Game.Instance.getManager().brother;

            sayText("i thought i lost you", 1f, brother);
            sayText("all ok", 1f, player);

/*
inside activate - look at father = false
             */
        }

    }
    
    public override void darkWorldEntered()
    {
    }
}
