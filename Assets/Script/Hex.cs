using UnityEngine;
using TMPro;

public class Hex : MonoBehaviour
{
    public TMP_Text label;

    public void SetText (string text) => label.text = text;
}
