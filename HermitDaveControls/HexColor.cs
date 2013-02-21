﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI;

namespace HermitDaveControls
{
    public struct HexColor
    {
        // Regex: This pattern matches hex codes in these two formats:
    // #000000 (no alpha value) and #FF000000 (alpha value at front).
    const string HEX_PATTERN = @"^\#([a-fA-F0-9]{6}|[a-fA-F0-9]{8})$";

    const int LENGTH_WITH_ALPHA = 8;

    Color _color;

    public HexColor(string hexCode)
    {
        if (hexCode == null)
        {
            throw new ArgumentNullException("hexCode");
        }

        if (!Regex.IsMatch(hexCode, HEX_PATTERN))
        {
            throw new ArgumentException(
                "Format must be #000000 or #FF000000 (no extra whitespace)",
                "hexCode");
        }

        // shave off '#' symbol
        hexCode = hexCode.TrimStart('#');

        // if no alpha value specified, assume no transparency (0xFF)
        if (hexCode.Length != LENGTH_WITH_ALPHA)
            hexCode = String.Format("FF{0}", hexCode);

        _color = new Color();
        _color.A = byte.Parse(hexCode.Substring(0, 2), NumberStyles.AllowHexSpecifier);
        if (_color.A < 50)
            _color.A = 50;
        _color.R = byte.Parse(hexCode.Substring(2, 2), NumberStyles.AllowHexSpecifier);
        _color.G = byte.Parse(hexCode.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        _color.B = byte.Parse(hexCode.Substring(6, 2), NumberStyles.AllowHexSpecifier);
    }

    public byte A
    {
        get { return _color.A; }
        set { _color.A = value; }
    }

    public byte R
    {
        get { return _color.R; }
        set { _color.R = value; }
    }

    public byte G
    {
        get { return _color.G; }
        set { _color.G = value; }
    }

    public byte B
    {
        get { return _color.B; }
        set { _color.B = value; }
    }

    // Implicit cast from HexColor to Color
    public static implicit operator Color(HexColor hexColor)
    {
        return hexColor._color;
    }

    // Implicit cast from Color to HexColor
    public static implicit operator HexColor(Color color)
    {
        HexColor c = new HexColor();
        c._color = color;
        return c;
    }

    // Just like with Color, ToString() prints out the hex value of the
    // color in #ARGB format (example: #FF000000) by default.
    public override string ToString()
    {
        return ToString(true);
    }

    // I don't always need the alpha value, so I added an overload here
    // that lets me return the hex value in #RBG format (example: #000000).
    public string ToString(bool includeAlpha)
    {
        if (includeAlpha)
        {
            return _color.ToString();
        }
        else
        {
            return String.Format("#{0}{1}{2}",
                _color.R.ToString("x2"),
                _color.G.ToString("x2"),
                _color.B.ToString("x2"));
        }
    }
    }
}
