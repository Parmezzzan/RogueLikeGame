using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapProducerV2 : MonoBehaviour
{
    [SerializeField]
    Sprite[] sprites;
    [SerializeField]
    Transform objectRoot;
    [SerializeField]
    bool anableRandomMirroring_X = true;
    [SerializeField]
    bool anableRandomMirroring_Y = true;
    [SerializeField]
    private ChankTileSet[] chankCollection = null;

    public void GenerateMap(MapConfiguration config)
    {
        int posX = config.LeftTopPosition().x;
        int posY = config.LeftTopPosition().y;

        int tileNumX = config.MapUnit_Width / config.TileSize;
        int tileNumy = config.MapUnit_Height / config.TileSize;

        for (int j = 0; j < tileNumy; j++)
        {
            for (int i = 0; i < tileNumX; i++)
            {
                var obj = generateTile(new Vector2Int() { x = posX, y = posY },
                            sprites[Random.Range(0, sprites.Length)],
                            new Vector2Int(config.TileSize, config.TileSize));

                obj.name = i.ToString() + j.ToString();
                posX += config.TileSize;
            }
            posX = (int)config.LeftTopPosition().x;
            posY -= config.TileSize;
        }
    }
    public GameObject generateTile(Vector2Int pos, Sprite sprite, Vector2Int scale)
    {
        var obj = new GameObject();
        obj.tag = "Map";
        obj.transform.SetParent(objectRoot);
        obj.transform.position = new Vector3(pos.x, pos.y, 0.0f);
        obj.transform.localScale = new Vector3() { x = scale.x, y = scale.y, z = 0.0f };

        var spriteComponent = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteComponent.sprite = sprite;

        if (anableRandomMirroring_X)
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                spriteComponent.flipX = true;

        if (anableRandomMirroring_Y)
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                spriteComponent.flipY = true;

        return obj;
    }
    public void GenerateChankMap(MapConfiguration config)
    {
        if (config.MapUnit_Height < config.chankSize ||
           config.MapUnit_Width < config.chankSize)
            throw new System.Exception();

        Vector2Int tilePerChank = new Vector2Int(config.chankSize, config.chankSize);
        Vector2Int tileSize = new Vector2Int(config.TileSize, config.TileSize);
        Vector2Int chankAmount = new Vector2Int(config.MapUnit_Width / config.chankSize,
                                               config.MapUnit_Height / config.chankSize);

        var chankCorner = ProducePositions(config.LeftTopPosition(), chankAmount, new Vector2Int(config.chankSize, config.chankSize));

        foreach (var corner in chankCorner)
        {
            int chankNum = Random.Range(0, chankCollection.Length);
            var posList = ProducePositions(corner, tilePerChank, tileSize);

            foreach (var tilePos in posList)
            {
                var arrAmount = chankCollection[chankNum].sprites.Length;
                var spite = chankCollection[chankNum].sprites[Random.Range(0, arrAmount)];
                generateTile(tilePos, spite, tileSize);
            }
        }
        
    }
    private List<Vector2Int> ProducePositions(Vector2Int topLeftCorner, Vector2Int tileAmount, Vector2Int tileSize)
    {
        List<Vector2Int> posList = new List<Vector2Int>();
        int posX = topLeftCorner.x;
        int posY = topLeftCorner.y;

        for (int j = 0; j < tileAmount.y; j++)
        {
            for (int i = 0; i < tileAmount.x; i++)
            {
                posList.Add(new Vector2Int(posX, posY));
                posX += tileSize.x;
            }
            posX = (int)topLeftCorner.x;
            posY -= tileSize.y;
        }

        return posList;
    }
}
