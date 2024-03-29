﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace SA.Utilities
{
    [ExecuteInEditMode]
    public class IconMaker : MonoBehaviour
    {
        public bool create;
        public RenderTexture ren;
        public Camera bakeCam;

        public string spriteName;

        // Update is called once per frame
        void Update()
        {
            if (create)
            {
                create = false;
                CreateIcon();
            }
        }

        void CreateIcon()
        {
            if (string.IsNullOrEmpty(spriteName))
            {
                spriteName = "icon";
            }

            string path = SaveLocation();
            path += spriteName;

            bakeCam.targetTexture = ren;

            RenderTexture currentRT = RenderTexture.active;
            bakeCam.targetTexture.Release();
            RenderTexture.active = bakeCam.targetTexture;
            bakeCam.Render();

            Texture2D imgPng = new Texture2D(bakeCam.targetTexture.width, bakeCam.targetTexture.height, TextureFormat.ARGB32, false);
            imgPng.ReadPixels(new Rect(0,0, bakeCam.targetTexture.width, bakeCam.targetTexture.height),0,0);
            imgPng.Apply();
            RenderTexture.active = currentRT;
            byte[] bytesPng = imgPng.EncodeToPNG();
            File.WriteAllBytes(path + ".png", bytesPng);
            AssetDatabase.Refresh(ImportAssetOptions.ForceUpdate);
        }

        string SaveLocation()
        {
            string saveLocation = Application.dataPath + "/Textures/Sprites/Icons/";

            if (!Directory.Exists(saveLocation))
            {
                Directory.CreateDirectory(saveLocation);
            }

            return saveLocation;
        }
    }
}