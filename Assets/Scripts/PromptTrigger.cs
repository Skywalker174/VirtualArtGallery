using UnityEngine;

public class PromptTrigger : MonoBehaviour
{
    [SerializeField]
    private static Texture2D image;

    [SerializeField]
    private static string url;

    public void Interact()
    {
        UIEventHandler.instance.showMenu(image, url);
    }
}
