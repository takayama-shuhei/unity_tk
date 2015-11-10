using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Collections;

public class MicroTubeGenerator : MonoBehaviour
{
    // すべてのMicroTubeに共通の設定になると思うので，
    // colorとwidthは生成するクラスが持ってる
    // この値はインスペクタからいじれる(SerializeField)
    [SerializeField] Color color;
    [SerializeField] float width;

    float r1 = 621.09f, r2 = 690.10f, r, theta, phi;

    void Start ()
    {
        var microTubes = new List<MicroTube> ();
        for (var j = 0; j < 7; j++) {
            for (var i = 0; i < 12; i++) {
                r = r1;
                phi = i * 30f / 180f * 3.14f;
                theta = j * 30f / 180f * 3.14f;
                float x = r * Mathf.Sin (theta) * Mathf.Cos (phi);
                float y = r * Mathf.Sin (theta) * Mathf.Sin (phi);
                float z = r * Mathf.Cos (theta);
                var microTube = MicroTube.Instantiate(Vector3.zero, new Vector3(x, y, z));
                microTube.ApplyColor(color);
                microTube.ApplyWidth(width);
                microTube.transform.SetParent(transform, false);
                microTubes.Add(microTube);
            }
        }
    }

    void Update ()
    {

    }
}
