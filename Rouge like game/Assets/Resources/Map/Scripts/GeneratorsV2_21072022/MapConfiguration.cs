using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfiguration : MonoBehaviour
{
    [SerializeField]
    public float MapUnit_Width;
    [SerializeField]
    public float MapUnit_Height;
    [SerializeField]
    public float TileSize;
    [SerializeField]
    public Vector2 CenterStartPosition;
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
    public Vector2 LeftTopPosition()
    {
        return new Vector2()
        {
            x = CenterStartPosition.x - MapUnit_Width / 2,
            y = CenterStartPosition.y + MapUnit_Height / 2
        };
    }
}
