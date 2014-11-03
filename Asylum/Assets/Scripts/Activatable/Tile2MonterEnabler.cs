﻿using UnityEngine;
using System.Collections;

public class Tile2MonterEnabler : Activatable {

    [SerializeField]
    GameObject enemy1;

    [SerializeField]
    GameObject enemy2;

	// Use this for initialization
	void Start () {
        init();
	}
	
	// Update is called once per frame
	void Update () {
	}

    override protected void activate(){
        enemy1.SetActive(true);
        enemy2.SetActive(true);

        GameObject player = Game.Instance.getManager().player;
        GameObject brother = Game.Instance.getManager().brother;

        TileContainer tile = player.GetComponent<WalkingPlayerController>().getCurrentTile();

        tile.sayText("im scared", 0.5f, brother);
        tile.sayText("norm", 1f, player);
        StartCoroutine(tile.endCutscene(0f));
    }
}
