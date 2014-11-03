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
        transform.rotation = Quaternion.LookRotation(vecToEnemy);
    }
}
