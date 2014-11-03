using UnityEngine;
using System.Collections;

public class TileContainer : MonoBehaviour {


    float _delay = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void moveCamera()
	{
        Game.Instance.getManager().stopShake();
		Camera.main.transform.position = new Vector3 (transform.position.x,transform.position.y, -10);
	}

    public virtual void tileEntered()
    {
    }

    public virtual void darkWorldEntered()
    {
    }


    public void sayText(string text, float delay, GameObject speaker){
        //StartCoroutine(say("", 0.1f, speaker));
        //StartCoroutine(say(text, 0.1f, speaker));
        //StartCoroutine(say("", delay, speaker));
        StartCoroutine(say("", 0.01f, speaker));
    
    }

    // нужно до сказать пустую строку еще!
    IEnumerator say(string text, float delay, GameObject speaker){
        _delay += delay;

        //float thisDelay = _delay;

        //if (!string.IsNullOrEmpty(text))
       // {
       //     StartCoroutine(say("", 0.1f, speaker));
        //}

        //yield return new WaitForSeconds(thisDelay);
        yield return new WaitForSeconds(_delay);
        Game.Instance.getManager().Speak(text, 0, speaker);
    }



    public IEnumerator changeBrotherState(BrotherController.State state, float delay){
        _delay += delay;
        yield return new WaitForSeconds(_delay);


        WalkingPlayerController player = Game.Instance.getManager().player.GetComponent<WalkingPlayerController>();
        player.LetGoOfBrother();

        BrotherController brother = Game.Instance.getManager().brother.GetComponent<BrotherController>();
        brother.setState(state);
    }

    public IEnumerator startCutscene(float delay){
        _delay += delay;
  
        yield return new WaitForSeconds(_delay);
        // disable input
        Game.Instance.setControlsEnabled(false);
        Game.Instance.setHandsChangeEnabled(false);
        // show borders
        Game.Instance.getManager().setBordersVisible(true);
    }

    public IEnumerator endCutscene(float delay){
        _delay += delay;
        yield return new WaitForSeconds(_delay);
        _delay = 0;
        // enable input
        Game.Instance.setControlsEnabled(true);
        // hide borders
        Game.Instance.getManager().setBordersVisible(false);
        Game.Instance.setHandsChangeEnabled(true);
    }

    public IEnumerator teleportPlayerAndChangeTile(float delay, TileContainer tile, GameObject teleportTarget){
        _delay += delay;
        
        yield return new WaitForSeconds(_delay);

        GameObject player = Game.Instance.getManager().player;;
        player.transform.parent = tile.transform;
        player.transform.position = teleportTarget.transform.position;
        
        tile.moveCamera();
        tile.tileEntered();
    }

}
