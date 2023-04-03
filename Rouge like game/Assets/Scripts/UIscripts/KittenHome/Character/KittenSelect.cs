using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KittenSelect : MonoBehaviour
{
    [SerializeField]
    GameObject frame;
    [SerializeField]
    float s = 2;

    public GameObject target;
    public KittenChoiseMem.kittenName nameTarget;
    public void UpdateframeTarget(GameObject newTarget)
    {
        StopAllCoroutines();
        target = newTarget;
        StartCoroutine(MoveFrame());
    }

    private void Start()
    {
        KittenChoiseMem.nameKitten = nameTarget = SaveManager.LoadSavefile().chosenKitten;
        var l = FindObjectsOfType<CharacterNum>();
        bool find = false;
        foreach (var item in l)
        {
            if (item.name == nameTarget)
            {
                frame.transform.position = item.gameObject.transform.position;
                find = true;
                return;
            }
        }
        if(!find)
            frame.transform.position = target.transform.position;

    }

    private IEnumerator MoveFrame()
    {

        while (frame.transform.position != target.transform.position)
        {
            frame.transform.position = Vector3.MoveTowards(frame.transform.position, target.transform.position, s * Time.deltaTime);
            yield return null;
        }
        var file = SaveManager.LoadSavefile();
        file.chosenKitten = target.GetComponent<CharacterNum>().name;
        KittenChoiseMem.nameKitten = nameTarget = file.chosenKitten;
        SaveManager.Save(file);
    }
}
