using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public bool isActiveCheckpoint = false;
    public GameObject OtherCheckpoint1;
    public GameObject OtherCheckpoint2;

    public Animator a;

    public void CheckpointSwap()
    {
        Debug.Log(this.name + "CheckpointSwap");
        OtherCheckpoint1.GetComponent<CheckpointScript>().isActiveCheckpoint = false;
        OtherCheckpoint2.GetComponent<CheckpointScript>().isActiveCheckpoint = false;
        isActiveCheckpoint = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        a.SetBool("isActiveCheckpoint", isActiveCheckpoint);
    }
}
