﻿using UnityEngine;
using System.Collections;

public class Tile1Controller : TileContainer {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
        GameObject player = Game.Instance.getManager().player;
        GameObject brother = Game.Instance.getManager().brother;

        // не находит потому что ищет еще в момент создания GameMAnager'a

        StartCoroutine(startCutscene(0));
        sayText("I’m scared", 0.5f, brother);
        sayText("Daddy asked us to collect twigs", 2f, player);
        sayText("There is a witch deep in the forest", 2f, brother);
        sayText("I've heard that she eats children", 2f, brother);
        sayText("Ok let’s go back to our father", 2f, player);
        StartCoroutine(endCutscene(0f));
    }
    
    public override void darkWorldEntered()
    {

    }
}
