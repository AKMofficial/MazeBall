using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBalls : MonoBehaviour
{

    private void OnCollisionEnter(Collision other) 
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
    }
}
