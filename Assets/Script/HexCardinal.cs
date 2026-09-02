using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HexCardinal {
    E = 0,
    NE=1, NW=2,
    W=3,
    SW=4, SE=5
}

public static class HexCardinalsExtensions
{
    public static float Rad (this HexCardinal target) => ((int) target) * HexMath.RAD;

    public static Vector3 Coord (this HexCardinal target)
        => new Vector3(HexMath.Apothem * 2 * Mathf.Cos(target.Rad()), 0,
                       HexMath.Apothem * 2 * Mathf.Sin(target.Rad()));

    // baked since this is used very often. But really it's the same as => HexMath.CarToApo(target.Coord)
    public static Vector3Int ACoord (this HexCardinal target)
        => target switch
    {
        HexCardinal.E => new(1,0,0),
        HexCardinal.NE => new(0,0,1),
        HexCardinal.NW => new(-1,0,1),
        HexCardinal.W => new(-1,0,0),
        HexCardinal.SW => new(0,0,-1),
        HexCardinal.SE => new(1,0,-1),
        _ => new(0,0,0)
    };
}
