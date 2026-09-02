using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class HexGenerator : MonoBehaviour {
    private HashSet<Vector3Int> generated = new();
    [SerializeField] private Transform tilesFolder;
    [SerializeField] private Transform center;

    [Button]
    void ResetAll ()
    {
        for (int i=tilesFolder.childCount-1; i>=0; i--)
        {
            #if UNITY_EDITOR
            if (!Application.isPlaying)
                DestroyImmediate(tilesFolder.GetChild(i).gameObject);
            else
            #endif
                Destroy(tilesFolder.GetChild(i).gameObject);
        }
        center.position = Vector3.zero;
        generated.Clear();
    }

    [Button]
    void SpawnHoneycomb () {
        Vector3Int hexCenter = HexMath.CarToApoKey(center.position);
        SpawnSingle(hexCenter);

        for (int i=0; i<6; i++)
        {
            var piece = SpawnSingle(hexCenter + ((HexCardinal) i).ACoord());
        }
    }

    Hex SpawnSingle (Vector3Int apoKey)
    {
        if (generated.Contains(apoKey))
            return null;

        Hex spawned = Instantiate(HexSettings.Instance.HexPrefab);
        spawned.transform.position = HexMath.ApoToCar(apoKey);
        spawned.transform.parent = tilesFolder;
        spawned.name = apoKey.ToString();

        generated.Add(apoKey);

        return spawned;
    }
}
