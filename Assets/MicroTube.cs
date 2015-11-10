using UnityEngine;

// マイクロチューブ1つ1つのオブジェクト
public class MicroTube : MonoBehaviour
{

    // これはC#のプロパティってやつで，このクラス内では値を代入できるけど
    // 外部からはできない。取得はどこからでも可能
    public LineRenderer Line { private set; get; }
    public Vector3 Start { private set; get; }
    public Vector3 End { private set; get; }

    // start -> endに線を生成するだけ
    static public MicroTube Instantiate(Vector3 start, Vector3 end)
    {
        var obj = new GameObject();
        var microTube = obj.AddComponent<MicroTube>();
        var renderer = obj.AddComponent<LineRenderer>();

        // 直線だから点は2つでそこにstartとendを登録する
        renderer.SetVertexCount(2);
        renderer.SetPosition(0, start);
        renderer.SetPosition(1, end);

        microTube.Line  = renderer;
        microTube.Start = start;
        microTube.End   = end;

        return microTube;
    }

    public void ApplyColor(Color color) { Line.material.color = color; }
    public void ApplyWidth(float width) { Line.SetWidth(width, width); }

}