using UnityEngine;
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
        StartCoroutine(say("im scared", 0.5f, brother));
        StartCoroutine(say("drov", 1f, player));
        StartCoroutine(say("witch", 1f, brother));
        StartCoroutine(say("papa", 1f, player));
        StartCoroutine(say("", 1f, player));
        StartCoroutine(endCutscene(0f));
    }
    
    public override void darkWorldEntered()
    {

    }
}
