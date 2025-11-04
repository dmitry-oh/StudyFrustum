using UnityEngine;

public class Main_TA : MonoBehaviour
{
    [SerializeField] Transform camera_t;
    [SerializeField] GameObject gTP,gCube, gBOX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3(4, 1, 4);
        Vector3 targetAngle = new Vector3(0, 270, 0);

        float diff1 = Vector3.Distance(camera_t.position, targetPos);
        float diff2 = Vector3.Distance(camera_t.eulerAngles, targetAngle);
        if (diff1 < 1&&diff2<10)
        {
            gTP.SetActive(false);
            gCube.SetActive(false);
            gBOX.SetActive(true);
            enabled = false;
        }
    }
}
