using UnityEngine;
using System.Collections;

public class PatrolingEnemyController : MonoBehaviour {

	enum State
	{
		walking,
		chasingPlayer,
        goingBackToRoute
	}

	[SerializeField]
	float agroRadius = 1.0f;

	[SerializeField]
	float leashRadius = 3.0f;

    [SerializeField]
    float resumeWalkRadius = 0.1f;

	State currentState;

	Vector3 enemyPos = new Vector3();
    Vector3 myCachePos = new Vector3();

	hoMove myMoveBehavior;

    State CurrentState
    {
        get { return currentState;}
        set
        {
            if (value != currentState)
            {
                if (value == State.walking)
                {
                    myMoveBehavior.Resume();
                }

                if (value == State.chasingPlayer)
                {
                    myCachePos = transform.position;
                    myMoveBehavior.Pause();
                }

                currentState = value;
            }
        }
    }


	// Use this for initialization
	void Start () {
		currentState = State.walking;
		myMoveBehavior = GetComponent<hoMove> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (EnemyNearby() && DistanceIsClose())
        {
            CurrentState = State.chasingPlayer;
        } else if (CanResumeWalk())
        {
            CurrentState = State.walking;
        } else
        {
            CurrentState = State.goingBackToRoute;
        }

        if (CurrentState == State.chasingPlayer)
        {
            ChasePlayer();
        }

        if (CurrentState == State.goingBackToRoute)
        {
            ReturnToRoute();
        }
    }

    void ChasePlayer()
    {
        Vector3 vecToEnemy = enemyPos - transform.position;
        transform.position +=  myMoveBehavior.speed * 1.0f / 60.0f * vecToEnemy.normalized;
        transform.rotation = Quaternion.LookRotation(vecToEnemy);
    }

    void ReturnToRoute()
    {
        Vector3 vecToRoute = myCachePos - transform.position;
        transform.position +=  myMoveBehavior.speed * 1.0f / 60.0f * vecToRoute.normalized;
        transform.rotation = Quaternion.LookRotation(vecToRoute);
    }

    bool CanResumeWalk()
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

	bool EnemyNearby()
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

	bool DistanceIsClose()
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
