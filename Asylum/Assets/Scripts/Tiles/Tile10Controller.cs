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
            sayText("my children", 2f, father.gameObject);
            sayText("father", 1f, brother);
            //мелкий к папе
            //???

            //папа начинает идти на нас
            // TODO after Delay
            father.chasingDaughter = true;

            player.GetComponent<WalkingPlayerController>().lookingAtFather = true;

            //стаим флагчто папа стал плохой
            Game.Instance.BadFather = true;

            StartCoroutine(endCutscene(0f));
        }

        if (Game.Instance.FatherKilled)
        {
            StartCoroutine(startCutscene(1f));
            sayText("where is father", 2f, brother);
            sayText("he will catch up", 1f, player);
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
