using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerOrigin : MonoBehaviour
{

    private Vector3 playerOrigin;
    public GameObject mainPlayer;

    // Start is called before the first frame update
    void Start()
    {
        playerOrigin = mainPlayer.transform.position;
        transform.localPosition = playerOrigin;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
