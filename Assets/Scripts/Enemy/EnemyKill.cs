using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class EnemyKill : MonoBehaviour
{
    private bool dead = false;
    
    void Update()
    {
        if (dead) //if the player is dead; load the main menu scene
        {
            OnDeath();
        }
        if (transform.position.y <= -25) //if the player falls out of the world; load main menu scene
        {
            OnDeath();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            OnDeath();
        }
    }

    private void OnDeath()
    {
        SceneManager.LoadScene("Menu");
        MouseLook.lockCursor = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log(MouseLook.lockCursor);
        
    }
}
