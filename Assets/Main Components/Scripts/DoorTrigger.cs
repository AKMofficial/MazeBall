using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] GameObject door;

    private void OnCollisionEnter(Collision other) 
    {
        door.transform.position += new Vector3 (100000f,10000f,1000f);
    }
}
