using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LoadingIndicators.WPF
{
    /// <summary>
    /// A control featuring a range of loading indicating animations.
    /// </summary>
    [TemplatePart(Name = "Border", Type = typeof(Border))]
    public class LoadingIndicator : Control
    {
        /// <summary>
        /// Identifies the <see cref="LoadingIndicators.WPF.LoadingIndicator.SpeedRatio"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty SpeedRatioProperty =
            DependencyProperty.Register("SpeedRatio", typeof(double), typeof(LoadingIndicator), new PropertyMetadata(1d, (o, e) => {
                LoadingIndicator li = (LoadingIndicator) o;

                if (li.PART_Border != null) {
                    foreach (VisualStateGroup group in VisualStateManager.GetVisualStateGroups(li.PART_Border)) {
                        if (group.Name == "ActiveStates") {
                            foreach (VisualState state in group.States) {
                                if (state.Name == "Active") {
                                    state.Storyboard.SetSpeedRatio(li.PART_Border, (double) e.NewValue);
                                }
                            }
                        }
                    }
                }
            }));

        // Variables
        protected Border PART_Border;

        /// <summary>
        /// Get/set the speed ratio of the animation.
        /// </summary>
        public double SpeedRatio
        {
            get { return (double) GetValue(SpeedRatioProperty); }
            set { SetValue(SpeedRatioProperty, value); }
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code
        /// or internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Border = (Border) GetTemplateChild("PART_Border");

            if (PART_Border != null) {
                VisualStateManager.GoToElementState(PART_Border, "Active", false);
                foreach (VisualStateGroup group in VisualStateManager.GetVisualStateGroups(PART_Border)) {
                    if (group.Name == "ActiveStates") {
                        foreach (VisualState state in group.States) {
                            if (state.Name == "Active") {
                                state.Storyboard.SetSpeedRatio(PART_Border, this.SpeedRatio);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingIndicators.WPF.LoadingIndicator"/> class.
        /// </summary>
        public LoadingIndicator()
        {
        }
    }
}
