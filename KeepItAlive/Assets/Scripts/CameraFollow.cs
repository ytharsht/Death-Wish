using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followObject;
    private Vector3 moveTemp;
    public float offsetY = 2;
    public float offsetX = 2;

    private void Start()
    {
        moveTemp = followObject.transform.position;
    }

    private void Update()
    {
        moveTemp = followObject.transform.position;
        moveTemp.y += offsetY;
        moveTemp.x += offsetX;
        moveTemp.z = transform.position.z;
        transform.position = moveTemp;
    }
}

