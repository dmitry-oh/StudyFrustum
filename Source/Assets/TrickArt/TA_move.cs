using UnityEngine;

public class TA_move : MonoBehaviour
{
    float moveSpeed = 2;

    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))* moveSpeed * Time.deltaTime);
    }
}
