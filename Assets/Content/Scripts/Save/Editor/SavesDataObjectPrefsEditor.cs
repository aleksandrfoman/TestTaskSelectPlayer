using UnityEditor;
using UnityEngine;

namespace Content.Scripts.Save.Editor
{
    [CustomEditor(typeof(SaveDataObjectPrefs))]
    public class SavesDataObjectPrefsEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            SaveDataObjectPrefs savesDataObject = (SaveDataObjectPrefs) target;

            if (GUILayout.Button("Save"))
            {
                savesDataObject.Save();
            }
            if (GUILayout.Button("Load"))
            {
                savesDataObject.Load();
            }
            if (GUILayout.Button("Clear"))
            {
                savesDataObject.Clear();
            }

            EditorUtility.SetDirty(savesDataObject);
        }
    }
}
