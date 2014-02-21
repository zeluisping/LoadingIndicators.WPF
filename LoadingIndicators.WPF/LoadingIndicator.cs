using System;
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
            DependencyProperty.Register("SpeedRatio", typeof(double), typeof(LoadingIndicator), new PropertyMetadata(1));

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

            Border border = (Border) GetTemplateChild("PART_Border");
            VisualStateManager.GoToElementState(border, "Active", false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingIndicators.WPF.LoadingIndicator"/> class.
        /// </summary>
        public LoadingIndicator()
        {
        }
    }
}
