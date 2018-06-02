using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Target;

    Vector3 offset;
    private void Awake()
    {
        offset = transform.position - Target.position;
    }
    // Update is called once per frame
    void Update () {
        transform.position = Target.position + offset;
	}
}
