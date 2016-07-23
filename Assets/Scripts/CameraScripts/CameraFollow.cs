using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform bird;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (bird != null)
        {
            Vector3 temp = transform.position;
            temp.x = bird.position.x + 3f;
            transform.position = temp;
        }
	}
}
