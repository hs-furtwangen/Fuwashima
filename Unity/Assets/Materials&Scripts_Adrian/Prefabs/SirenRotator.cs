using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SirenRotator : MonoBehaviour
{
    public Transform rotationObject = null;

    bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        rotationObject = this.transform.GetChild(1);
        isRotating = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating == true)
        {
            rotationObject.Rotate(0, 0, 120f * Time.deltaTime);
        }
    }

    public void activateRotation()
    {
        isRotating = true;
    }

    public void stopRotation()
    {
        isRotating = false;
    }
}
