using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfiguration : MonoBehaviour
{
    [SerializeField]
    public int MapUnit_Width;
    [SerializeField]
    public int MapUnit_Height;
    [SerializeField]
    public int TileSize;
    [SerializeField]
    public Vector2Int CenterStartPosition;
    [Space(10)]
    [SerializeField]
    public bool isChankGeneration = false;
    [SerializeField]
    public int chankSize = 5;

    public Vector2 CurrentCentralPosition;

    private void Start()
    {
        CurrentCentralPosition = CenterStartPosition;
    }
    public Vector2Int LeftTopPosition()
    {
        return new Vector2Int()
        {
            x = CenterStartPosition.x - MapUnit_Width / 2,
            y = CenterStartPosition.y + MapUnit_Height / 2
        };
    }
}
