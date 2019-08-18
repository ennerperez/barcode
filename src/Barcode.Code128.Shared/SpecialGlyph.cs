using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Barcode
{
    /// <summary>
    /// Defines special control codes which have no character representation.
    /// </summary>
    public enum Code128SpecialGlyph
    {
        /// <summary>
        /// Not special
        /// </summary>
        None,

        /// <summary>
        /// Start of character set A
        /// </summary>
        StartSetA,

        /// <summary>
        /// Start of character set B
        /// </summary>
        StartSetB,

        /// <summary>
        /// Start of character set C
        /// </summary>
        StartSetC,

        /// <summary>
        /// Switch to character set A
        /// </summary>
        SwitchToA,

        /// <summary>
        /// Switch to character set B
        /// </summary>
        SwitchToB,

        /// <summary>
        /// Switch to character set C
        /// </summary>
        SwitchToC,

        /// <summary>
        /// Function 1
        /// </summary>
        Func1,

        /// <summary>
        /// Function 2
        /// </summary>
        Func2,

        /// <summary>
        /// Function 3
        /// </summary>
        Func3,

        /// <summary>
        /// Function 4
        /// </summary>
        Func4,

        /// <summary>
        /// Shift
        /// </summary>
        Shift,

        /// <summary>
        /// Stop
        /// </summary>
        Stop,

        /// <summary>
        /// Terminal
        /// </summary>
        Terminal
    }
}