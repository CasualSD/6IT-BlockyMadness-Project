using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
    public GameObject LevelComplete;
    private float time;
    private bool timer = false;
    private void Update()
    {
        if (timer == true)
        {
            time += Time.deltaTime;
        }
        if (time >= 1.2f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            timer = true;
            LevelComplete.SetActive(true);
        }

    }
}
