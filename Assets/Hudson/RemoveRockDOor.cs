using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveRockDOor : MonoBehaviour
{
    public GameObject EndWall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EndWall.SetActive(false);

    }
}
