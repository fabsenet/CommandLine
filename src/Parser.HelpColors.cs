using CommandLine.Analysis;
using CommandLine.Attributes;
using CommandLine.Attributes.Advanced;
using OutputColorizer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using CommandLine.Colors;

namespace CommandLine
{
    public static partial class Parser
    {
        public static class Colors
        {
            private static IColors s_helpColors;
            private static object s_lockObj = new object();


            public static IColors Get(ConsoleColor backgroundColor = (ConsoleColor)(-1))
            {
                if (s_helpColors != null)
                {
                    return s_helpColors;
                }

                // if the color is not specified, default to the current console's background color.
                if (backgroundColor == (ConsoleColor)(-1))
                {
                    backgroundColor = Console.BackgroundColor;
                }

                // Get the color scheme.
                lock (s_lockObj)
                {
                    if (s_helpColors == null)
                    {
                        s_helpColors = GetDefault(backgroundColor);
                    }
                }

                return s_helpColors;
            }

            private static IColors GetDefault(ConsoleColor backgroundColor)
            {
                switch (backgroundColor)
                {
                    case ConsoleColor.Black:
                        return new DarkBackgroundColors();
                    case ConsoleColor.Blue:
                        return new DarkBackgroundColors();
                    case ConsoleColor.Cyan:
                        return new CyanBackgroundColors();
                    case ConsoleColor.DarkBlue:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkCyan:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkGray:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkGreen:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkMagenta:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkRed:
                        return new DarkBackgroundColors();
                    case ConsoleColor.DarkYellow:
                        return new DarkYellowBackgroundColors();
                    case ConsoleColor.Gray:
                        return new GrayBackgroundColors();
                    case ConsoleColor.Green:
                        return new GreenBackgroundColors();
                    case ConsoleColor.Magenta:
                        return new DarkBackgroundColors();
                    case ConsoleColor.Red:
                        return new RedBackgroundColors();
                    case ConsoleColor.White:
                        return new LightBackgroundColors();
                    case ConsoleColor.Yellow:
                        return new LightBackgroundColors();
                    default:
                        return new DarkBackgroundColors();
                }
            }

            public static void Set(IColors colors)
            {
                lock (s_lockObj)
                {
                    s_helpColors = colors;
                }
            }
        }
    }
}