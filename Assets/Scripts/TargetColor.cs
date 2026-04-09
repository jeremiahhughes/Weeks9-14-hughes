using System.Collections;
using UnityEngine;

public class TargetColor : MonoBehaviour
{
    public SpriteRenderer targetSpriteRenderer;
    public float respawnTime = 5f;
    public float speed = 3;
    

        void Update()
    {
        // to move the targets got this from required reading 1-4 stay on the screen timestamp 14:33
        transform.position += Vector3.up * speed * Time.deltaTime;
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.y < 0 || screenPos.y > Screen.height)
        {

            speed = speed * -1;
        }
    }

    public void ChangeColorToRed()
    {
        targetSpriteRenderer.color = Color.red;
    }

    public void ResetColor()
    {
        targetSpriteRenderer.color = Color.gray;
    }

    public void StartRespawn()
    {
        StartCoroutine(RespawnTimer());
    }

    IEnumerator RespawnTimer()
    {
        //hide target instead of being destroyed
        targetSpriteRenderer.enabled = false;
        // wait for 5 seconds based on the respawn time variable
        yield return new WaitForSeconds(respawnTime);

        // reset the target to show again
        targetSpriteRenderer.color = Color.gray;
        targetSpriteRenderer.enabled = true;

    }
}
