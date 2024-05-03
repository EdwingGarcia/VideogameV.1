using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float forceMultiplier = 10f; // Factor de multiplicación de la fuerza de movimiento
    public float jumpForce = 500f; // Fuerza de salto
    private bool isGrounded; // Flag para verificar si el jugador está en el suelo

    private Rigidbody rb;
    private Camera mainCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Detectar entrada de salto
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // Aplicar fuerza de salto al Rigidbody
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Obtener la dirección hacia adelante de la cámara sin incluir la componente vertical
        Vector3 forwardDirection = mainCamera.transform.forward;
        forwardDirection.y = 0;
        forwardDirection.Normalize();

        // Movimiento del personaje
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = Quaternion.LookRotation(forwardDirection) * movement;

        // Aplicar la fuerza de movimiento al Rigidbody
        rb.AddForce(movement * speed * forceMultiplier, ForceMode.Force);
    }

    void OnCollisionStay(Collision collision)
    {
        // Verificar si el jugador está en el suelo
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // Verificar si el jugador ya no está en el suelo
        isGrounded = false;
    }
}
