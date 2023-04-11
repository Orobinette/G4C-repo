using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    bool walking;

    void Update() 
    {
        if(Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            if(!walking)
            {
                walking = true;
            }
        }
        else
        {
            if(walking)
            {
                walking = false;
            }
        }

        animator.SetBool("walking", walking);
    }
}
