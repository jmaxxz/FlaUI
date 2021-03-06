﻿using FlaUI.Core;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;
using FlaUI.UIA3.Identifiers;
using UIA = interop.UIAutomationCore;

namespace FlaUI.UIA3.Patterns
{
    public class Transform2Pattern : Transform2PatternBase<UIA.IUIAutomationTransformPattern2>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_TransformPattern2Id, "Transform2", AutomationObjectIds.IsTransformPattern2AvailableProperty);
        public static readonly PropertyId CanZoomProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2CanZoomPropertyId, "CanZoom");
        public static readonly PropertyId ZoomLevelProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomLevelPropertyId, "ZoomLevel");
        public static readonly PropertyId ZoomMaximumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMaximumPropertyId, "ZoomMaximum");
        public static readonly PropertyId ZoomMinimumProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_Transform2ZoomMinimumPropertyId, "ZoomMinimum");

        private readonly TransformPattern _transformPattern;

        public Transform2Pattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationTransformPattern2 nativePattern) : base(basicAutomationElement, nativePattern)
        {
            _transformPattern = new TransformPattern(basicAutomationElement, nativePattern);
        }
        
        public override void Zoom(double zoom)
        {
            ComCallWrapper.Call(() => NativePattern.Zoom(zoom));
        }

        public override void ZoomByUnit(ZoomUnit zoomUnit)
        {
            ComCallWrapper.Call(() => NativePattern.ZoomByUnit((UIA.ZoomUnit)zoomUnit));
        }

        public override void Move(double x, double y)
        {
            _transformPattern.Move(x,y);
        }

        public override void Resize(double width, double height)
        {
            _transformPattern.Resize(width, height);
        }

        public override void Rotate(double degrees)
        {
            _transformPattern.Rotate(degrees);
        }
    }

    public class Transform2PatternProperties : TransformPatternProperties, ITransform2PatternProperties
    {
        public PropertyId CanZoom => Transform2Pattern.CanZoomProperty;
        public PropertyId ZoomLevel => Transform2Pattern.ZoomLevelProperty;
        public PropertyId ZoomMaximum => Transform2Pattern.ZoomMaximumProperty;
        public PropertyId ZoomMinimum => Transform2Pattern.ZoomMinimumProperty;
    }
}
