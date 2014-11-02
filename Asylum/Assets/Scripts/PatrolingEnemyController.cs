using UnityEngine;
using System.Collections;

public class PatrolingEnemyController : MonoBehaviour {

    #region Classes

    public class StatesHolder
    {
        public enum States
        {
            walking,
            chasingPlayer,
            returningToRoute
        }
        
        public State[] StatesArray = new State[]{new Walking(), new ChasingEnemy(), new ReturningToRoute()};
    }
        
    abstract public class State
    {
        abstract public void Action(PatrolingEnemyController me);
    }
    
    class Walking : State
    {
        override public void Action(PatrolingEnemyController me)
        {
            if (me.EnemyNearby() && me.DistanceIsClose())
            {
                me.myCachePos = me.transform.position;
                me.myMoveBehavior.Pause();
                me.CurrentState = me.states.StatesArray[(int)StatesHolder.States.chasingPlayer];
            }
        }
    }

    class ChasingEnemy : State
    {
        override public void Action(PatrolingEnemyController me)
        {
            me.ChasePlayer();
            if (!me.DistanceIsClose()||(!me.EnemyNearby()))
            {
                me.CurrentState = me.states.StatesArray[(int)StatesHolder.States.returningToRoute];
            }
        }
    }
    
    class ReturningToRoute : State
    {
        override public void Action(PatrolingEnemyController me)
        {
            me.ReturnToRoute();
            if (me.CanResumeWalk())
            {
                me.myMoveBehavior.Resume();
                me.CurrentState = me.states.StatesArray[(int)StatesHolder.States.walking];
            }
        }
    }
    #endregion

    const float killRadius = 0.3f;

	[SerializeField]
	float agroRadius = 1.0f;

	[SerializeField]
	float leashRadius = 3.0f;

    [SerializeField]
    float resumeWalkRadius = 0.1f;

	State currentState;

	public Vector3 enemyPos = new Vector3();
    public Vector3 myCachePos = new Vector3();

	public hoMove myMoveBehavior;

    public StatesHolder states = new StatesHolder();

    public State CurrentState
    {
        get { return currentState;}
        set
        {               
            currentState = value;
        }
    }


	// Use this for initialization
	void Start () {
        currentState = states.StatesArray[(int)StatesHolder.States.walking];
		myMoveBehavior = GetComponent<hoMove> ();
	}
	
	// Update is called once per frame
	void Update () {
        currentState.Action(this);
    }

    public void ChasePlayer()
    {
        Vector3 vecToEnemy = enemyPos - transform.position;
        transform.position +=  myMoveBehavior.speed * 1.0f / 60.0f * vecToEnemy.normalized;
        transform.rotation = Quaternion.LookRotation(vecToEnemy);
    }

    public void ReturnToRoute()
    {
        Vector3 vecToRoute = myCachePos - transform.position;
        transform.position +=  myMoveBehavior.speed * 1.0f / 60.0f * vecToRoute.normalized;
        transform.rotation = Quaternion.LookRotation(vecToRoute);
    }

    public bool CanResumeWalk()
    {
        Vector3 vecToRoute = myCachePos - transform.position;
        if (vecToRoute.magnitude < resumeWalkRadius)
        {
            return true;
        } else
        {
            return false;
        }
    }

	public bool EnemyNearby()
	{
        bool result = false;

        float distToPlayer = Vector3.Distance(Game.Instance.getManager().player.transform.position, transform.position);
        if (distToPlayer < agroRadius) 
		{
			enemyPos = Game.Instance.getManager().player.transform.position;
            result = true;
		}

        float distToPlayerBrother = Vector3.Distance(Game.Instance.getManager().brother.transform.position, transform.position); 
        if (distToPlayerBrother < agroRadius) 
		{
			enemyPos = Game.Instance.getManager().brother.transform.position;
            result = true;
		}

        if (Mathf.Min(distToPlayer, distToPlayerBrother) < killRadius)
        {
            Game.Instance.getManager().player.GetComponent<WalkingPlayerController>().Die();
        }

		return result;
	}

	public bool DistanceIsClose()
	{

        float length = float.MaxValue;


        foreach (Transform point in myMoveBehavior.pathContainer.waypoints)
        {
            float nowL = Vector3.Distance(transform.position, point.position);
            if (nowL < length)
            {
                length = nowL;
            }
        }

        if (length < leashRadius)
        {
            return true;
        } else
        {
            return false;
        }
    }

}
