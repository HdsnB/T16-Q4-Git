using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public List<Transform> patrolPts = new List<Transform>();
    Transform[] patrolPoints = new Transform[] { };
    public int patrolPath;
    public float pathTime;
    public float currentTime;
    SpriteRenderer sr;
    int nPoints;
    void Start()
    {
        patrolPath = 0;
        patrolPoints = patrolPts.ToArray();
        nPoints = patrolPoints.Length;
        sr = GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > pathTime)
        {
            currentTime = 0; //reset the timer
            patrolPath++;
            if (patrolPath > nPoints - 1) patrolPath = 0;
            sr.flipX = !sr.flipX;
            //have point1 be on left, and point2 be on the right. If changed then this part will flip backwards.
        }
        transform.position = Vector3.Lerp(patrolPoints[patrolPath].position, patrolPoints[(patrolPath + 1) % nPoints].position, currentTime / pathTime);
        
    }
}
