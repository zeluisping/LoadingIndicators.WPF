// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiStyleExtension.cs" company="Procure Software Development">
//     Copyright (c) 2019 Procure Software Development
// </copyright>
// <author></author>
// <summary>
//     
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Markup;

namespace LoadingIndicators.WPF.Styles
{
    [MarkupExtensionReturnType(typeof(Style))]
    public class MultiStyleExtension : MarkupExtension
    {
        private readonly string[] _resourceKeys;

        public MultiStyleExtension(string inputResourceKeys)
        {
            if (string.IsNullOrWhiteSpace(inputResourceKeys))
            {
                throw new ArgumentNullException(nameof(inputResourceKeys));
            }

            _resourceKeys = inputResourceKeys.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (_resourceKeys.Length == 0)
            {
                throw new ArgumentException();
            }
        }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var resultStyle = new Style();

            foreach (var resourceKey in _resourceKeys)
            {
                var key = (object) resourceKey;
                if (resourceKey == ".")
                {
                    var service = (IProvideValueTarget) serviceProvider.GetService(typeof(IProvideValueTarget));
                    key = service.TargetObject.GetType();
                }

                var currentStyle = new StaticResourceExtension(key).ProvideValue(serviceProvider) as Style;

                if (currentStyle == null)
                {
                    throw new ArgumentException();
                }

                resultStyle.Merge(currentStyle);
            }

            return resultStyle;
        }
    }

    internal static class StyleExtensions
    {
        public static void Merge(this Style style1, Style style2)
        {
            if (style1 == null)
            {
                throw new ArgumentNullException(nameof(style1));
            }

            if (style2 == null)
            {
                throw new ArgumentNullException(nameof(style2));
            }

            if (style1.TargetType.IsAssignableFrom(style2.TargetType))
            {
                style1.TargetType = style2.TargetType;
            }

            if (style2.BasedOn != null)
            {
                Merge(style1, style2.BasedOn);
            }

            foreach (var currentSetter in style2.Setters)
                style1.Setters.Add(currentSetter);
            foreach (var currentTrigger in style2.Triggers)
                style1.Triggers.Add(currentTrigger);

            // This code is only needed when using DynamicResources.
            foreach (var key in style2.Resources.Keys)
                style1.Resources[key] = style2.Resources[key];
        }
    }
}