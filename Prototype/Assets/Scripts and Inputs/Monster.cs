using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("HitBox"))
        {
            animator.SetTrigger("Death");
        }
    }
}
