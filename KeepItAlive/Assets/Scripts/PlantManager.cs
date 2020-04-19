using UnityEngine;
using UnityEngine.UI;

public class PlantManager : MonoBehaviour
{
    public Text text;

    public PlayerMovement2D playerMovement2D;

    private void Update()
    {
        text.text = playerMovement2D.plantsCollected + "/6" .ToString();
    }
}
