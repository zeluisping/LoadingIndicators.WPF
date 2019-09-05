using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LoadingIndicators.WPF.Utilities
{
    internal static class VisualStateUtilities
    {
        public static IEnumerable<VisualStateGroup> GetActiveVisualStateGroups(this FrameworkElement element) =>
            element.GetVisualStateGroupsByName(IndicatorVisualStateGroupNames.ActiveStates.Name);

        public static IEnumerable<VisualState> GetActiveVisualStates(this FrameworkElement element) => element
            .GetActiveVisualStateGroups().GetAllVisualStatesByName(IndicatorVisualStateNames.ActiveState.Name);

        public static IEnumerable<VisualState> GetAllVisualStatesByName(
            this IEnumerable<VisualStateGroup> visualStateGroups, string name) =>
            visualStateGroups.SelectMany(vsg => vsg.GetVisualStatesByName(name));

        public static IEnumerable<VisualState> GetVisualStatesByName(this VisualStateGroup visualStateGroup,
            string name)
        {
            if (visualStateGroup is null)
            {
                return null;
            }

            var visualStates = visualStateGroup.GetVisualStates();

            return string.IsNullOrWhiteSpace(name) ? visualStates : visualStates?.Where(vs => vs.Name == name);
        }

        public static IEnumerable<VisualStateGroup> GetVisualStateGroupsByName(this FrameworkElement element,
            string name)
        {
            var groups = VisualStateManager.GetVisualStateGroups(element);

            if (groups is null)
            {
                return null;
            }

            IEnumerable<VisualStateGroup> castedVisualStateGroups;

            try
            {
                castedVisualStateGroups = groups.Cast<VisualStateGroup>().ToArray();
                if (!castedVisualStateGroups.Any())
                {
                    return null;
                }
            }
            catch (InvalidCastException)
            {
                return null;
            }

            return string.IsNullOrWhiteSpace(name)
                ? castedVisualStateGroups
                : castedVisualStateGroups.Where(vsg => vsg.Name == name);
        }

        public static IEnumerable<VisualState> GetVisualStates(this VisualStateGroup visualStateGroup)
        {
            if (visualStateGroup is null)
            {
                return null;
            }

            return visualStateGroup.States.Count == 0 ? null : visualStateGroup.States.Cast<VisualState>();
        }
    }
}