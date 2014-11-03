using UnityEngine;
using System.Collections;

public class Tile8Controller : TileContainer {

    bool showedNormalDialog = false;

    [SerializeField]
    GameObject voice;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
        sayText("You are my property!", 2f, voice); 
        sayText("It was a fair deal!", 2f, voice); 

    }
    
    public override void darkWorldEntered()
    {
    }
}
