using UnityEngine;

public class MobileUIFilter : MonoBehaviour
{
    public bool forceShowInEditor = true;

    void Awake()
    {
        if (Application.isEditor)
        {
            gameObject.SetActive(forceShowInEditor);
            return;
        }

        bool isMobile = Application.isMobilePlatform;
        gameObject.SetActive(isMobile);
    }
}