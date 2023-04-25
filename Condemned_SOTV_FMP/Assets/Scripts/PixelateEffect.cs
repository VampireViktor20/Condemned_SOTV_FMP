using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelateEffect : MonoBehaviour
{
    public int pixelSize = 10;

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        int width = src.width / pixelSize;
        int height = src.height / pixelSize;

        RenderTexture buffer = RenderTexture.GetTemporary(width, height, 0);

        buffer.filterMode = FilterMode.Point;
        Graphics.Blit(src, buffer);
        Graphics.Blit(buffer, dest);

        RenderTexture.ReleaseTemporary(buffer);
    }
}
