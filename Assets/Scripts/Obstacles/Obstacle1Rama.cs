using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle1Rama : MonoBehaviour
{
    [SerializeField] float speedRot;
    
    private void FixedUpdate()
    {
        Vector3 rote = new Vector3(0, 1, 0);

        this.transform.Rotate(rote * speedRot * Time.deltaTime);
    }
}
