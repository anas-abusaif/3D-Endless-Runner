using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Transform Playerposition;
    private void Update()
    {
        transform.position = new Vector3(0, 2.5f, Playerposition.position.z - 3f);
    }

}
