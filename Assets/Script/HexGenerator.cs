using UnityEngine;
using NaughtyAttributes;
using System.Collections.Generic;

public class HexGenerator : MonoBehaviour {
    private HashSet<Vector2> generated = new();

    [Button]
    void Spawn () {
        for (int i=0; i<6; i++) {
            var piece = Instantiate(HexSettings.Instance.hexPrefab);
            piece.transform.position = transform.position + ((HexCardinal) i).Coord();
            piece.SetText(((HexCardinal) i).ACoord().ToString());
        }
    }
}
