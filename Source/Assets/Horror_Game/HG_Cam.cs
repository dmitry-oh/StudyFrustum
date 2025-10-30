using UnityEngine;

public class HG_Cam : MonoBehaviour
{
    float rot;
    float rot_speed = 5;
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        rot +=
        Input.GetAxis("Mouse X")*Time.deltaTime*Mathf.Rad2Deg*rot_speed;
        transform.rotation =
        Quaternion.Euler(0, rot, 0);
    }
}
