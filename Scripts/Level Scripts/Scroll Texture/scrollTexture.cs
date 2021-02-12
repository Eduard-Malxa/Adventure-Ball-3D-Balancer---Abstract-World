using UnityEngine;
public class scrollTexture : MonoBehaviour
{
    public Renderer quadRenderer;

    public float scrollSpeedX;

    public float scrollSpeedY;

    public float TillingX;

    public float TillingY;

    internal void FixedUpdate()
    {
        Vector2 textureOffset = new Vector2(Time.time * scrollSpeedX, Time.time * scrollSpeedY);
        Vector2 textureTilling = new Vector2(TillingX, TillingY);
        quadRenderer.material.mainTextureOffset = textureOffset;
        quadRenderer.material.mainTextureScale = textureTilling;
    }
}
