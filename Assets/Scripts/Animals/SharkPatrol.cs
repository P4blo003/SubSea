// ==============================
// USINGS
// ==============================

// Unity:
using UnityEngine;

// Internal:
using SubSea.Utilities;
using System;


// ==============================
// CLASSES
// ==============================

namespace SubSea.Systems
{
    public class SharkPatrol : MonoBehaviour
{
    public float speed = 2.0f;
    public float rotationSpeed = 30.0f;

    void Update()
    {
        // Mueve al tiburón siempre hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Hace que gire suavemente para que nade en círculos grandes
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
}