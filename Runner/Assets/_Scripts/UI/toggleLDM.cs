using UnityEngine;
using UnityEngine.UI;

public class toggleLDM : MonoBehaviour
{
    public void lDM(Toggle toggle)
    {
        Progress.Instance.PlayerInfo._LDM = toggle.isOn;
    }
}
