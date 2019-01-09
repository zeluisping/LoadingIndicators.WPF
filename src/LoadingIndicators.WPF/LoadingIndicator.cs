using System;
using System.Windows;
using System.Windows.Controls;
using LoadingIndicators.WPF.Utilities;

namespace LoadingIndicators.WPF
{
    /// <inheritdoc />
    /// <summary>
    ///     A control featuring a range of loading indicating animations.
    /// </summary>
    [TemplatePart(Name = TemplateBorderName, Type = typeof(Border))]
    public class LoadingIndicator : Control
    {
        internal const string TemplateBorderName = "PART_Border";

        /// <summary>
        ///     Identifies the <see cref="LoadingIndicators.WPF.LoadingIndicator.SpeedRatio" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty SpeedRatioProperty =
            DependencyProperty.Register("SpeedRatio", typeof(double), typeof(LoadingIndicator), new PropertyMetadata(1d,
                OnSpeedRatioChanged));

        /// <summary>
        ///     Identifies the <see cref="LoadingIndicators.WPF.LoadingIndicator.IsActive" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(LoadingIndicator), new PropertyMetadata(true,
                OnIsActiveChanged));

        public static readonly DependencyProperty ModeProperty = DependencyProperty.Register(
            "Mode", typeof(LoadingIndicatorMode), typeof(LoadingIndicator),
            new PropertyMetadata(default(LoadingIndicatorMode)));

        // ReSharper disable once InconsistentNaming
        protected Border PART_Border;

        static LoadingIndicator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LoadingIndicator),
                new FrameworkPropertyMetadata(typeof(LoadingIndicator)));
        }

        public LoadingIndicatorMode Mode
        {
            get => (LoadingIndicatorMode) GetValue(ModeProperty);
            set => SetValue(ModeProperty, value);
        }

        /// <summary>
        ///     Get/set the speed ratio of the animation.
        /// </summary>
        public double SpeedRatio
        {
            get => (double) GetValue(SpeedRatioProperty);
            set => SetValue(SpeedRatioProperty, value);
        }

        /// <summary>
        ///     Get/set whether the loading indicator is active.
        /// </summary>
        public bool IsActive
        {
            get => (bool) GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }

        private static void OnSpeedRatioChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var li = (LoadingIndicator) o;

            if (li.PART_Border == null || li.IsActive == false)
            {
                return;
            }

            SetStoryBoardSpeedRatio(li.PART_Border, (double) e.NewValue);
        }

        private static void OnIsActiveChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var li = (LoadingIndicator) o;

            if (li.PART_Border == null)
            {
                return;
            }

            if ((bool) e.NewValue == false)
            {
                VisualStateManager.GoToElementState(li.PART_Border, IndicatorVisualStateNames.InactiveState.Name,
                    false);
                li.PART_Border.SetCurrentValue(VisibilityProperty, Visibility.Collapsed);
            }
            else
            {
                VisualStateManager.GoToElementState(li.PART_Border, IndicatorVisualStateNames.ActiveState.Name, false);

                li.PART_Border.SetCurrentValue(VisibilityProperty, Visibility.Visible);

                SetStoryBoardSpeedRatio(li.PART_Border, li.SpeedRatio);
            }
        }

        private static void SetStoryBoardSpeedRatio(FrameworkElement element, double speedRatio)
        {
            var activeStates = element.GetActiveVisualStates();
            foreach (var activeState in activeStates) activeState.Storyboard.SetSpeedRatio(element, speedRatio);
        }

        /// <inheritdoc />
        /// <summary>
        ///     When overridden in a derived class, is invoked whenever application code
        ///     or internal processes call System.Windows.FrameworkElement.ApplyTemplate().
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Border = (Border) GetTemplateChild(TemplateBorderName);

            if (PART_Border == null)
            {
                return;
            }

            VisualStateManager.GoToElementState(PART_Border,
                IsActive
                    ? IndicatorVisualStateNames.ActiveState.Name
                    : IndicatorVisualStateNames.InactiveState.Name, false);

            SetStoryBoardSpeedRatio(PART_Border, SpeedRatio);

            PART_Border.SetCurrentValue(VisibilityProperty, IsActive ? Visibility.Visible : Visibility.Collapsed);
        }
    }
}