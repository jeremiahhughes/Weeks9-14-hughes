using UnityEngine;

public class TargetParticle : MonoBehaviour
{
    public GameObject particlePrefab;
    public float effectDuration = 2;
  
    public void SpawnEffect(Transform targetTransform)
    {
        GameObject effect = Instantiate(particlePrefab, targetTransform.position, Quaternion.identity);

        Destroy(effect, effectDuration);
    }
    
}
