using UnityEngine;

[CreateAssetMenu(fileName = "HexSettings", menuName = "HexSettings")]
public class HexSettings : ScriptableSingleton<HexSettings>
{
    [field:SerializeField] public Hex HexPrefab { get; set; }
    [field:SerializeField] public float SideSize { get; set; }
}
