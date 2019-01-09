// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoadingIndicatorMode.cs" company="Procure Software Development">
//     Copyright (c) 2019 Procure Software Development
// </copyright>
// <author></author>
// <summary>
//     
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace LoadingIndicators.WPF
{
    public enum LoadingIndicatorMode
    {
        [Description("LoadingIndicatorWaveStyle")]
        Wave,

        [Description("LoadingIndicatorArcsStyle")]
        Arcs,

        [Description("LoadingIndicatorArcsRingStyle")]
        ArcsRing,

        [Description("LoadingIndicatorDoubleBounceStyle")]
        DoubleBounce,

        [Description("LoadingIndicatorFlipPlaneStyle")]
        FlipPlane,

        [Description("LoadingIndicatorPulseStyle")]
        Pulse,

        [Description("LoadingIndicatorRingStyle")]
        Ring,

        [Description("LoadingIndicatorThreeDotsStyle")]
        ThreeDots
        
    }

    internal static class LoadingIndicatorModeUtility
    {
        public static string GetDescription(this LoadingIndicatorMode value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description;
        }
    }
}