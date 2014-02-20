using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace LoadingIndicators.WPF
{
    [TemplatePart(Name = "Border", Type = typeof(Border))]
    public class LoadingIndicator : Control
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Border border = (Border) GetTemplateChild("PART_Border");
            VisualStateManager.GoToElementState(border, "Active", false);
        }

        // Constructors
        public LoadingIndicator()
        {
        }
    }
}
