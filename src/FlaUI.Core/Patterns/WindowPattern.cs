﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Elements;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Tools;
using UIA = interop.UIAutomationCore;

namespace FlaUI.Core.Patterns
{
    public class WindowPattern : PatternBaseWithInformation<UIA.IUIAutomationWindowPattern, WindowPatternInformation>
    {
        public static readonly PatternId Pattern = PatternId.Register(UIA.UIA_PatternIds.UIA_WindowPatternId, "Window");
        public static readonly PropertyId CanMaximizeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowCanMaximizePropertyId, "CanMaximize");
        public static readonly PropertyId CanMinimizeProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowCanMinimizePropertyId, "CanMinimize");
        public static readonly PropertyId IsModalProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowIsModalPropertyId, "IsModal");
        public static readonly PropertyId IsTopmostProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowIsTopmostPropertyId, "IsTopmost");
        public static readonly PropertyId WindowInteractionStateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowWindowInteractionStatePropertyId, "WindowInteractionState");
        public static readonly PropertyId WindowVisualStateProperty = PropertyId.Register(UIA.UIA_PropertyIds.UIA_WindowWindowVisualStatePropertyId, "WindowVisualState");
        public static readonly EventId WindowClosedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Window_WindowClosedEventId, "WindowClosed");
        public static readonly EventId WindowOpenedEvent = EventId.Register(UIA.UIA_EventIds.UIA_Window_WindowOpenedEventId, "WindowOpened");

        internal WindowPattern(AutomationElement automationElement, UIA.IUIAutomationWindowPattern nativePattern)
            : base(automationElement, nativePattern, (element, cached) => new WindowPatternInformation(element, cached))
        {
        }

        public void Close()
        {
            ComCallWrapper.Call(() => NativePattern.Close());
        }

        public void SetWindowVisualState(WindowVisualState state)
        {
            ComCallWrapper.Call(() => NativePattern.SetWindowVisualState((interop.UIAutomationCore.WindowVisualState)state));
        }

        public int WaitForInputIdle(int milliseconds)
        {
            return ComCallWrapper.Call(() => NativePattern.WaitForInputIdle(milliseconds));
        }
    }

    public class WindowPatternInformation : InformationBase
    {
        public WindowPatternInformation(AutomationElement automationElement, bool cached)
            : base(automationElement, cached)
        {
        }

        public bool CanMaximize
        {
            get { return Get<bool>(WindowPattern.CanMaximizeProperty); }
        }

        public bool CanMinimize
        {
            get { return Get<bool>(WindowPattern.CanMinimizeProperty); }
        }

        public bool IsModal
        {
            get { return Get<bool>(WindowPattern.IsModalProperty); }
        }

        public bool IsTopmost
        {
            get { return Get<bool>(WindowPattern.IsTopmostProperty); }
        }

        public WindowInteractionState WindowInteractionState
        {
            get { return Get<WindowInteractionState>(WindowPattern.WindowInteractionStateProperty); }
        }

        public WindowVisualState WindowVisualState
        {
            get { return Get<WindowVisualState>(WindowPattern.WindowVisualStateProperty); }
        }
    }
}