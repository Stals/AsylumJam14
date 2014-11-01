using UnityEngine;
using System.Collections;

public class ObjectDisabler : Activatable {

    [SerializeField]
    GameObject objectToDisable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override protected void activate(){
        if (objectToDisable)
        {
            objectToDisable.SetActive(false);
        }
    }
}
