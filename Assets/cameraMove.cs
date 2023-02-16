using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] Transform tr;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(tr.position.x, tr.position.y + 3, -10);
    }
}
