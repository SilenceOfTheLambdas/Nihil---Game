using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    private static bool dead = false;
    
    void Update()
    {
        if (dead) //if the player is dead; load the main menu scene
        {
            SceneManager.LoadScene("Menu");
        }
        if (transform.position.y <= -25) //if the player falls out of the world; load main menu scene
        {
            SceneManager.LoadScene("Menu");
        }
    }

}
