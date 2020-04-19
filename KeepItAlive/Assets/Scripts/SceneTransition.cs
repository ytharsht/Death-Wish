using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    private static bool hasPlayed = false;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if (hasPlayed == false)
        {
            anim.Play("SceneTransition");
            hasPlayed = true;
        }
    }
}
