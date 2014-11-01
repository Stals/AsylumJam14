using UnityEngine;
using System.Collections;

public class PatrolingEnemyController : MonoBehaviour {

	enum State
	{
		walking,
		chasingPlayer
	}

	[SerializeField]
	float agroRadius = 5.0f;

	[SerializeField]
	float leashRadius = 25.0f;

	State currentState;
	Vector3 enemyPos = new Vector3();

	iMove myMoveBehavior;


	// Use this for initialization
	void Start () {
		currentState = State.walking;
		myMoveBehavior = GetComponent<iMove> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	bool CheckEnemy()
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

	bool CheckDistance()
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
