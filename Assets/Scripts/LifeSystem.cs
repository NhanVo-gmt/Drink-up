using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSystem : MonoBehaviour
{
    public GameObject[] lives;
    public ScoreSystem scoreSystem;
    public int life;

    void Start()
    {
        // foreach (GameObject life in lives)
        // {
        //     Debug.Log(life.name);
        // }
        // Debug.Log(this.name);
    }

    void Update()
    {
        if (life < 0)
        {
            // life = 0;
            // scoreSystem.ResetScore();
            // for (int i = 0; i < lives.Length; i++)
            // {                
            //     lives[i].gameObject.SetActive(true);
            //     life++;
            // }
            SceneManager.LoadScene("GameOverScene");
        }
        else if (life < 1)
        {
         //   lives[0].gameObject.SetActive(false);
        }
        else if (life < 2)
        {
            lives[1].gameObject.SetActive(false);
        }
        else if (life < 3)
        {
            lives[2].gameObject.SetActive(false);
        }
        else if (life < 4)
        {
            lives[3].gameObject.SetActive(false);
        }
        else if (life < 5)
        {
            lives[4].gameObject.SetActive(false);
        }
    }

    public void TakeDamage(int damage)
    {
        // if(!pauseMenu.GameIsPaused)
            life -= damage;
    }
}
