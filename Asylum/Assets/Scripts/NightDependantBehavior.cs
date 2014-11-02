using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NightDependantBehavior : MonoBehaviour {

    static List<NightDependantBehavior> allDepandantObjects = new List<NightDependantBehavior>(); 

    public static void ChangeNight(bool isHorror)
    {
        foreach (NightDependantBehavior beh in allDepandantObjects)
        {
            beh.ChangeSprite(isHorror);
        }
    }

    [SerializeField]
    Sprite basic;

    [SerializeField]
    Sprite horror;

	// Use this for initialization
	void Start () {
        allDepandantObjects.Add(this);
	}

    void ChangeSprite(bool isHorror)
    {
        if (isHorror)
        {
            this.GetComponent<SpriteRenderer>().sprite = horror;
        } else
        {
            this.GetComponent<SpriteRenderer>().sprite = basic;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
