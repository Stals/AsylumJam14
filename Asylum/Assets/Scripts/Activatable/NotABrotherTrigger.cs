﻿using UnityEngine;
using System.Collections;

public class NotABrotherTrigger : Activatable {
        
    /*[SerializeField]
    GameObject objectToDisable;
    
    [SerializeField]
    SpriteRenderer bg;
    
    [SerializeField]
    Sprite bgChanged;
    */
    [SerializeField]
    GameObject brotherVoice;

    [SerializeField]
    GameObject teleportLocation;

    [SerializeField]
    TileContainer tile8;

    GameObject player;
    GameObject brother;
    TileContainer tile;
    
    // Use this for initialization
    void Start () {
        init();
        
        player = Game.Instance.getManager().player;
        brother = Game.Instance.getManager().brother;
        
        tile = player.GetComponent<WalkingPlayerController>().getCurrentTile();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
    
    override protected void activate(){
        // brother voice
        tile.startCutscene(0);
        tile.sayText("sister?", 1f, brotherVoice);

        // TODO do this with CD
        player.transform.parent = tile8.transform;
        player.transform.position = teleportLocation.transform.position;
        
        tile8.moveCamera();
        tile8.tileEntered();
        
        // show witch
        //if(bg && bgChanged){
        //    bg.sprite = bgChanged;
        //}
        
        // play sound
        // teleport 

    }
}
