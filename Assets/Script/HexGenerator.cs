using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class HexGenerator : MonoBehaviour {
    private HashSet<Vector3Int> generated = new();

    [Button]
    void Spawn () {
        for (int i=0; i<6; i++) {
            var piece = Instantiate(HexSettings.Instance.HexPrefab);
            piece.transform.position = transform.position + ((HexCardinal) i).Coord();
        }
    }
}
