using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAdv();
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = Progress.Instance.PlayerInfo._point.ToString();
        ShowAdv();
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene(1);
    }
}
