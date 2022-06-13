using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemGenerator : MonoBehaviour
{
    [Header("generator option")]
    [SerializeField]
    private MapGenerator _mapGenerator;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _itemRoot;
    [SerializeField]
    private bool _isGenerateNew = true;
    [SerializeField] [Range(0, 20)]
    private int _maxItemOnMap = 3;
    [SerializeField] [Range(0.1f, 20.0f)]
    private float _itemSummaryCost = 1.0f;
    [SerializeField] [Range(1.0f, 30.0f)]
    private float _itemGenerateDistanse = 2.0f;
    [SerializeField]
    private float _trashHold = 2.0f;
    [Space(15)]
    [Header("Items fo generate")]
    [SerializeField]
    private ItemGameObject[] _objectSet;

    private Vector2Int chankSize;
    private Vector4 centralBox;
    private Vector2 mapSize;
    private Vector2 cornerMap;

    private List<GameObject> _generatedObj;
    public void Generate()
    {
        if (_maxItemOnMap > 0)
        {
            List<GameObject> generatedList = new List<GameObject>();
            Vector2 corner = _mapGenerator.GetBotLeftCorner();
            Vector2Int mapUnitSize = _mapGenerator.GetMapSize();
            float costReduce = _itemSummaryCost;
            //trying generate MAX items with all money
            for (int i = 0; i < _maxItemOnMap; i++)
            {
                int indexGenerate = FindObjIndexForGenerate(ref costReduce);
                if (indexGenerate == -1) break;
                //find a Position for instanse
                Vector3 pos = new Vector3();
                int tryingNum = 300;
                bool find = false;
                while (tryingNum > 0 && find == false)
                {
                    pos = new Vector3(UnityEngine.Random.Range(corner.x, corner.x + mapUnitSize.x),
                                      UnityEngine.Random.Range(corner.y, corner.y + mapUnitSize.y),
                                      0.0f);
                    if (generatedList.Count > 0)
                        foreach (GameObject item in generatedList)
                        {
                            if (Vector3.Distance(item.transform.position, pos) > _itemGenerateDistanse)
                            {
                                find = true;
                            }
                            else
                            {
                                find = false;
                                break;
                            }
                        }
                    else
                        break;

                    tryingNum--;
                }
                //break generating
                if (tryingNum == 0) break;

                generatedList.Add(Instantiate(_objectSet[indexGenerate]._item, pos, Quaternion.identity, _itemRoot));
            }

            _generatedObj = generatedList;
        }

        chankSize = _mapGenerator.GetChankUnitSize();
        mapSize = _mapGenerator.GetMapSize();

        cornerMap = _mapGenerator.GetBotLeftCorner();
        centralBox = _mapGenerator.GetCentralBox();
    }
    private void Update()
    {
        //top
        if (_target.position.y > centralBox.y + _trashHold)
        {
            if (_isGenerateNew)
            {
                if (_maxItemOnMap / _mapGenerator.GetChankCol().x > 0)
                {
                    for (int i = 0; i < _generatedObj.Count; i++)
                    {
                        if (_generatedObj[i].transform.position.y < cornerMap.y + chankSize.y) 
                        { 
                        GameObject tmp = _generatedObj[i];
                        _generatedObj.RemoveAt(i);
                            Destroy(tmp);
                        }
                    }

                    float costReduce = _itemSummaryCost / _mapGenerator.GetChankCol().x;
                    List<GameObject> GeneratedList = new List<GameObject>();

                    for (int i = 0; i < _maxItemOnMap / _mapGenerator.GetChankCol().x; i++)
                    {
                        int index = FindObjIndexForGenerate(ref costReduce);
                        if (index == -1) break;
                        Vector2 boxSize = new Vector2(chankSize.x * _mapGenerator.GetChankCol().x, chankSize.y);
                        Vector2 corner = new Vector2(cornerMap.x, cornerMap.y + mapSize.y - chankSize.y);
                        Vector3 pos = FindPosForItem(corner, boxSize, ref GeneratedList);
                        if (pos == Vector3.zero) break;
                        GeneratedList.Add(Instantiate(_objectSet[index]._item, pos, Quaternion.identity, _itemRoot));
                    }
                    _generatedObj.AddRange(GeneratedList);
                }
            }
            else
                foreach (GameObject item in _generatedObj)
                    if (item.transform.position.y < cornerMap.y + chankSize.y)
                        item.transform.position += Vector3.up * mapSize.y;

            centralBox = _mapGenerator.GetCentralBox();
            cornerMap = _mapGenerator.GetBotLeftCorner();
        }
        //bot
        if (_target.position.y < centralBox.x - _trashHold)
        {
            foreach (GameObject item in _generatedObj)
                if (item.transform.position.y > cornerMap.y + mapSize.y - chankSize.y)
                    item.transform.position += Vector3.down * mapSize.y;

            centralBox = _mapGenerator.GetCentralBox();
            cornerMap = _mapGenerator.GetBotLeftCorner();
        }
        //right
        if (_target.position.x > centralBox.w + _trashHold)
        {
            foreach (GameObject item in _generatedObj)
                if (item.transform.position.x < cornerMap.x + chankSize.x)
                    item.transform.position += Vector3.right * mapSize.x;

            centralBox = _mapGenerator.GetCentralBox();
            cornerMap = _mapGenerator.GetBotLeftCorner();
        }
        //left
        if (_target.position.x < centralBox.z - _trashHold)
        {
            foreach (GameObject item in _generatedObj)
                if (item.transform.position.x > cornerMap.x + mapSize.x - chankSize.x)
                    item.transform.position += Vector3.left * mapSize.x;

            centralBox = _mapGenerator.GetCentralBox();
            cornerMap = _mapGenerator.GetBotLeftCorner();
        }
    }
    private int FindObjIndexForGenerate(ref float coastReduce)
    {
        int tryingNum = 300;
        int indexGenerate = 0;
        //find a obj for instanse
        while (tryingNum > 0)
        {
            indexGenerate = UnityEngine.Random.Range(0, _objectSet.Length);
            if (_objectSet[indexGenerate]._rareRank < coastReduce)
            {
                coastReduce -= _objectSet[indexGenerate]._rareRank;
                break;
            }
            tryingNum--;
        }
        //break generating
        if (tryingNum == 0)
            return -1;
        else
            return indexGenerate;
    }
    private Vector3 FindPosForItem(Vector2 corner, Vector2 Size, ref List<GameObject> generatedList)
    {
        Vector3 pos = Vector3.zero;
        GameObject generateobject = new GameObject();
        int tryingNum = 300;
        bool find = false;
                while (tryingNum > 0 && find == false)
                {
                    pos = new Vector3(UnityEngine.Random.Range(corner.x, corner.x + Size.x),
                                      UnityEngine.Random.Range(corner.y, corner.y + Size.y),
                                      0.0f);
                    if (generatedList.Count > 0)
                        foreach (GameObject item in generatedList)
                        {
                            if (Vector3.Distance(item.transform.position, pos) > _itemGenerateDistanse)
                            {
                                find = true;
                            }
                            else
                            {
                                find = false;
                                break;
                            }
                        }
                    else
                        break;

                    tryingNum--;
                }
        return pos;           
    }
    [Serializable]
    struct ItemGameObject
    {
        public GameObject _item;
        public float _rareRank;
    }
}
