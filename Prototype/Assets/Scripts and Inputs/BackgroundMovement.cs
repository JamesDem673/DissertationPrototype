using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        float newspeed = _player.GetComponent<Rigidbody2D>().velocity.x * speed * 0.001f;
        Vector3 newpos = new Vector3(transform.position.x + newspeed, transform.position.y, transform.position.z);
        transform.SetPositionAndRotation(newpos , transform.rotation);
    }
}
