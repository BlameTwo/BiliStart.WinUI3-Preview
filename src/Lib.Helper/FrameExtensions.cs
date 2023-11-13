using Microsoft.UI.Xaml.Controls;
using System;

namespace Lib.Helper
{
    public static class FrameExtensions
    {
        public static object? GetPageViewModel(this Frame frame) =>
            frame?.Content?.GetType().GetProperty("ViewModel")?.GetValue(frame.Content!);

        public static Type? GetPageViewModelType(this Frame frame) =>
            frame?.Content?.GetType().GetProperty("ViewModel")?.GetType();
    }
}
