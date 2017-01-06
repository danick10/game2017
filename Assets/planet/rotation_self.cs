using UnityEngine;
using System.Collections;

public class rotation_self : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y + speed * Time.deltaTime, gameObject.transform.eulerAngles.z);
	}

}
