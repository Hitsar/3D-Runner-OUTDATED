using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);

        _speed += 0.01f * Time.fixedDeltaTime / 5;
        if (_speed <= 25)
        {
            return;
        }
    }
}