using UnityEngine;
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

    [SerializeField]
    SpriteRenderer fakeBrother;

    [SerializeField]
    Sprite witchSprite;

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
        tile.sayText("I’m scared", 0.75f, brotherVoice);
        tile.sayText("Where are you", 0.75f, brotherVoice);

        StartCoroutine(tile.changeImage(1f, fakeBrother, witchSprite));
        StartCoroutine(tile.playSound(0.01f, audio));

        StartCoroutine(tile.teleportPlayerAndChangeTile(2f, tile8, teleportLocation));

        //audio. Play();

        // TODO do this with CD
        /*player.transform.parent = tile8.transform;
        player.transform.position = teleportLocation.transform.position;
        
        tile8.moveCamera();
        tile8.tileEntered();*/
        
        // show witch
        //if(bg && bgChanged){
        //    bg.sprite = bgChanged;
        //}
        
        // play sound
        // teleport 

    }
}
