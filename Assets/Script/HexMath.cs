using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class HexMath
{
    public const float SQRT3 = 1.7320508075688772f;
    public const float DEG = 60;
    public const float RAD = Mathf.PI / 3f;
    public static float Apothem => SQRT3 * HexSettings.Instance.SideSize / 2f;

    public static Vector3 ApoToCar (Vector3 apothesianPoint) =>
        new Vector3(Apothem * (2 * apothesianPoint.x + apothesianPoint.z), apothesianPoint.y,
                    Apothem * (SQRT3 * apothesianPoint.z));

    public static Vector3 CarToApo (Vector3 cartessianPoint) =>
        new Vector3((cartessianPoint.x - SQRT3 * cartessianPoint.z / 3f) / (2 * Apothem), cartessianPoint.y,
                    cartessianPoint.z / (SQRT3 * Apothem));

    public static Vector3Int CarToApoKey (Vector3 cartessianPoint) => ApoToApoKey(CarToApo(cartessianPoint));
    public static Vector3Int ApoToApoKey (Vector3 apothesianPoint) => Vector3Int.RoundToInt(apothesianPoint);

    public static Vector3 HexCenter (Vector3 cartessianPoint) => ApoToCar((Vector3) CarToApoKey(cartessianPoint));
}
