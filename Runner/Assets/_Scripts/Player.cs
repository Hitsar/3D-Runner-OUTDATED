using System.Collections;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    [DllImport("__Internal")]
    private static extern void SetToLeaderboard(int value);

    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    [SerializeField] private GameObject _diedMenu;

    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioSource _audioGold;
    [SerializeField] private AudioSource _audioGround;

    [SerializeField] private TextMeshProUGUI text;
    private int _point;

    private Rigidbody _rigidbody;
    private Vector3 _moveInput;

    private bool _isGround = true;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(Point());
    }
    private void Update()
    {
        _moveInput.x = Input.GetAxis("Horizontal");
        _rigidbody.MovePosition(_rigidbody.position + _moveInput * _speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isGround = true;
            _audioGround.Play();
        }
        if (collision.collider.TryGetComponent(out EnemyGold enemyG))
        {
            collision.gameObject.SetActive(false);
            _point++;
            _audioGold.Play();
        }
        if (collision.collider.TryGetComponent(out EnemyGame enemy))
        {
            Die();
        }
    }

    private void Die()
    {
        ShowAdv();

        StopCoroutine(Point());

        Time.timeScale = 0;
        _diedMenu.SetActive(true);
        _audio.Play();

        if (Progress.Instance.PlayerInfo.Point < _point)
        {
            Progress.Instance.PlayerInfo.Point = _point;
            SetToLeaderboard(Progress.Instance.PlayerInfo.Point);
            Progress.Instance.Save();
        }
    }

    private IEnumerator Point()
    {
        while (true)
        {
            var seconds = new WaitForSeconds(2);
            _point++;
            text.text = _point.ToString();
            yield return seconds;
        }
    }
}
