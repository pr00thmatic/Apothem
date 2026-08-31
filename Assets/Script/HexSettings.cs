#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif

using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "HexSettings", menuName = "HexSettings")]
public class HexSettings : ScriptableObject {
    private static HexSettings instance;
    public static HexSettings Instance {
        get {
            if (!instance)
                instance = Addressables.LoadAssetAsync<HexSettings>(nameof(HexSettings)).WaitForCompletion();

            return instance;
        }
    }

    public const float DEG = 60;
    public const float RAD = Mathf.PI / 3f;
    public Hex hexPrefab;

    [field:SerializeField] public float SideSize { get; set; }
    public float Apothem => Mathf.Tan(RAD) * SideSize;

    public HexSettings GetFromAddressable()
    {
        if (Application.isPlaying)
        {
            return Addressables.LoadAssetAsync<HexSettings>(nameof(HexSettings)).WaitForCompletion();
        }
#if UNITY_EDITOR
        else
        {
            AddressableAssetSettings settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) return null;

            foreach (var group in settings.groups)
            {
                foreach (AddressableAssetEntry entry in group.entries)
                {
                    if (entry.address == nameof(HexSettings))
                    {
                        string assetPath = AssetDatabase.GUIDToAssetPath(entry.guid);
                        return AssetDatabase.LoadAssetAtPath<HexSettings>(assetPath);
                    }
                }
            }
        }
#endif
        return null;
    }
}
