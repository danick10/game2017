using UnityEngine;
using System.Collections;

public class character_controller : MonoBehaviour {
    public float turn_speed;
    public float speed_foward;
    public float speed_backward;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	if (Input.GetKey(KeyCode.A))
    {
        transform.Rotate(Vector3.down * Time.deltaTime * turn_speed);
    }
    if (Input.GetKey(KeyCode.D))
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turn_speed);
    }

    if (Input.GetKey(KeyCode.W))
    {
        gameObject.transform.Translate(0, 0, Time.deltaTime * speed_foward, Space.Self);
    }
    if (Input.GetKey(KeyCode.S))
    {
        gameObject.transform.Translate(0, 0, Time.deltaTime * -speed_backward, Space.Self);
    }


	}

}
