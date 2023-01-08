using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed; 

    private void Start()
    {
        StartCoroutine(SpeedUp());
    }
    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);

        if (_speed <= 25)
        {
            StopCoroutine(SpeedUp());
        }
    }

    private IEnumerator SpeedUp()
    {
        var seconds = new WaitForSeconds(5);
        yield return seconds;
        _speed += 0.1f;
    }
}
