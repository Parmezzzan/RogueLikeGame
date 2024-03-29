using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScripm : MonoBehaviour
{
   
    [SerializeField] private GameObject _object; //An object camera will follow
    [SerializeField] private Vector3 _distanceFromObject; // Camera's distance from the object
    [SerializeField] private float smooth = 0.125f;
    //Event function
    private void LateUpdate() //Works after all update functions called
    {
        Vector3 positionToGo = _object.transform.position + _distanceFromObject; //Target position of the camera
        Vector3 smoothPosition = Vector3.Lerp(a: transform.position, b: positionToGo, t: smooth); //Smooth position of the camera
        transform.position = smoothPosition;
        //transform.LookAt(_object.transform.position); //Camera will look(returns) to the object
    }

}
