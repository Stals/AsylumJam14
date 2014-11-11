using UnityEngine;
using System.Collections;

public class Tile9Controller : TileContainer {

    bool showedNormalDialog = false;

    [SerializeField]
    GameObject fatherTeleportLocation;

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

            sayText("I thought I lost you", 1f, brother);
            sayText("Everything is OK", 1f, player);

/*
inside activate - look at father = false
             */
        } else
        {
            Game.Instance.getManager().father.transform.position = fatherTeleportLocation.transform.position;
        }

    }
    
    public override void darkWorldEntered()
    {
    }
}
