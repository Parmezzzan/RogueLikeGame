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
        var obj =  new GameObject();
        obj.transform.SetParent(objectRoot);
        obj.transform.position = pos;
        obj.transform.localScale = new Vector3() { x = scale.x, y = scale.y, z = 0.0f };

        var spriteComponent = obj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteComponent.sprite = sprite;

        if(anableRandomMirroring_X)
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                spriteComponent.flipX = true;

        if (anableRandomMirroring_Y)
            if (Random.Range(0.0f, 1.0f) > 0.5f)
                spriteComponent.flipY = true;

        return obj;
    }
}
