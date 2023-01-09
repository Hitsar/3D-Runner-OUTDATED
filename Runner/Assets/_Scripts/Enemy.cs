using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed; 

    //private void Start()
    //{
    //    StartCoroutine(SpeedUp());
    //}
    private void FixedUpdate()
    {
        transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);

        _speed += 0.01f * Time.fixedDeltaTime / 5;
        if (_speed <= 25)
        {
            return;
        }
    }

    //private IEnumerator SpeedUp()
    //{
    //    while(true)
    //    {
    //        var seconds = new WaitForSeconds(5);
    //        _speed += 0.1f;
    //        yield return seconds;
    //    }
    //}
}
