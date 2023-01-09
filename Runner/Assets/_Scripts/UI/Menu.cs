using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = "Record: " + Progress.Instance.PlayerInfo._point.ToString();
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
