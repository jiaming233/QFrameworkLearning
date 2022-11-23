using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp.Editor
{
    public class EditorCounterApp : EditorWindow
    {
        [MenuItem("EditorCounterApp/Open")]
        static void Open()
        {
            var window = GetWindow<EditorCounterApp>();
            window.position = new Rect(100, 100, 400, 600);
            window.titleContent = new GUIContent(nameof(EditorCounterApp));
            window.Show();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("+"))
            {
                new AddCountCommand().Execute();
            }

            GUILayout.Label(CounterApp.CounterModel.Count.Value.ToString());

            if (GUILayout.Button("-"))
            {
                new SubCountCommand().Execute();
            }
        }
    }
}

