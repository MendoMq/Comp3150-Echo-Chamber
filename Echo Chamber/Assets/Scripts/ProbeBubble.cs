using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProbeBubble : MonoBehaviour
{
   
    public GameObject BigBubble;
    void OnCollisionStay(Collision collision)
    {
        GameObject clone;
        clone = Instantiate(BigBubble, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
