LoadingIndicators.WPF
====================
![Demo](./demo.gif)

LoadingIndicators.WPF is a collection of 8 animated loading indicators for WPF compatible with [MahApps.Metro](https://github.com/MahApps/MahApps.Metro).

## Styles
- Arcs
- Arcs Ring
- Double Bounce
- FlipPlane
- Pulse
- Ring
- Three Dots
- Wave

## Features
- Variable Animation Speed
- Easy activation/deactivation
- Easy change of theme using resources
- Out of the box [MahApps.Metro](https://github.com/MahApps/MahApps.Metro) compatibility

## Usage
- Include Namespace
```xml
<Window ...
        xmlns:li="http://github.com/zeluisping/loadingIndicators/xaml/controls">
```
- Add Loading indicator and select mode
```xml
<li:LoadingIndicator Grid.Column="0" Grid.Row="0" SpeedRatio="{Binding SpeedRatio}" IsActive="{Binding IsArcsActive}" Mode="Arcs" />
```

Note: Waves mode will be selected by default if left empty