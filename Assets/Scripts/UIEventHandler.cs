using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    public static UIEventHandler instance;

    [SerializeField]
    private PaintingGUI _modalWindow;

    public PaintingGUI modalWindow => _modalWindow;

    private void Awake()
    {
        instance = this;
        hideMenu();
    }

    public void showMenu(Texture2D image, string url)
    {
        modalWindow.setVideo(url);
        modalWindow.setPainting(image);
        modalWindow.gameObject.SetActive(true);
    }

    public void hideMenu()
    {
        modalWindow.gameObject.SetActive(false);
    }
}
