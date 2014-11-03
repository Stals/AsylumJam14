using UnityEngine;
using System.Collections;

public class FatherBehavior : MonoBehaviour {

    [SerializeField]
    float speed = 0.001f;

    public bool chasingDaughter = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (chasingDaughter)
        {
            ChasePlayer();
        }
	}

    public void ChasePlayer()
    {
        Vector3 enemyPos = Game.Instance.getManager().player.transform.position;
        Vector3 vecToEnemy = enemyPos - transform.position;
        transform.position +=  speed * 1.0f / 60.0f * vecToEnemy.normalized;
        turnTo(vecToEnemy);
    }


    void turnTo(Vector3 v)
    {
        if ((v.x != 0) || (v.y != 0))
        {
            
            float rad = Mathf.Atan2(v.y, v.x);
            float degrees = (rad / Mathf.PI) * 180.0f;
            
            //Debug.Log(degrees);
            
            Vector3 angles = transform.eulerAngles;
            angles.z = degrees;
            
            transform.eulerAngles = angles;
        }
    }
}
