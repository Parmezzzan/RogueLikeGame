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
        float posX = config.LeftTopPosition().x;
        float posY = config.LeftTopPosition().y;

        int tileNumX = (int)(config.MapUnit_Width / config.TileSize);
        int tileNumy = (int)(config.MapUnit_Height / config.TileSize);

        for (int j = 0; j < tileNumy; j++)
        {
            for (int i = 0; i < tileNumX; i++)
            {
                var obj = generateTile(new Vector2() { x = posX, y = posY },
                            sprites[Random.Range(0, sprites.Length)],
                            new Vector2(config.TileSize, config.TileSize));

                obj.name = i.ToString() + j.ToString();
                posX += config.TileSize;
            }
            posX = (int)config.LeftTopPosition().x;
            posY -= config.TileSize;
        }
    }
    public GameObject generateTile(Vector2 pos, Sprite sprite, Vector2 scale)
    {
        var obj = new GameObject();
        obj.transform.SetParent(objectRoot);
        obj.transform.position = pos;
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
        Vector2 tileSize = new Vector2(config.TileSize, config.TileSize);
        Vector2Int chankAmount = new Vector2Int((int)(config.MapUnit_Width / config.chankSize),
                                               (int)(config.MapUnit_Height / config.chankSize));

        var chankCorner = ProducePositions(config.LeftTopPosition(), chankAmount, new Vector2(config.chankSize, config.chankSize));

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
    private List<Vector2> ProducePositions(Vector2 topLeftCorner, Vector2Int tileAmount, Vector2 tileSize)
    {
        List<Vector2> posList = new List<Vector2>();
        float posX = topLeftCorner.x;
        float posY = topLeftCorner.y;

        for (int j = 0; j < tileAmount.y; j++)
        {
            for (int i = 0; i < tileAmount.x; i++)
            {
                posList.Add(new Vector2(posX, posY));
                posX += tileSize.x;
            }
            posX = (int)topLeftCorner.x;
            posY -= tileSize.y;
        }

        return posList;
    }
}
