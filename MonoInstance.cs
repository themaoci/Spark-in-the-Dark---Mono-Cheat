using UnityEngine;

namespace SparkITD_MonoCheat
{
    class MonoInstance : MonoBehaviour
    {
        internal static MainChar mainChar {
            get { return MainChar.Instance; }
        }
        private MenuDraw MenuDraw = new MenuDraw();
        void Awake() { }
        void Start() { }
        void Update() {
            if (mainChar == null) return;
            CharacterData();
            LightData();
        }
        void OnGUI() {
            //if (MonoInstance.mainChar != null)
            //{
            //    GUI.Label(new Rect(2f, 2f, 200f, 25f),
            //        $"{Options.ShowMenu} x:{MonoInstance.mainChar.transform.position.x},y:{MonoInstance.mainChar.transform.position.y},z:{MonoInstance.mainChar.transform.position.z}",
            //        new GUIStyle() { normal = { textColor = Color.white } });
            //}
            //else
            //{
            //    GUI.Label(new Rect(2f, 2f, 200f, 25f),
            //        $"Menu: {Options.ShowMenu} {inserdDown1} {inserdDown2}",
            //        new GUIStyle() { normal = { textColor = Color.white } });
            //}
            if (Options.ShowMenu)
                MenuDraw.MainMenu();
            else
                MenuDraw.HiddenMenu();
        }

        void CharacterData() {
            if (Options.OverrideCharacterData)
            {
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.MaxWeight).MaxValue = 9999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.MaxWeight).OriginalValue = 9999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Health).CurrentValue = 9999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Health).MaxValue = 9999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Health).OriginalValue = 9999f;
            }
        }
        void LightData() {
            if (Options.OverrideLightData)
            {
                MonoInstance.mainChar.DefaultPointLight.range = 50f;
                MonoInstance.mainChar.DefaultPointLight.intensity = 2f;

                var lamp_temp = mainChar.GetLamp();
                if (lamp_temp != null)
                {
                    lamp_temp.LampResourceSec = 9999f;
                    lamp_temp.PointLight.range = 50f;
                    lamp_temp.PointLight.intensity = 2f;
                }
            }
        }
    }
}
