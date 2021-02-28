using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlles : MonoBehaviour
{
    [SerializeField] float controlSpeed = 40f;
    [SerializeField] float xRange = 12f;
    [SerializeField] float yRange = 10f;
    [SerializeField] GameObject[] lasers;

    [SerializeField] float positionPitchFacter = -1f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 1f;
    [SerializeField] float rotationPitchFactor = -20f;

    float xThrow;
    float yThrow;



    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFacter + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = transform.localRotation.x * rotationPitchFactor + xThrow * controlPitchFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float yOffset = yThrow * Time.deltaTime * controlSpeed;

        float newXPosition = transform.localPosition.x + xOffset;
        float newYPosition = transform.localPosition.y + yOffset;

        float clampedXPos = Mathf.Clamp(newXPosition, -xRange, xRange);
        float clampedYPos = Mathf.Clamp(newYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject Laser in lasers)
        {
            var emissionModule = Laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
                    
    }
}
