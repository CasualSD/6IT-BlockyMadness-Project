using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timer : MonoBehaviour
{

    private float _timer = 3f;
    private bool _timeractive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_timeractive)
        {
            _timer -= Time.deltaTime;
        }
        else if(_timer <= 0)
        {
            _timeractive = false;
            _timer = 3f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _timeractive = true;
        }
    }
}
