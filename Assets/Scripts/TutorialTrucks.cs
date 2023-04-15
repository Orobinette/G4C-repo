using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrucks : MonoBehaviour
{
    Rigidbody2D truckRB;

    void Start()
    {
        truckRB = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        truckRB.AddForce(new Vector3(0f, 500f, 0f) * Time.fixedDeltaTime);

        if(this.gameObject.transform.position.y > 6)
        {
            Destroy(this.gameObject);
        }
    }
}
