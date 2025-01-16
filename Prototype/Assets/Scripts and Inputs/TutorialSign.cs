using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSign : MonoBehaviour
{
    [SerializeField] GameObject _tutSign;


    private void Start()
    {
        _tutSign.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _tutSign.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _tutSign.SetActive(false);
    }
}
