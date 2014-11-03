using UnityEngine;
using System.Collections;

public class KillFatherActivatable : Activatable {

    [SerializeField]
    GameObject objectToDisable;
    
    [SerializeField]
    SpriteRenderer bg;
    
    [SerializeField]
    Sprite bgChanged;
    
    [SerializeField]
    bool resultActive = false;
    
    // Use this for initialization
    void Start () {
        init();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    override protected void activate(){

        if (Game.Instance.BadFather)
        {
            if (objectToDisable)
            {
                objectToDisable.SetActive(resultActive);
            }
            if (bg && bgChanged)
            {
                bg.sprite = bgChanged;
            }

            Game.Instance.FatherKilled = true;

        } else
        {
            wasActivated = false;
        }
    }
}