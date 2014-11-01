using UnityEngine;
using System.Collections;

public class TileContainer : MonoBehaviour {

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

    /*public IEnumerator say(string text, float delay, GameObject speaker) {
        Game.Instance.getManager().Speak(text, delay, speaker);
        yield return new WaitForSeconds(delay);
    }*/
}
