using UnityEngine;
using System.Collections;

public class ObjectDisabler : Activatable {

    [SerializeField]
    GameObject objectToDisable;

    [SerializeField]
    SpriteRenderer bg;

    [SerializeField]
    Sprite bgChanged;

	// Use this for initialization
	void Start () {
        init();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    override protected void activate(){
        if (objectToDisable)
        {
            objectToDisable.SetActive(false);
            if(bg && bgChanged){
                bg.sprite = bgChanged;
            }
        }
    }
}
