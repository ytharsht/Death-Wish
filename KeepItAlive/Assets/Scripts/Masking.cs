using UnityEngine;

public class Masking : MonoBehaviour
{
    private void Update()
    {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
