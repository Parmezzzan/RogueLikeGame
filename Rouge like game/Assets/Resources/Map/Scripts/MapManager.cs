using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Transform mapRootTransform;
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Biom[] biomSet;
    [SerializeField]
    private GameObject trackingTarget;
    [SerializeField]
    private int trasholdTileRedraw;

    [Header("Map option")]
    [Space(20)]
    [SerializeField]
    private Vector2Int chankCol;
    [SerializeField]
    private Vector2Int chankSize;
    [SerializeField]
    private Vector2Int tileUnitSize;
    [Header("Map control")]
    [SerializeField]
    private bool generateOnZero = true;
    [SerializeField]
    private Vector2Int _startMapPosition;

    private int botCentralChankPos;
    private int topCentralChankPos;
    private int rightCentralChankPos;
    private int leftCentralChankPos;

    private Vector2Int chankUnitSize;

    private Chank[] chankSet;
    void Start()
    {
        chankSet = new Chank[chankCol.x * chankCol.y];
        chankUnitSize = new Vector2Int(chankSize.x * tileUnitSize.x, chankSize.y * tileUnitSize.y);
        Vector2Int cornerPos = new Vector2Int(_startMapPosition.x - chankCol.x * chankUnitSize.x / 2,
                                              _startMapPosition.y - chankCol.y * chankUnitSize.y / 2);


        for (int i = 0; i < chankCol.y; i++)
        {
            for (int j = 0; j < chankCol.x; j++)
            {
                Vector2Int pos = new Vector2Int(cornerPos.x + j * chankUnitSize.x,
                                                cornerPos.y + i * chankUnitSize.y);
                chankSet[i * chankCol.x + j] = new Chank(pos, chankSize, tileUnitSize, biomSet[Random.Range(0, biomSet.Length)], i * chankCol.x + j);
            }
        }

        for (int i = 0; i < chankSet.Length; i++)
        {
            chankSet[i].DrawChank(tilePrefab, mapRootTransform);
        }

        updateCentralBox();

        chankUnitSize = new Vector2Int(chankSize.x * tileUnitSize.x, chankSize.y * tileUnitSize.y);
    }
    private void Update()
    {
        if (trackingTarget.transform.position.y < botCentralChankPos - trasholdTileRedraw)
        {
            Vector2 cornerPos = findCornerPos();
            cornerPos.y -= chankUnitSize.y;

            for (int i = 0; i < chankCol.y; i++)
            {
                for (int j = 0; j < chankCol.x; j++)
                {
                    int currentIndex = i * chankCol.x + j;

                    if (chankSet[currentIndex].index >= chankCol.x * (chankCol.y - 1))
                    {
                        chankSet[currentIndex].SetPosition(new Vector2(cornerPos.x + chankUnitSize.x * (chankSet[currentIndex].index % chankCol.x), cornerPos.y));
                        chankSet[currentIndex].index = chankSet[currentIndex].index % chankCol.x;
                        chankSet[currentIndex].deleteAllTile();
                        chankSet[currentIndex].DrawChank(tilePrefab, mapRootTransform);
                    }
                    else
                        chankSet[currentIndex].index += chankCol.x;

                }
            }
            updateCentralBox();
        }
        if (trackingTarget.transform.position.y > topCentralChankPos + trasholdTileRedraw)
        {
            Vector2 cornerPos = findCornerPos();
            cornerPos.y += chankUnitSize.y * chankCol.y;

            for (int i = 0; i < chankCol.y; i++)
            {
                for (int j = 0; j < chankCol.x; j++)
                {
                    int currentIndex = i * chankCol.x + j;

                    if (chankSet[currentIndex].index < chankCol.x)
                    {
                        chankSet[currentIndex].SetPosition(new Vector2(cornerPos.x + chankSet[currentIndex].index * chankUnitSize.x, cornerPos.y));
                        chankSet[currentIndex].index = chankCol.x * (chankCol.y - 1) + chankSet[currentIndex].index;
                        chankSet[currentIndex].deleteAllTile();
                        chankSet[currentIndex].DrawChank(tilePrefab, mapRootTransform);
                    }
                    else
                        chankSet[currentIndex].index -= chankCol.x;

                }
            }
            updateCentralBox();
        }
        if (trackingTarget.transform.position.x > rightCentralChankPos + trasholdTileRedraw)
        {
            Vector2 cornerPos = findCornerPos();
            cornerPos.x += chankUnitSize.x * chankCol.x;

            for (int i = 0; i < chankCol.y; i++)
            {
                for (int j = 0; j < chankCol.x; j++)
                {
                    int currentIndex = i * chankCol.x + j;

                    if (chankSet[currentIndex].index % chankCol.x == 0)
                    {
                        chankSet[currentIndex].SetPosition(new Vector2(cornerPos.x, cornerPos.y + (float)(chankSet[currentIndex].index / chankCol.x) * chankUnitSize.y));
                        chankSet[currentIndex].index += chankCol.x - 1;
                        chankSet[currentIndex].deleteAllTile();
                        chankSet[currentIndex].DrawChank(tilePrefab, mapRootTransform);
                    }
                    else
                        chankSet[currentIndex].index -= 1;

                }
            }
            updateCentralBox();
        }
        if (trackingTarget.transform.position.x < leftCentralChankPos - trasholdTileRedraw)
        {
            Vector2 cornerPos = findCornerPos();
            cornerPos.x -= chankUnitSize.x;

            for (int i = 0; i < chankCol.y; i++)
            {
                for (int j = 0; j < chankCol.x; j++)
                {
                    int currentIndex = i * chankCol.x + j;

                    if (chankSet[currentIndex].index % chankCol.x == chankCol.x - 1)
                    {
                        chankSet[currentIndex].SetPosition(new Vector2(cornerPos.x, cornerPos.y + (chankSet[currentIndex].index / chankCol.x) * chankUnitSize.y));
                        chankSet[currentIndex].index -= chankCol.x - 1;
                        chankSet[currentIndex].deleteAllTile();
                        chankSet[currentIndex].DrawChank(tilePrefab, mapRootTransform);
                    }
                    else
                        chankSet[currentIndex].index += 1;

                }
            }
            updateCentralBox();
        }
    }
    private Vector2 findCornerPos()
    {
        Vector2 cornerPos = new Vector2();

        for (int i = 0; i < chankSet.Length; i++)
        {
            if (chankSet[i].index == 0)
            {
                cornerPos = chankSet[i].GetPosition();
                break;
            }
        }

        return cornerPos;
    }
    private void updateCentralBox()
    {
        for (int i = 0; i< chankSet.Length; i++)
        {
            if(chankSet[i].index == chankSet.Length / 2)
                {
                print("YES i'm find a central BOX");
                    botCentralChankPos = chankSet[i].getBotPos();
                    topCentralChankPos = chankSet[i].getTopPos();
                    leftCentralChankPos = chankSet[i].getLeftPos();
                    rightCentralChankPos = chankSet[i].getRightPos();
                print(botCentralChankPos);
                print(topCentralChankPos);
                print(rightCentralChankPos);
                print(leftCentralChankPos);
                break;
                }
        }
    }
    class Chank
    {
        public int index { get; set; }
        private Vector2 _pos;
        private Vector2 _size;
        private Vector2 _tileSize;
        private float _rareRank = 1.0f;
        private Sprite[] _spriteSet;
        private GameObject[] _gameObjectsTile;
        public Chank(Vector2 pos, Vector2 size, Vector2 tileSize, Biom biom, int newIndex)
        {
            index = newIndex;
            _pos = pos;
            _size = size;
            _tileSize = tileSize;
            _rareRank = biom.rareRank;
            _spriteSet = new Sprite[(int)_size.x * (int)_size.y];
            _gameObjectsTile = new GameObject[(int)_size.x * (int)_size.y];

            for (int i = 0; i < _spriteSet.Length; i++)
            {
                    _spriteSet[i] = biom.tileSprites[Random.Range(0, biom.tileSprites.Length)];
            }
        }
        public Vector2 GetPosition() { return _pos; }
        public void SetPosition(Vector2 newPos)
        {
            _pos = newPos;
        }
        public void DrawChank(GameObject prefab, Transform root)
        {
            for (int i = 0; i < (int)_size.y; i++)
            {
                for (int j = 0; j < (int)_size.x; j++)
                {
                    Vector3 position = new Vector3(_pos.x + j * _tileSize.x, _pos.y + i * _tileSize.y);

                    int ind = i * (int)_size.x + j;
                    _gameObjectsTile[ind] = Instantiate(prefab, position, Quaternion.identity, root);
                    _gameObjectsTile[ind].GetComponent<SpriteRenderer>().sprite = _spriteSet[ind];
                    _gameObjectsTile[ind].transform.localScale = new Vector3(_tileSize.x, _tileSize.y);
                }
            }
        }
        public void deleteAllTile()
        {
            for (int i = 0; i < _gameObjectsTile.Length; i++)    Destroy(_gameObjectsTile[i]);
        }
        public int getBotPos() { return (int)_pos.y; }
        public int getLeftPos() { return (int)_pos.x; }
        public int getRightPos() { return (int)(_pos.x + _size.x*_tileSize.x); }
        public int getTopPos() { return (int)(_pos.y + _size.y * _tileSize.y); }
    }
}
