using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotaton : MonoBehaviour
{
    private const int ROTATEDIVIDER = 5;
    [SerializeField] private float sensitivity = 150F;
    [SerializeField] private int leftLimiter = 30;
    [SerializeField] private int rightLimiter = 120;
    private float rotationZone = Screen.width / ROTATEDIVIDER;
    [SerializeField] private Vector3 rotation;
    private bool isALive = true;
    




    // Update is called once per frame
    void Update()
    {
        if (isALive == true)
        {
            if (Input.mousePosition.x < rotationZone && transform.rotation.eulerAngles.y > leftLimiter)
            {
                transform.Rotate(0, -sensitivity * Time.deltaTime, 0);

            }
            if (Input.mousePosition.x > Screen.width - rotationZone && transform.rotation.eulerAngles.y < rightLimiter)
            {
                transform.Rotate(0, sensitivity * Time.deltaTime, 0);
            }
        }
    }
    public void Die ()
    {
        isALive = false;
        transform.rotation = Quaternion.Euler(rotation);
    }
    
        
    

}
