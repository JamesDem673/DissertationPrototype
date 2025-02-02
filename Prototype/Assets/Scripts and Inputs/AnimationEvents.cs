using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] Animator _animator;
   
    [SerializeField] public GameObject _player;
    public GameObject swingOne;
    public GameObject swingTwo;

    private Movement _pm;

    public void Start()
    {
        _pm = _player.GetComponent<Movement>();    
    }

    public void EndOfAnimation()
    {
        _pm._isAttacking = false;
        _animator.SetBool("IsAttacking", false);

        if(_pm._isAttacking == false && _pm._nextAttack == true)
        {
            _pm._nextAttack = false;
        }
    }
    public void StartOfAnimation()
    {
        _pm._nextAttack = false;
        _animator.SetBool("NextAttack", false);
    }

    public void ToggleSwingOne()
    {
        if(swingOne.activeInHierarchy)
        {
            swingOne.SetActive(false);
        }
        else
        {
            swingOne.SetActive(true);
        }
    }

    public void ToggleSwingTwo()
    {
        if (swingTwo.activeInHierarchy)
        {
            swingTwo.SetActive(false);
        }
        else
        {
            swingTwo.SetActive(true);
        }
    }
}
