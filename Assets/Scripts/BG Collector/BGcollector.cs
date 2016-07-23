using UnityEngine;
using System.Collections;

public class BGcollector : MonoBehaviour {
    private GameObject[] backgrounds;
    private GameObject[] grounds;
    private float lastBGPosX;
    private float lastGroundPosX;
	// Use this for initialization
	void Awake () {
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        grounds = GameObject.FindGameObjectsWithTag("Ground");
        lastBGPosX = backgrounds[0].transform.position.x;
        lastGroundPosX = grounds[0].transform.position.x;
        for (int i = 0; i < backgrounds.Length; i++)
        {
            if(lastBGPosX < backgrounds[i].transform.position.x)
            {
                lastBGPosX = backgrounds[i].transform.position.x;
            }
        }
        for (int i = 0; i < grounds.Length; i++)
        {
            if (lastGroundPosX < grounds[i].transform.position.x)
            {
                lastGroundPosX = grounds[i].transform.position.x;
            }
        }
    }
    

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            Vector3 temp = target.transform.position;
            float witdh = ((BoxCollider2D)target).size.x;
            temp.x = lastBGPosX + witdh;
            target.transform.position = temp;
            lastBGPosX = temp.x;
        } 
        if (target.tag == "Ground")
        {
            Vector3 temp = target.transform.position;
            float witdh = ((BoxCollider2D)target).size.x;
            temp.x = lastGroundPosX + witdh;
            target.transform.position = temp;
            lastGroundPosX = temp.x;
        }
    }
}
