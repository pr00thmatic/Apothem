using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HexCardinal {
    E = 0,
    NE=1, NO=2,
    O=3,
    SO=4, SE=5
}

public static class HexCardinalsExtensions
{
    public static float Rad (this HexCardinal target) => ((int) target) * HexSettings.RAD;

    public static Vector3 Coord (this HexCardinal target)
        => new Vector3(HexSettings.Instance.Apothem * Mathf.Cos(target.Rad()), 0,
                       HexSettings.Instance.Apothem * Mathf.Sin(target.Rad()));

    public static Vector3 ACoord (this HexCardinal target)
        => new Vector3((target.Coord().x - (Mathf.Sqrt(3) / 3) * target.Coord().z) / HexSettings.Instance.Apothem, 0,
                       (2*target.Coord().z) / (HexSettings.Instance.Apothem * Mathf.Sqrt(3)));
}
