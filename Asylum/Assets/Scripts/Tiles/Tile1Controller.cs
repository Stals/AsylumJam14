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
        StartCoroutine(say("hello brother", 0.5f, player));
        StartCoroutine(say("hi", 1f, brother));
        StartCoroutine(say("how are you", 1f, player));
        StartCoroutine(say("fine thanks", 1f, brother));
        StartCoroutine(say("", 1f, brother));
        StartCoroutine(endCutscene(0f));
    }
    
    public override void darkWorldEntered()
    {

    }
}
