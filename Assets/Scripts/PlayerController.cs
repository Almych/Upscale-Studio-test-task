using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed, runSpeed;
    [SerializeField] private MenuManager menuManager;
    [SerializeField] private AudioSource playerStep;
    
   private CharacterController characterController => GetComponent<CharacterController>();
   
    private float horizontal, vertical;
    private Vector3 lastPosition;
    private float currSpeed;
    private float velocity = -20f;
    void Update()
    {
        Movement();
        StepSound();

        if (Input.GetKeyDown(KeyCode.Escape)) 
            menuManager.ShowPauseMenu();
    }

    private void Movement ()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        if (characterController.isGrounded)
            move.y += velocity;

        if (Input.GetKey(KeyCode.LeftShift))
            currSpeed = runSpeed;
        else
            currSpeed = speed;
        
        characterController.Move(move * currSpeed * Time.deltaTime);
    }

    private void StepSound  ()
    {
        if (transform.position != lastPosition)
        {
            if (!playerStep.isPlaying) playerStep.Play();
        }
        else
        {
            playerStep.Stop();
        }

        lastPosition = transform.position;
    }
}
