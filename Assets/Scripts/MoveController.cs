using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.81f;
    public AudioSource walkFX;

    Vector3 velocity;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (move.x != 0 || move.z != 0)
        {
            if (!walkFX.isPlaying)
            {
                walkFX.Play();
            }  
        }
        else 
        {
            if (walkFX.isPlaying)
            {
                walkFX.Stop();
            }
        }
    }
}
