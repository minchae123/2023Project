using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spring : MonoBehaviour
{   
    public float force;             

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player") 
        {
            GetComponent<Animator>().Play("spring");
            Vector3 dir = other.transform.position;
            other.gameObject.GetComponent<BearMovement>().controller.Move(new Vector3(dir.x, 2, dir.z));
            //other.gameObject.GetComponent<Rigidbody>().AddForce(0f, force, 0f, ForceMode.Impulse);
        }
    }
}
