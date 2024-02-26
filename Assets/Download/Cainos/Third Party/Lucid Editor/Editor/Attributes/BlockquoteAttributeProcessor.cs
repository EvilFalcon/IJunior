using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(BlockquoteAttribute))]
    public class BlockquoteAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            BlockquoteAttribute blockquote = (BlockquoteAttribute)attribute;
            GUIStyle style = EditorStyles.label;
            style.wordWrap = true;
            
            LucidEditorGUILayout.Blockquote(blockquote.text);
        }
    }
}