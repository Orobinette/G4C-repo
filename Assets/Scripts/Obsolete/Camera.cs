using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform truckTrans;

    Vector3  movement = new Vector3(0, 0, 0);
    float speed = 5f;

    void Update() 
    {
        movement = new Vector3 (0, 0, 0);

        if(truckTrans.position.x < this.gameObject.transform.position.x - 10)
        {
            this.gameObject.transform.position = new Vector3(truckTrans.position.x + 10, 0, -10);
        }
        if(truckTrans.position.x > this.gameObject.transform.position.x + 10)
        {
            this.gameObject.transform.position = new Vector3(truckTrans.position.x - 10, 0, -10);
        }
        if(truckTrans.position.y < this.gameObject.transform.position.y - 4)
        {
            this.gameObject.transform.position = new Vector3(0, truckTrans.position.x + 4, -10);
        }
        if(truckTrans.position.y > this.gameObject.transform.position.y + 4)
        {
            this.gameObject.transform.position = truckTrans.position + new Vector3(0, truckTrans.position.x - 4, -10);
        }

    }

    
}
