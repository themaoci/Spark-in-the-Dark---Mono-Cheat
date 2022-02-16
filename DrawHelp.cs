using UnityEngine;

namespace SparkITD_MonoCheat
{
    internal class DrawHelp
    {
        private static GUIContent _GuiContent = new GUIContent();
        internal static GUIContent SetGuiContent(string text)
        {
            _GuiContent.text = text;
            return _GuiContent;
        }
    }
}
