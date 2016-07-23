using UnityEngine;
using System.Collections;

public class Pipecollector : MonoBehaviour {
    private GameObject[] pipes;
    private float lastPipeX;
    //private float distance = 2.5f;
    void Awake()
    {
        pipes = GameObject.FindGameObjectsWithTag("Pipe");
        //grounds = GameObject.FindGameObjectsWithTag("Ground");
        lastPipeX = pipes[0].transform.position.x;
        //lastGroundPosX = grounds[0].transform.position.x;
        for (int i = 1; i < pipes.Length; i++)
        {
            if (lastPipeX < pipes[i].transform.position.x)
            {
                lastPipeX = pipes[i].transform.position.x;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag =="Pipe")
        {
            Vector3 temp = target.transform.position;
            float witdhs = ((BoxCollider2D)target).size.x+5f;
            temp.x = lastPipeX + witdhs;
            target.transform.position = temp;
            lastPipeX = temp.x;
        }
     
    }
}
