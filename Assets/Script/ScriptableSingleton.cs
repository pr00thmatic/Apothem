#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.AddressableAssets;

public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            if (!instance)
                instance = GetFromAddressable();

            return instance;
        }
    }

    protected static T GetFromAddressable()
    {
        if (Application.isPlaying)
        {
            return Addressables.LoadAssetAsync<T>(typeof(T).ToString()).WaitForCompletion();
        }
#if UNITY_EDITOR
        else
        {
            return AssetDatabase.LoadAssetByGUID<T>(new(AssetDatabase.FindAssets($"t:{typeof(T).ToString()}")[0]));
        }
#else
        return null;
#endif
    }
}
