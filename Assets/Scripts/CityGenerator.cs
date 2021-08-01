using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour{
    public static Texture2D TextureWithCities(Color[] colorMap, int width, int height){
        Debug.Log("Cities Call");
        Texture2D texture = new Texture2D (width, height);
        Color grass = new Color (0.2499731f, 0.6226415f, 0.1497864f, 0);
        Color city = new Color (1f, 0.058f, 0.749f, 0);
        int min = 0;
        int max = 700;

        Debug.Log(grass);
        for (int i = 0; i < colorMap.Length; i++){
            Debug.Log("Loop");
            int rowOverPoint = (width * height) - height;
            if(colorMap[i] == grass){
                int num = Random.Range(min, max);
                if(num == 0){
                    if(i > height && i < rowOverPoint){
                        colorMap[i] = city;
                        colorMap[i + 1] = city;
                        colorMap[i + height] = city;
                        colorMap[i + height + 1] = city;
                    }else{
                        colorMap[i] = city;
                        colorMap[i + 1] = city;
                    }
                }

                
            }
        }
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels (colorMap);
        texture.Apply ();
        return texture;
    }
}
