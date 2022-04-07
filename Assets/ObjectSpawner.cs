using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class ObjectSpawner : MonoBehaviour
{
   [SerializeField] private ARTrackedImageManager _manager;
   [SerializeField] private Canvas plouf;
   [SerializeField] private GameObject romsteack;
   private GameObject _hamburger;
   private GameObject _hamburgerFrites;
   private void OnEnable()
   {
      _manager.trackedImagesChanged += OnTrackerImageChanged;
   }

   private void OnDisable()
   {
      _manager.trackedImagesChanged -= OnTrackerImageChanged;
   }

   private void OnTrackerImageChanged(ARTrackedImagesChangedEventArgs args)
   {
      if (args.added[0]!=null)
      {
         _hamburger=Instantiate(romsteack);
         romsteack.transform.position = args.added[0].transform.position;
      }

      if (args.updated[0]!=null)
      {
         _hamburger.transform.position = args.updated[0].transform.position;
         /*if (Input.GetTouch(0).phase == TouchPhase.Began)
         {
            _hamburgerFrites = _hamburger;
            _hamburgerFrites.transform.position = _hamburger.transform.position;
            Instantiate(_hamburgerFrites.transform);
            _hamburgerFrites.transform.forward;
         }*/
      }
      
      if (args.removed[0]!=null)
      {
         Destroy(_hamburger);
      }
      
      /*if (args.added[0]!=null && romsteack.gameObject.activeInHierarchy == false)
      {
         romsteack.gameObject.SetActive(true);
         romsteack.transform.position = args.added[0].transform.position;
         
      }

      if (args.updated[0]!=null)
      {
         romsteack.transform.position = args.updated[0].transform.position;
      }
      
      if (args.removed[0]!=null)
      {
         romsteack.SetActive(false);
      }*/
   }
}
