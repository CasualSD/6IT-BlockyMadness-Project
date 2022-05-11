using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOb : MonoBehaviour
{
    [SerializeField] private float _CubeTime = 3f;
    [SerializeField] private bool _Timer = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (_Timer == true)
        {
            _CubeTime -= Time.deltaTime;
        }
        if (_CubeTime <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _Timer = true;
        }
    }

}
