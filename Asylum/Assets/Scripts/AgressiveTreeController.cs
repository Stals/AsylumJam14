using UnityEngine;
using System.Collections;

public class AgressiveTreeController : MonoBehaviour {

    const float FPSfloat = 60.0f;

    #region Classes
    
    abstract public class State
    {
        public enum States
        {
            waiting,
            attack,
            waitingInAttack,
            returning
        }
        
        public static State[] StatesArray = new State[]{new Waiting(), new Attack(), new WaitingInAttack(), new Returning()};

        abstract public void Action(AgressiveTreeController me);
    }
    
    class Waiting : State
    {
        override public void Action(AgressiveTreeController me)
        {
            me.currentCounter++;
            if (me.currentCounter / FPSfloat > me.waitTime)
            {
                me.currentCounter = 0;
                me.currentState = StatesArray[(int)States.attack];
            }

        }
    }
    
    class Attack : State
    {
        override public void Action(AgressiveTreeController me)
        {
            me.currentCounter++;
            Vector3 pos = me.transform.localPosition;
            pos.x += me.OutSpeed;
            me.transform.localPosition = pos; 
            if (pos.x > me.startX + me.outSize)
            {
                me.currentCounter = 0;
                me.currentState = StatesArray[(int)States.waitingInAttack];
            }
        }
    }
    
    class WaitingInAttack : State
    {
        override public void Action(AgressiveTreeController me)
        {
            me.currentCounter++;
            if (me.currentCounter / FPSfloat > me.stuckOutTime)
            {
                me.currentCounter = 0;
                me.currentState = StatesArray[(int)States.returning];
            }
        }
    }

    class Returning : State
    {
        override public void Action(AgressiveTreeController me)
        {
            me.currentCounter++;
            Vector3 pos = me.transform.localPosition;
            pos.x -= me.InSpeed;
            me.transform.localPosition = pos; 
            if (pos.x < me.startX)
            {
                me.currentCounter = 0;
                me.currentState = StatesArray[(int)States.waiting];
            }
        }
    }
    #endregion

    [SerializeField]
    float waitTime = 1f;

    [SerializeField]
    float outTime = 1f;

    [SerializeField]
    float stuckOutTime = 1f;

    [SerializeField]
    float inTime = 1f;

    [SerializeField]
    float outSize = 1.4f;


    float outSpeed;
    float inSpeed;
    float startX;

    public float OutSpeed
    {
        get { return outSpeed; }
    }

    public float InSpeed
    {
        get { return inSpeed; }
    }

    public int currentCounter = 0;

    State currentState;

	// Use this for initialization
	void Start () {
        outSpeed = outSize / outTime / FPSfloat;
        inSpeed = outSize / inTime / FPSfloat;
        startX = transform.localPosition.x;
        currentState = State.StatesArray[(int)State.States.waiting];
	}
	
	// Update is called once per frame
	void Update () {
        currentState.Action(this);
	}

    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.gameObject.name == "player") || (col.gameObject.name == "brother"))
        {
            Game.Instance.getManager().player.GetComponent<WalkingPlayerController>().Die();
        }
    }


}
