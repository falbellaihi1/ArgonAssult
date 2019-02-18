using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float TurnSpeed = 20f;
    [Tooltip("In m")] [SerializeField] float TurnRange = 4f;
    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField]float positionYawFactor = 25f;
    [SerializeField] float positionRollFactor = -20f;
    float xThrow, yThrow;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        RotateShip();


    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yLocalPos = transform.localPosition.y;
        float xLocalPos = transform.localPosition.x;
        transform.localPosition = new Vector3(CalculateTurn(xThrow, xLocalPos, false), CalculateTurn(yThrow, yLocalPos, true), transform.localPosition.z);

    }

    float CalculateTurn(float Throw, float localPos, bool isY)
    {
        if (isY)
        {
            TurnRange = 3.5f;
        }
        else
        {
            TurnRange = 4f;
        }
        float ClampedPos;
        float Offset = Throw * TurnSpeed * Time.deltaTime;
        float rowNewPos = localPos + Offset;
        ClampedPos = Mathf.Clamp(rowNewPos, -TurnRange, TurnRange);
        
        
        return ClampedPos;
    }
   

    void RotateShip()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * positionRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

}
