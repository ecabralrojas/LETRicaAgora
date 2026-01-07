using System.Text;

namespace LET.Agora.Libreria.Impresion.EscPos;

public static class PosExt
{
    public static void Enlarged(this BinaryWriter bw, string text)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)32);
        bw.Write(text);
        bw.Write(AsciiControlChars.Newline);
    }

    public static void Bold(this BinaryWriter bw, string text)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)27);
        bw.Write((byte)69);
        bw.Write(text); //Width,enlarged
        bw.Write(AsciiControlChars.Newline);
    }
    public static void High(this BinaryWriter bw, string text)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)16);
        bw.Write(text); //Width,enlarged
        bw.Write(AsciiControlChars.Newline);
    }

    public static void LargeText(this BinaryWriter bw, string text)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)48);
        bw.Write(text);
        bw.Write(AsciiControlChars.Newline);
    }

    public static void FeedLines(this BinaryWriter bw, int lines)
    {
        bw.Write(AsciiControlChars.Newline);
        if (lines > 0)
        {
            bw.Write(AsciiControlChars.Escape);
            bw.Write('d');
            bw.Write((byte)lines - 1);
        }
    }

    public static void Finish(this BinaryWriter bw)
    {
        bw.FeedLines(1);
        bw.JustifyText(1);
        bw.JustifyText(0);
        bw.FeedLines(3);
        bw.Write(AsciiControlChars.Newline);
    }

    public static void NormalFont(this BinaryWriter bw, string text, bool line = true)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)8);
        //bw.Write(" " + text);
        bw.Write(Encoding.ASCII.GetBytes(text));
        if (line)
            bw.Write(AsciiControlChars.Newline);
    }

    public static void PrintHeaderDashes(this BinaryWriter bw, string text)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write('a');
        bw.Write((byte)0);
        bw.Write(AsciiControlChars.Escape);
        bw.Write('!');
        bw.Write((byte)0);
        bw.Write("-".PadRight(31, '-'));
        bw.Write(AsciiControlChars.Newline);
        bw.JustifyText(1);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)8);
        bw.Write(Encoding.ASCII.GetBytes(text));
        bw.Write(AsciiControlChars.Newline);
        bw.Write("-".PadRight(31, '-'));
        bw.JustifyText(0);
        bw.Write(AsciiControlChars.Newline);

    }

    public static void PrintDashes(this BinaryWriter bw, int totalcolumn)
    {
        //bw.JustifyText(1);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)0);
        //bw.Write(Encoding.ASCII.GetBytes("-".PadRight(42, '-')));
        bw.Write(Encoding.ASCII.GetBytes("-".PadRight(totalcolumn, '-')));
        //bw.Write(Encoding.ASCII.GetBytes("-".PadRight(31, '-')));

        //bw.JustifyText(0);
        bw.Write(AsciiControlChars.Newline);
    }

    public static void PrintDoubleDashes(this BinaryWriter bw, int totalcolumn)
    {
        //bw.JustifyText(1);
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)33);
        bw.Write((byte)0);
        //bw.Write(Encoding.ASCII.GetBytes("-".PadRight(42, '-')));
        bw.Write(Encoding.ASCII.GetBytes("=".PadRight(totalcolumn, '=')));
        //bw.Write(Encoding.ASCII.GetBytes("-".PadRight(31, '-')));

        //bw.JustifyText(0);
        bw.Write(AsciiControlChars.Newline);
    }

    public static void JustifyText(this BinaryWriter bw, int justification)
    {
        bw.Write(AsciiControlChars.Escape);
        bw.Write((byte)97);
        if (justification == 0)
        {
            bw.Write((byte)0); //Left Justification
        }
        else if (justification == 1)
        {
            bw.Write((byte)1); //Centered Justification 
        }
        else if (justification == 2)
        {
            bw.Write((byte)2); //Right Justification
        }
        else if (justification == 3)
        {
            bw.Write((byte)3); //Full Justification
        }

    }
}
