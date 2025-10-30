using System;
using UnityEngine;

public class HG_Enemy : MonoBehaviour
{
    [SerializeField] Transform player;
    float theta_a,theta_b;
    void Start()
    {
        theta_a = Camera.main.fieldOfView*Mathf.Deg2Rad;
        float r = Screen.width / (float)Screen.height;
        float tan_b = Mathf.Tan(theta_a) * r;
        theta_b = Mathf.Atan(tan_b);
    }
    void Update()
    {
        Vector3 u = transform.position - player.position;
        Vector3 v = player.rotation * Vector3.forward;
        Debug.DrawRay(player.position, u,Color.blue);
        Debug.DrawRay(player.position, v, Color.red);

        //xz평면만 고려함
        bool inRange = (Vector3.Angle(u, v) * Mathf.Deg2Rad < theta_b);
        if (!inRange)
        {
            transform.position =
            Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * 2);
        }
    }
}
