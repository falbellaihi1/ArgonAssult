using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float TurnSpeed = 4f;
    [Tooltip("In m")] [SerializeField] float TurnRange = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yLocalPos = transform.localPosition.y;
        float xLocalPos = transform.localPosition.x;
       

        transform.localPosition = new Vector3(CalculateTurn(xThrow,xLocalPos), CalculateTurn(yThrow, yLocalPos), transform.localPosition.z);

        
    }

    float CalculateTurn(float Throw, float localPos)
    {
        float ClampedPos;
        float Offset = Throw * TurnSpeed * Time.deltaTime;
        float rowNewPos = localPos + Offset;
        ClampedPos = Mathf.Clamp(rowNewPos, -TurnRange, TurnRange);
        return ClampedPos;
    }

}
