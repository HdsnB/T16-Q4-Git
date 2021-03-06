using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackingScript : MonoBehaviour
{
    public int Wood = 0;
    public int Stone = 0;
    public int Dogs = 0;
    public Text w;
    public Text s;
    public Text d;
    public GameObject ResourcesWall;

    // Start is called before the first frame update
    void Start()
    {
        Wood = 0;
        Stone = 0;
        Dogs = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //w.text = Wood.ToString();
        //s.text = Stone.ToString();
        //d.text = Dogs.ToString();
    }

    public void GainCollectibles(int W, int S, int D)
    {
        Debug.Log("ScoreTrackingScript used");
        if (W > 0) Wood ++;
        if (S > 0) Stone ++;
        Dogs += D;
        w.text = Wood.ToString() + " / 8";
        s.text = Stone.ToString() + " / 8";
        d.text = Dogs.ToString() + " / 32";
        if (Wood >= 4 && Stone >= 4 && Dogs >= 12)
        {
            ResourcesWall.SetActive(false);
        }
    }
}
