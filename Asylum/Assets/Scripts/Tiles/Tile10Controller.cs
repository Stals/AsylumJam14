using UnityEngine;
using System.Collections;

public class Tile10Controller : TileContainer {

    bool showedNormalDialog = false;

    [SerializeField]
    FatherBehavior father;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void tileEntered()
    {
        GameObject player = Game.Instance.getManager().player;
        GameObject brother = Game.Instance.getManager().brother;

        if (Game.Instance.BadFather == false)
        {
            StartCoroutine(startCutscene(1f));
            sayText("Daddy!", 1f, brother);
            sayText("Son! You’re alive!", 2f, father.gameObject);

            //мелкий куда-то
            StartCoroutine(changeBrotherState(new BrotherController.RunningToFather(), 0.1f));

            sayText("You hoped we were dead?", 1f, player);
            sayText("Bag of gold! Daddy, is it yours?", 1f, brother);

            sayText("We know the truth, dad", 1f, player);

            sayText("You’re tired sweetie", 1f, father.gameObject);
            sayText("come and hug your beloved father", 1f, father.gameObject);


            //папа начинает идти на нас
            // TODO after Delay

            StartCoroutine(startChaise(1f, father));

            player.GetComponent<WalkingPlayerController>().lookingAtFather = true;

            //стаим флагчто папа стал плохой
            Game.Instance.BadFather = true;

            StartCoroutine(endCutscene(0f));
        }

        if (Game.Instance.FatherKilled)
        {
            StartCoroutine(startCutscene(1f));
            sayText("where is our daddy?", 2f, brother);
            sayText("Hold my hand", 1f, player);
            sayText("All is gonna be allright", 1f, player);

            //StartCoroutine(endCutscene(0f));



            // GAME OVER
        }


        /*
cutscene
если отец не убит
    bla bla
//мелкий к папе
папа начинает идти на нас
    стаим флагчто папа стал плохой
по возврашении можно активировать топор - который сразу зарубает отца (отец active false)
ставится флаг что отца убили 
if(papa dead)
по вощвращению новый бла бла
         */
    }


    
    public override void darkWorldEntered()
    {

    }

    public override bool isForest()
    {
        return false;
    }
}
