using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCubeLerp : MonoBehaviour
{
    [SerializeField] private float lerpTime;
    [SerializeField] private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }
    void Update()
    {
        if( lerpTime <= Time.deltaTime)
        {
            transform.position = targetPos;

            targetPos = new Vector3(transform.position.x, Random.Range(5f, 10f), transform.position.z);
            lerpTime = 5.0f;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);

            lerpTime -= Time.deltaTime;
        }
    }
}
