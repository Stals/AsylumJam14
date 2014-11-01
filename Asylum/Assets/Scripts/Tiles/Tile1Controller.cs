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

        float delay = 0.5f;

        StartCoroutine(say("hello brother", delay, player));
        StartCoroutine(say("hi", delay+1f, brother));
        StartCoroutine(say("how are you", delay+2f, player));
        StartCoroutine(say("fine thanks", delay+3f, brother));
        StartCoroutine(say("", delay+4f, brother));
    }
    
    public override void darkWorldEntered()
    {

    }

    IEnumerator say(string text, float delay, GameObject speaker){
        yield return new WaitForSeconds(delay);
        Game.Instance.getManager().Speak(text, delay, speaker);
    }
}
