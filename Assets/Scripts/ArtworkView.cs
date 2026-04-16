using UnityEditor;
using UnityEngine;

public class ArtworkView : MonoBehaviour
{
    private Transform viewPoint;

    private void Start()
    {
        viewPoint = transform.GetChild(0);
    }

    private void OnMouseDown()
    {
        CameraController.Instance.FocusOnArtwork(viewPoint);

        this.ShowMenu();
    }



    private void ShowMenu()
    {
        // find child menu
        Painting painting = GetComponentInChildren<Painting>();
        
    }

    private void HideMenu()
    {
        GetComponentInChildren<Renderer>().enabled = false;



    }
}
