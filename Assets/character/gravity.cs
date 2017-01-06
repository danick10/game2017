using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour {
    public GameObject planet;
    Vector3 gravity_vector;
    public float gravity_force;
    Ray gravity_ray;
    public bool IsTouchingGround;
	// Use this for initialization
	void Start () {
	if (!planet)
        {
            print("No planet set for the gravity component of this object");
        }
    if (!gameObject.GetComponent<Rigidbody>())
        {
            print("A rigid component is required for gravity component");
        }
    if (gravity_force == 0)
        {
            print("if you want gravity to apply, you must add a force other than 0 in its component");
        }

	}
	
	// Update is called once per frame
	void Update () {
    gravity_vector = (gameObject.transform.root.transform.position - gameObject.transform.position).normalized;
    if (!IsTouchingGround)
    {
        gameObject.GetComponent<Rigidbody>().AddForce(gravity_vector * gravity_force, ForceMode.Acceleration);
    }
    else
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }




    Vector3 surfaceNormal = transform.position - gameObject.transform.root.transform.position;
    surfaceNormal.Normalize();
    //GameObject's heading
    float headingDeltaAngle = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
    Quaternion headingDelta = Quaternion.AngleAxis(headingDeltaAngle, transform.up);
    //align with surface normal
    transform.rotation = Quaternion.FromToRotation(transform.up, surfaceNormal) * transform.rotation;
    //apply heading rotation
    transform.rotation = headingDelta * transform.rotation;







 //   transform.localRotation = Quaternion.FromToRotation(-gameObject.transform.eulerAngles, (gravity_vector));

	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "planet-terrain")
        {
            IsTouchingGround = true;
        } 
    }

    void OnCollisionExit(Collision collision)
    {
              if (collision.collider.gameObject.name == "planet-terrain")
        {
            IsTouchingGround = false;
        } 
    }
}
