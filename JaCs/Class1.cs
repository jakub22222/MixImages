/// <summary>
/// Miksowanie obraz�w
/// Alorytm pozwala na po��czenie dw�ch obraz�w o takiej samej rozdzielczo�ci i wybranie wsp�czynnika mieszania
/// 2022/2023 Sem.5 Jakub Ho� gr.2
/// v1.0
/// </summary>

namespace JaCs
{
    public class Class1
    {
        public static int mixCs(int pixelA, int pixelB, int u)
        {
            int rA = (pixelA & 0x00FF0000) >> 16;
            int gA = (pixelA & 0x0000FF00) >> 8;
            int bA = (pixelA & 0x000000FF);

            int rB = (pixelB & 0x00FF0000) >> 16;
            int gB = (pixelB & 0x0000FF00) >> 8;
            int bB = (pixelB & 0x000000FF);

            int r = (rA * u + rB * (256 - u)) / 256;
            int g = (gA * u + gB * (256 - u)) / 256;
            int b = (bA * u + bB * (256 - u)) / 256;

            int result = r;
            result = result << 8;
            result += g;
            result = result << 8;
            result += b;
            return result;
        }
    }
}
