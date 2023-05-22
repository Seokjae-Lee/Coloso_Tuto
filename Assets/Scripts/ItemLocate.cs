using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLocate : MonoBehaviour
{
    public float rotate_speed;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotate_speed);

    }
}
