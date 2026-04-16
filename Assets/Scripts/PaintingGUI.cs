using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PaintingGUI : MonoBehaviour
{

    [Header("Artwork")]
    private Texture2D painting;

    [Header("Video Link")]
    [SerializeField]
    private string url;

    [Header("Purchase Form")]
    [SerializeField]
    private string form;


    private Action onListenVideo;
    private Action onPurcahse;

    [Header("Virtual Assistant")]
    [SerializeField]
    private Texture2D assistant;

    public void PlayVideo()
    {
        onListenVideo?.Invoke();


    }

    public void setPainting(Texture2D image)
    {
        this.painting = image;
    }

    public void setVideo(string url)
    {

    }

    public void PlayPurcahse()
    {
        onPurcahse?.Invoke();

    }
}

