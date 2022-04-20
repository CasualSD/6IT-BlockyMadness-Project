using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCubeLerpUp : MonoBehaviour
{
    private float lerpTime;
    [SerializeField] private Vector3 targetPos;

    void Start()
    {
        targetPos = transform.position;
    }
    void Update()
    {
        if (lerpTime <= Time.deltaTime)
        {
            transform.position = targetPos;

            targetPos = new Vector3(transform.position.x, Random.Range(75f, 80f), transform.position.z);
            lerpTime = 5f;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, 1f * Time.deltaTime);

            lerpTime -= Time.deltaTime;
        }
    }
}
