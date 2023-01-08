using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _diedMenu;

    [SerializeField] private AudioSource _audio;

    private Rigidbody _rigidbody;
    private Vector3 _input;

    private bool _isGround;

    private int _point;
    [SerializeField] private TextMeshProUGUI text;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Point());
    }
    private void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _rigidbody.MovePosition(_rigidbody.position + _input * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Enemy enemy))
            Die();
        if (collision.collider.TryGetComponent(out Ground ground))
            _isGround = true;
    }

    private void Die()
    {
        StopCoroutine(Point());
        gameObject.SetActive(false);
        Time.timeScale = 0;
        _diedMenu.SetActive(true);
        _audio.Play();

        if (Progress.Instance.PlayerInfo._point >= _point)
        {
            Progress.Instance.PlayerInfo._point = _point;
        }
    }

    private IEnumerator Point()
    {
        var seconds = new WaitForSeconds(1);
        _point++;
        text.text = _point.ToString();
        yield return seconds;
    }
}
