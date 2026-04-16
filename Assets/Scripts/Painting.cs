using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Painting : MonoBehaviour
{
    [Header("Direct image URL")]
    [SerializeField] private string imageUrl =
        "https://firebasestorage.googleapis.com/v0/b/virtual-art-gallery-56498.firebasestorage.app/o/artworks%2F1ZNYiozB4TrZnaNzLgcZ%2Fimage.png?alt=media&token=e738cd01-3461-4baf-90e3-37c24ae36c3a";

    [Header("Target")]
    [SerializeField] private Renderer targetRenderer;

    private Texture2D texture;

    private void Reset()
    {
        targetRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        if (targetRenderer == null)
        {
            Debug.LogError("Painting: No targetRenderer assigned.");
            return;
        }

        StartCoroutine(LoadTextureFromUrl(imageUrl));
    }

    private IEnumerator LoadTextureFromUrl(string url)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(url))
        {
            yield return req.SendWebRequest();

            Debug.Log("Result: " + req.result);
            Debug.Log("Error: " + req.error);
            Debug.Log("Response code: " + req.responseCode);

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Image download failed: " + req.error);
                yield break;
            }

            Texture2D tex = DownloadHandlerTexture.GetContent(req);
            tex.filterMode = FilterMode.Trilinear;
            tex.anisoLevel = 16;
            tex.mipMapBias = 0f;

            this.texture = tex;

            Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
            mat.mainTexture = tex;
            targetRenderer.material = mat;

            float aspect = (float)tex.width / tex.height;
            Vector3 s = targetRenderer.transform.localScale;
            targetRenderer.transform.localScale = new Vector3(s.y * aspect, s.y, s.z);
        }
    }
}