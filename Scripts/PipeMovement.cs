using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    private float endZone = -24;
    void Update()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;
        DestroyPipe();
    }
    void DestroyPipe()
    {
        if(transform.position.x < endZone)
        {
            Destroy(gameObject);
        }
    }
}
