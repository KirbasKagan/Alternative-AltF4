using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
   private static BackGroundMusic Instance;
   private bool muted = false;
   private AudioSource _audioSource;

   private void Awake()
   {
      if (Instance == null)
      {
         Instance = this;
         DontDestroyOnLoad(this.gameObject);
      }
      else
      {
         Destroy(this.gameObject);
      }

      _audioSource = this.GetComponent<AudioSource>();
   }

   private void Update()
   {
      if (Input.GetKeyDown(KeyCode.M))
      {
         muted = !muted;
      }

      if (muted)
      {
         _audioSource.enabled = false;
      }
      else
      {
         _audioSource.enabled = true;
      }
   }
}
