using Download.Cainos.Third_Party.Lucid_Editor.Runtime.Attributes;
using UnityEngine;

namespace Download.Cainos.Third_Party.Lucid_Editor.Editor.Attributes
{
    [CustomAttributeProcessor(typeof(DisableInEditModeAttribute))]
    public class DisableInEditModeAttributeProcessor : PropertyProcessor
    {
        public override void OnBeforeDrawProperty()
        {
            DisableInEditModeAttribute disableInEditMode = (DisableInEditModeAttribute)attribute;
            property.isEditable = Application.isPlaying;
        }
    }
}