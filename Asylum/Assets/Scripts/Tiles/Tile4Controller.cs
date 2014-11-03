using UnityEngine;
using System.Collections;

public class Tile4Controller : TileContainer {

    bool showedNormalDialog = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
    }
    
    public override void darkWorldEntered()
    {
        audio.Play();
    }
}
