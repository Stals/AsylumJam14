using UnityEngine;
using System.Collections;

public interface State
{
    void Action(PatrolingEnemyController me);
}

class Walking : State
{
    public void Action(PatrolingEnemyController me)
    {
        if (me.EnemyNearby() && me.DistanceIsClose())
        {
            me.myCachePos = me.transform.position;
            me.myMoveBehavior.Pause();
            me.CurrentState = PatrolingEnemyController.StatesArray[(int)PatrolingEnemyController.States.chasingPlayer];
        }
    }
}

class ChasingEnemy : State
{
    public void Action(PatrolingEnemyController me)
    {
        me.ChasePlayer();
        if (!me.DistanceIsClose()||(!me.EnemyNearby()))
        {
            me.CurrentState = PatrolingEnemyController.StatesArray[(int)PatrolingEnemyController.States.returningToRoute];
        }
    }
}

class ReturningToRoute : State
{
    public void Action(PatrolingEnemyController me)
    {
        me.ReturnToRoute();
        if (me.CanResumeWalk())
        {
            me.myMoveBehavior.Resume();
            me.CurrentState = PatrolingEnemyController.StatesArray[(int)PatrolingEnemyController.States.walking];
        }
    }
}

public class PatrolingEnemyController : MonoBehaviour {

	

	[SerializeField]
	float agroRadius = 1.0f;

	[SerializeField]
	float leashRadius = 3.0f;

    [SerializeField]
    float resumeWalkRadius = 0.1f;

	State currentState;

	public Vector3 enemyPos = new Vector3();
    public Vector3 myCachePos = new Vector3();

    public enum States
    {
        walking,
        chasingPlayer,
        returningToRoute
    }

    public static State[] StatesArray = new State[]{new Walking(), new ChasingEnemy(), new ReturningToRoute()};

	public hoMove myMoveBehavior;

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
		currentState = StatesArray[(int)States.walking];
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
		if (Vector3.Distance (Game.Instance.getManager().player.transform.position, transform.position) < agroRadius) 
		{
			enemyPos = Game.Instance.getManager().player.transform.position;
			return true;
		}
		if (Vector3.Distance (Game.Instance.getManager().brother.transform.position, transform.position) < agroRadius) 
		{
			enemyPos = Game.Instance.getManager().brother.transform.position;
			return true;
		}

		return false;
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
