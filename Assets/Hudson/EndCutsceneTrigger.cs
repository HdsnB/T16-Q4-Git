using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutsceneTrigger : MonoBehaviour
{
    //----====---- if(GameObject Humphrey is destroyed, then destroy EndWall) !!!!!!!!!!!!!!!!!!!

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
        SceneManager.LoadScene("EndCutsceneScene");


    }


}
