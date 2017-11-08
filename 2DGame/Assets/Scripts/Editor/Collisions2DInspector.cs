using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Collisions2D))]
public class Collisions2DInspector : Editor
{
    static bool stateFoldout;
    static bool drawDefaultInspector;

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI(); Si se deja escrito no afecta. Se visualiza de forma normal la informacion del inspector.
        Collisions2D col = (Collisions2D)target;

        GUIStyle booleanText = new GUIStyle();

        EditorGUILayout.Space();
        EditorGUI.indentLevel = 1;
        stateFoldout = EditorGUILayout.Foldout(stateFoldout, "State", true, EditorStyles.toolbarDropDown);

        //isGounded
        //col.isGrounded = EditorGUILayout.Toggle("Is Grounded", col.isGrounded, EditorStyles.booleanText);

        if(stateFoldout)
        {
            EditorGUI.indentLevel = 2;

            EditorGUILayout.BeginVertical(EditorStyles.textArea);


            if(col.isGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Ground", booleanText);

            if(col.wasGroundedLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Grounded Last Frame", booleanText);

            if(col.justGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Grounded", booleanText);

            if(col.justNOTGrounded) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just NOT Grounded", booleanText);

            if(col.isFalling) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Falling", booleanText);

            if(col.isHeadCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Head Collision", booleanText);

            if(col.wasHeadCollisionLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Head Collision Last Frame", booleanText);

            if(col.justHeadCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Head Collision", booleanText);

            if(col.justNOTHeadCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just NOT Head Collision", booleanText);

            if(col.isLateralCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Is Lateral Collision", booleanText);

            if(col.wasLateralCollisionLastFrame) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Was Lateral Collision Last Frame", booleanText);

            if(col.justLateralCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just Lateral Collision", booleanText);

            if(col.justNOTLateralCollision) booleanText.normal.textColor = Color.green;
            else booleanText.normal.textColor = Color.red;
            EditorGUILayout.LabelField("Just NOT Lateral Collision", booleanText);

            EditorGUILayout.EndVertical();
        }

        EditorGUILayout.Space();

        EditorGUI.indentLevel = 1;
        drawDefaultInspector = EditorGUILayout.Foldout(drawDefaultInspector, "Default Inspector", true, EditorStyles.toolbarDropDown);
        
        if(drawDefaultInspector)
        {
            EditorGUI.indentLevel = 0;
            EditorGUILayout.Space();
        } 
    }
}
