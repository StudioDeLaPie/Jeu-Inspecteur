using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace TheraBytes.BetterUi
{
    [AddComponentMenu("Better UI/Obsolete/Better Horizontal Layout Group", 30)]
    public class BetterHorizontalLayoutGroup 
        : HorizontalLayoutGroup, IBetterHorizontalOrVerticalLayoutGroup, IResolutionDependency
    {
        public MarginSizeModifier PaddingSizer { get { return paddingSizerFallback; } }
        public FloatSizeModifier SpacingSizer { get { return spacingSizerFallback; } }

        [FormerlySerializedAs("paddingSizer")]
        [SerializeField]
        MarginSizeModifier paddingSizerFallback =
            new MarginSizeModifier(new Margin(), new Margin(), new Margin(1000, 1000, 1000, 1000));
        
        [FormerlySerializedAs("spacingSizer")]
        [SerializeField]
        FloatSizeModifier spacingSizerFallback =
            new FloatSizeModifier(0, 0, 300);
        
        protected override void OnEnable()
        {
            base.OnEnable();
            CalculateCellSize();
        }

        public void OnResolutionChanged()
        {
            CalculateCellSize();
        }

        public void CalculateCellSize()
        {
            Rect r = this.rectTransform.rect;
            if (r.width == float.NaN || r.height == float.NaN)
                return;

            base.m_Spacing = SpacingSizer.CalculateSize();

            Margin pad = PaddingSizer.CalculateSize();
            pad.CopyValuesTo(base.m_Padding);
            
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            CalculateCellSize();
            base.OnValidate();
        }
#endif
    }
}
