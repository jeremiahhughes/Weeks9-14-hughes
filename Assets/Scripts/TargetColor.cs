using UnityEngine;

public class TargetColor : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;
    
   
    public void ChangeColorToRed()
    {
        targetSpriteRenderer.color = Color.red;
    }

    public void ResetColor()
    {
        targetSpriteRenderer.color = Color.gray;
    }
}
