using System;
using System.Linq;
using UnityEngine;

namespace SparkITD_MonoCheat
{
    class MenuDraw
    {
        private Rect _Menu = new Rect(20f, 20f, 150f, 100f);
        private Rect _Menu_off = new Rect(20f, 20f, 20f, 20f);
        private ExperimentalCamera _MainCamera;
        internal void MainMenu()
        {
            GUILayout.Window(999, _Menu, MenuDrawer, DrawHelp.SetGuiContent($"Main Menu"));
            //GUILayout.Label

        }
        internal void HiddenMenu()
        {
            GUILayout.Window(990, _Menu_off, MenuDrawer, DrawHelp.SetGuiContent($""));
            //GUILayout.Label

        }
        private void MenuDrawer(int id)
        {
            switch (id) {
                case 999:
                    MenuItems();
                    break;
                case 990:
                    MinimalMenu();
                    break;
            }
        }

        private string OverrideCharacterText
        {
            get { return (Options.OverrideCharacterData) ? "OFF" : "ON"; }
        }
        private string OverrideLightText
        {
            get { return (Options.OverrideLightData) ? "OFF" : "ON"; }
        }
        private void MinimalMenu()
        {
            if (GUILayout.Button($"Show", GUILayout.Width(30)))
            {
                Options.ShowMenu = !Options.ShowMenu;
            }

        }
        private void MenuItems() {
            GUILayout.Width(150);
            if (GUILayout.Button($"Change LightBulb " + OverrideLightText, GUILayout.Width(150)))
            {
                Options.OverrideLightData = !Options.OverrideLightData;
            }
            if (GUILayout.Button($"Set God " + OverrideCharacterText, GUILayout.Width(150)))
            {
                Options.OverrideCharacterData = !Options.OverrideCharacterData;
            }
            if (GUILayout.Button($"Refill Player", GUILayout.Width(150)))
            {
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Health).CurrentValue = MonoInstance.mainChar.Character.GetSpec(CharSpecType.Health).MaxValue;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Stamina).CurrentValue = MonoInstance.mainChar.Character.GetSpec(CharSpecType.Stamina).MaxValue;

                var lamps = (from item in MonoInstance.mainChar.Inventory.GetAllItems()
                                          where item.GetComponent<HandItems.Lamp>()
                                          orderby item.GetComponent<HandItems.Lamp>().LampResourceSec
                                          select item as HandItems.Lamp).ToList();
                foreach (var lamp in lamps) {
                    lamp.LampResourceSec = 9999f;
                    lamp.PointLight.range = 50f;
                }
                HandItems.Crowbar crowbar = (from item in MonoInstance.mainChar.Inventory.GetAllItems()
                                     where item.GetComponent<HandItems.Crowbar>()
                                     orderby item.GetComponent<HandItems.Crowbar>().UsageCount
                                     select item).First<HandItems.HandItem>().GetComponent<HandItems.Crowbar>();
                crowbar.Quality = HandItems.ItemQuality.Excellent;
                crowbar.UsageCount = 9999;
            }

            if (GUILayout.Button($"Set Stats", GUILayout.Width(150)))
            {
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Strength).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Strength).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Strength).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Perception).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Perception).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Perception).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Will).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Will).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Will).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Stamina).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Stamina).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Stamina).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Constitution).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Constitution).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Constitution).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Dexterity).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Dexterity).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Dexterity).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Speed).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Speed).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Speed).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Accuracy).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Accuracy).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Accuracy).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.VisionRange).CurrentValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.VisionRange).MaxValue = 999f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.VisionRange).OriginalValue = 999f;

                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Darkness).CurrentValue = 0f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Darkness).MaxValue = 0f;
                MonoInstance.mainChar.Character.GetSpec(CharSpecType.Darkness).OriginalValue = 0f;

                //MonoInstance.mainChar.Character.GetSpec(CharSpecType.DamageMelee).CurrentValue = 999f;
                //MonoInstance.mainChar.Character.GetSpec(CharSpecType.DamageMelee).MaxValue = 999f;
                //MonoInstance.mainChar.Character.GetSpec(CharSpecType.DamageMelee).OriginalValue = 999f;
            }
            if (GUILayout.Button($"Remove Buffs", GUILayout.Width(150)))
            {
                foreach (var buff in MonoInstance.mainChar.Character.Buffs) {
                    MonoInstance.mainChar.Character.RemoveBuff(buff.Name);
                }
                
            }
            if (GUILayout.Button($"Set Camera Distance", GUILayout.Width(150)))
            {
                ExperimentalCamera.Instance.Height = Options.ZoomDistance;
            }
            GUILayout.Label(Options.ZoomDistance.ToString(), GUILayout.Width(150));
            Options.ZoomDistance = (float)Math.Round(GUILayout.HorizontalSlider(Options.ZoomDistance, 1f, 25f, GUILayout.Width(150)), 1);
            GUILayout.BeginHorizontal();
            if (GUILayout.Button($"Fwd", GUILayout.Width(75)))
            {
                MonoInstance.mainChar.transform.position += MonoInstance.mainChar.transform.forward;
            }
            if (GUILayout.Button($"Bwd", GUILayout.Width(75)))
            {
                MonoInstance.mainChar.transform.position -= MonoInstance.mainChar.transform.forward;
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            if (GUILayout.Button($"Dwn", GUILayout.Width(75)))
            {
                MonoInstance.mainChar.transform.position -= MonoInstance.mainChar.transform.up;
            }
            if (GUILayout.Button($"Up", GUILayout.Width(75)))
            {
                MonoInstance.mainChar.transform.position += MonoInstance.mainChar.transform.up * 15;
            }
            GUILayout.EndHorizontal();
            if (GUILayout.Button($"Gravity Switch", GUILayout.Width(150)))
            {
                var gravityHandler = MonoInstance.mainChar.GetComponent<Rigidbody>();
                if (gravityHandler) {
                    gravityHandler.mass = 0f;
                    gravityHandler.useGravity = false;
                }
            }

            if (GUILayout.Button($"Hide Menu", GUILayout.Width(150)))
            {
                Options.ShowMenu = !Options.ShowMenu;
            }

        }
    }
}
