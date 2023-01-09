using UnityEngine;

public class LDM : MonoBehaviour
{
    [SerializeField] private GameObject particles;
    [SerializeField] private GameObject particles1;
    [SerializeField] private GameObject wall;
    private void Start()
    {
        if (Progress.Instance.PlayerInfo._LDM)
        {
            particles.SetActive(false);
            particles1.SetActive(false);
            wall.SetActive(true);
        }
    }
}
