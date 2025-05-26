// Created by: Sunny Valley Studio 
// https://svstudio.itch.io

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS
{
    public class CameraMovement : MonoBehaviour
    {
        public Camera gameCamera;
        public float cameraMovementSpeed = 5;
        public float rotationSpeed = 2f;
        public float minYAngle = -80f;
        public float maxYAngle = 80f;

        private float currentXRotation;
        private float currentYRotation;

        private void Start()
        {
            gameCamera = GetComponent<Camera>();

            // Initialize rotation values based on current transform
            Vector3 currentAngles = transform.eulerAngles;
            currentXRotation = currentAngles.y;
            currentYRotation = currentAngles.x;
        }

        private void Update()
        {
            // Handle rotation when right mouse button is held
            if (Input.GetMouseButton(1))
            {
                HandleRotation();
            }
        }

        public void MoveCamera(Vector3 inputVector)
        {
            var movementVector = Quaternion.Euler(0, currentXRotation, 0) * inputVector;
            gameCamera.transform.position += movementVector * Time.deltaTime * cameraMovementSpeed;
        }

        private void HandleRotation()
        {
            // Get mouse input
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Update rotation values
            currentXRotation += mouseX;
            currentYRotation -= mouseY;

            // Clamp vertical rotation to prevent flipping
            currentYRotation = Mathf.Clamp(currentYRotation, minYAngle, maxYAngle);

            // Apply rotation
            transform.rotation = Quaternion.Euler(currentYRotation, currentXRotation, 0);
        }
    }
}