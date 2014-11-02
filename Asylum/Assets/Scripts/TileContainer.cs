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
		Camera.main.transform.position = new Vector3 (transform.position.x,transform.position.y,Camera.main.transform.position.z);
	}

    public virtual void tileEntered()
    {
    }

    public virtual void darkWorldEntered()
    {
    }

    public IEnumerator say(string text, float delay, GameObject speaker){
        _delay += delay;

        //if (!string.IsNullOrEmpty(text))
        //{
        //    say("", 0.1f, speaker);
        //}

        yield return new WaitForSeconds(_delay);
        Game.Instance.getManager().Speak(text, 0, speaker);
    }

    public IEnumerator startCutscene(float delay){
        _delay += delay;
  
        yield return new WaitForSeconds(_delay);
        // disable input
        Game.Instance.setControlsEnabled(false);
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
    }

}
