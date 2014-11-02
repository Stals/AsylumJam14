using UnityEngine;
using System.Collections;

public class Tile2Controller : TileContainer {

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
        
        StartCoroutine(startCutscene(1f));
        StartCoroutine(say("we are lost", 0.5f, brother));
        StartCoroutine(say("dont cry", 1f, player));
        StartCoroutine(say("", 1f, brother));
        StartCoroutine(endCutscene(0f));
    }
    
    public override void darkWorldEntered()
    {
        
    }
}
