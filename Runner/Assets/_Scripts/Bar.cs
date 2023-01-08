using UnityEngine;

public class Bar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyGame enemy))
            other.gameObject.SetActive(false);
    }
}
