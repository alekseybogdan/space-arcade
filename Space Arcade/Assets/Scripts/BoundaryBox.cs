using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBox : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
