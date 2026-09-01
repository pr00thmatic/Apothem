using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class HexMath
{
    public const float SQRT3 = 1.7320508075688772f;
    public const float DEG = 60;
    public const float RAD = Mathf.PI / 3f;
    public static float Apothem => (SQRT3 * HexSettings.Instance.SideSize)/2f;

    public static Vector3 ApoToCar (Vector3 apothesianPoint) =>
        new Vector3((apothesianPoint.x - apothesianPoint.z * SQRT3/3f) / (2 * Apothem), apothesianPoint.y,
                    apothesianPoint.z / (Apothem * SQRT3));

    public static Vector3 CarToApo (Vector3 cartessianPoint) =>
        new Vector3(Apothem * (2 * cartessianPoint.x + cartessianPoint.z), cartessianPoint.y,
                    Apothem * SQRT3 * cartessianPoint.z);
}
