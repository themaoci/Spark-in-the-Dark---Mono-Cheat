using UnityEngine;

namespace SparkITD_MonoCheat
{
    public class MaoMono
    {
        public static GameObject go;
        public static void Initialize() {
            if (GameObject.Find("MaoMono-Spark") != null) return;

            go = new GameObject("MaoMono-Spark");
            UnityEngine.Object.DontDestroyOnLoad(go);
            go.AddComponent<MonoInstance>();
        }
    }
}
