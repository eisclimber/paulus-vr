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
        // PutBackSocketInteractor putBackSocket;

        // protected override void OnEnable()
        // {
        //     base.OnEnable();

        //     putBackSocket = (PutBackSocketInteractor)target;
        // }

        // public override void OnInspectorGUI()
        // {
        //     serializedObject.UpdateIfRequiredOrScript();

        //     DrawBeforeProperties();
        //     EditorGUILayout.Space();
        //     DrawPutBackProperties();
        //     EditorGUILayout.Space();
        //     DrawHighlightingProperties();
        //     EditorGUILayout.Space();
        //     DrawBaseSocketProperties();

        //     serializedObject.ApplyModifiedProperties();
        // }

        // protected void DrawPutBackProperties()
        // {
        //     bool locked = putBackSocket.externallyControlled;
        //     EditorGUILayout.LabelField("Put Back Object", EditorStyles.boldLabel);
        //     EditorGUI.indentLevel++;
            
        //     if (locked)
        //     {
        //         EditorGUILayout.HelpBox("This object is currently controlled by an Exhibition Display. "
        //             + "Please use that to edit the putbackPrefab.", MessageType.Warning);
        //     }

        //     EditorGUI.BeginDisabledGroup(locked);
        //         EditorGUI.BeginChangeCheck();
        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_putBackPrefab"), true);

        //         if (EditorGUI.EndChangeCheck())
        //         {
        //             // Update displayed prefab only when necessary
        //             serializedObject.ApplyModifiedProperties();
        //             putBackSocket.UpdatePutBackObject();
        //         }
        //         else if (!putBackSocket.ArePutBackReferencesValid())
        //         {
        //             // Displayed prefab seems invalid -> Try Update/Recreate
        //             Debug.LogWarning("The references of your PutBackPrefab seem invalid! Maybe you deleted the object. "
        //                                 + $"If you want to delete it for good, remove it the PutBackPrefab of { putBackSocket }.");
        //             serializedObject.ApplyModifiedProperties();
        //             putBackSocket.UpdatePutBackObject();
        //         }

        //         // Display reference to the actual held prefab instance
        //         EditorGUI.BeginDisabledGroup(true);
        //             EditorGUILayout.PropertyField(serializedObject.FindProperty("_putBackInstance"), true);
        //             EditorGUILayout.PropertyField(serializedObject.FindProperty("_putBackInteractable"), true);
        //         EditorGUI.EndDisabledGroup();
        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_allowNonInteractables"), true);
        //         EditorGUI.BeginChangeCheck();         
        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_compensateInteractableAttach"), true);
        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_disableRetainTransformParent"), true);

        //         EditorGUILayout.Space();

        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_omitInitialSelectEnterEvent"), true);
        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_omitInitialSelectExitEvent"), true);
                
        //         EditorGUILayout.Space();

        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("_putBackTime"), true);

        //         EditorGUILayout.Space();

        //         EditorGUILayout.PropertyField(serializedObject.FindProperty("OnPutBack"), true);
        //     EditorGUI.EndDisabledGroup();
        //     EditorGUI.indentLevel--;
        // }
    }
}