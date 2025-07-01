using UnityEngine;
using UnityEditor;
using UnityEngine.XR.Interaction.Toolkit;
using ExPresSXR.Interaction;
using UnityEditor.VersionControl;


namespace ExPresSXR.Editor.Editors
{
    [CustomEditor(typeof(ClothTileRespawnSocket))]
    [CanEditMultipleObjects]
    public class ClothTileRespawnSocketEditor : PutBackSocketInteractorEditor
    {

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            DrawBeforeProperties();
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Cloth Tiles", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_respawnVariants"), true);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("_scoreReferenceTransform"), true);
            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            DrawPutBackProperties();
            EditorGUILayout.Space();
            DrawHighlightingProperties();
            EditorGUILayout.Space();
            DrawBaseSocketProperties();

            serializedObject.ApplyModifiedProperties();
        }
    }
}