using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float velocidad = 12f;
    public float gravity = -9.81f;
    Vector3 velocidadGravedad;
    public Transform groundChecker;
    public float radioEsfera = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3;



    void Update()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, radioEsfera, groundMask);
        if (isGrounded && velocidadGravedad.y < 0)
        {
            velocidadGravedad.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocidadGravedad.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        };
        characterController.Move(move * velocidad * Time.deltaTime);
        velocidadGravedad.y += gravity * Time.deltaTime;
        characterController.Move(velocidadGravedad * Time.deltaTime);

    }
}
