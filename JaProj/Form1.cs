/// <summary>
/// Miksowanie obrazów
/// Alorytm pozwala na połączenie dwóch obrazów o takiej samej rozdzielczości i wybranie współczynnika mieszania
/// 2022/2023 Sem.5 Jakub Hoś gr.2
/// v1.0
/// </summary>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JaCs.Class1;


namespace JaProj
{
    /// <summary>
    /// Main method of UI
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Bitmap object holds first users image
        /// </summary>
        Bitmap imageA = new Bitmap(1, 1);
        /// <summary>
        /// Bitmap object holds second users image
        /// </summary>
        Bitmap imageB = new Bitmap(1, 1);
        /// <summary>
        /// Default u factor as float
        /// </summary>
        float userU = 0.5f;
        /// <summary>
        /// Number of threads used by mixing algorithm
        /// </summary>
        int threads = Environment.ProcessorCount;
        /// <summary>
        /// Pixel values of first image as int(0,R,G,B)
        /// </summary>
        int[] pixelValuesA;
        /// <summary>
        /// Pixel values of second image as int(0,R,G,B)
        /// </summary>
        int[] pixelValuesB;
        /// <summary>
        /// Pixel values of result image as int(0,R,G,B)
        /// </summary>
        int[] resultPixels;
        /// <summary>
        /// Number of images pixels
        /// </summary>
        int pixels;
        /// <summary>
        /// u factor as int
        /// </summary>
        int u;
        /// <summary>
        /// Number of packages(image is devided into parts for threads)
        /// </summary>
        const int numberOfPixelPackages=64;
        /// <summary>
        /// Class constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            radioCpp.Checked = true;
            runButton.Enabled = false;
            numberOfThreadsLabel.Text = threads.ToString();
            hScrollBar1.Value = threads;
        }

        /// <summary>
        /// Shows users image in UI
        /// Fills pixel array
        /// Checks if algorithm is ready to work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlButtonA_Click(object sender, EventArgs e)
        {
            showImage(urlButtonA, deleteA, pictureBoxA, 'A');

            pixelValuesA = bitmapToIntArray(imageA);

            checkIfIsReadyToWork();
        }
        /// <summary>
        /// Shows users image in UI
        /// </summary>
        /// <param name="selectButton">Button which was used by user</param>
        /// <param name="deleteButton">Delete button which should be shown</param>
        /// <param name="box">Picture box where image will be shown</param>
        /// <param name="i">Char informs which Bitmap should be assigned</param>
        private void showImage(Button selectButton, Button deleteButton, PictureBox box, char i)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (i == 'A')
                    {
                        imageA = new Bitmap(fileDialog.FileName);
                        box.Image = imageA;
                    }
                    else if (i == 'B')
                    {
                        imageB = new Bitmap(fileDialog.FileName);
                        box.Image = imageB;
                    }
                    deleteButton.Visible = true;
                    box.Visible = true;
                    selectButton.Visible = false;

                }
                catch (Exception exception)
                {
                    errorProvider1.SetError(selectButton, exception.Message);
                }
            }
        }
        /// <summary>
        /// Checks if algorithm is ready to work - all informations are provided
        /// </summary>
        private void checkIfIsReadyToWork()
        {
            if (imageA.Width == imageB.Width && imageA.Height == imageB.Height)
            {
                runButton.Enabled = true;
            }
            else if (imageA.Width != 1 && imageA.Height != 1 && imageB.Width != 1 && imageB.Height != 1)
            {
                errLabel.Visible = true;
            }
        }
        /// <summary>
        /// Translate Bitmap object to int array as (0,R,G,B)
        /// </summary>
        /// <param name="bmp">Bitmap object which will be translated</param>
        /// <returns></returns>
        private int[] bitmapToIntArray(Bitmap bmp)
        {

            int[] rgbValuesInt = new int[bmp.Width * bmp.Height];

            int counter = 0;
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color color = bmp.GetPixel(x, y);

                    int pixel = color.R;
                    pixel = pixel << 8;
                    pixel += color.G;
                    pixel = pixel << 8;
                    pixel += color.B;

                    rgbValuesInt[counter] = pixel;
                    counter++;
                }
            return rgbValuesInt;
        }

        
        private void label4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Gets number of threads choosen on slider
        /// Sets label text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            threads = hScrollBar1.Value;
            numberOfThreadsLabel.Text = threads.ToString();
        }

        /// <summary>
        /// Gets u factor choosen on slider
        /// Sets label text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            userU = hScrollBar2.Value / 100f;
            uLabel.Text = userU.ToString();
        }
        /// <summary>
        /// Shows users image in UI
        /// Fills pixel array
        /// Checks if algorithm is ready to work
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlButtonB_Click(object sender, EventArgs e)
        {
            showImage(urlButtonB, deleteB, pictureBoxB, 'B');

            pixelValuesB = bitmapToIntArray(imageB);

            checkIfIsReadyToWork();

        }
        /// <summary>
        /// Removes first image from screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteA_Click(object sender, EventArgs e)
        {
            removeImage('A');

        }
        /// <summary>
        /// Removes second image from screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteB_Click(object sender, EventArgs e)
        {
            removeImage('B');

        }
        /// <summary>
        /// Sets visibility of UI elements, after image was deleted
        /// Assign new Bitmap object to one of load Bitmaps
        /// </summary>
        /// <param name="i">Char informs which Bitmap should be assigned</param>
        private void removeImage(char i)
        {
            errLabel.Visible = false;
            runButton.Enabled = false;
            if (i == 'A')
            {
                imageA = new Bitmap(1, 1);
                pictureBoxA.Visible = false;
                urlButtonA.Visible = true;
                deleteA.Visible = false;
            }
            else
            {
                imageB = new Bitmap(1, 1);
                pictureBoxB.Visible = false;
                urlButtonB.Visible = true;
                deleteB.Visible = false;
            }
        }
        /// <summary>
        /// Tests time of executing the algorithm
        /// Uses 6 images - images should be placed in "sampleImages" directory in same path as .exe file
        /// Names of images:
        /// - small1.bmp, small2.bmp
        /// - medium1.bmp, medium2.bmp
        /// - big1.bmp, big1.bmp
        /// Results are saved in .txt file
        /// </summary>
        private void test()
        {
            int[] arrayA;
            int[] arrayB;
            const int numberOfTests = 100;
            List<string> strings=new List<string>();
            
            //small image
            try
            {
                arrayA = bitmapToIntArray(new Bitmap(@"sampleImages\small1.bmp"));
                arrayB = bitmapToIntArray(new Bitmap(@"sampleImages\small2.bmp"));
            }
            catch (Exception e)
            {
                strings.Add("Nie można załadować przykładowych obrazów");
                strings.Add(e.Message);
                File.WriteAllLinesAsync("TestResults.txt", strings.ToArray());
                return;
            }
            
            pixels = arrayA.Length;
            resultPixels = new int[pixels];
            int step = pixels / numberOfPixelPackages;
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixCs(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("C# small images "+ currentThreads.ToString()+" threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixAsm(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("Asm small images " + currentThreads.ToString() + " threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }

            //medium image
            try
            {
                arrayA = bitmapToIntArray(new Bitmap(@"sampleImages\medium1.bmp"));
                arrayB = bitmapToIntArray(new Bitmap(@"sampleImages\medium2.bmp"));
            }
            catch (Exception e)
            {
                strings.Add("Nie można załadować przykładowych obrazów");
                strings.Add(e.Message);
                File.WriteAllLinesAsync("TestResults.txt", strings.ToArray());
                return;
            }
            pixels = arrayA.Length;
            resultPixels = new int[pixels];
            step = pixels / numberOfPixelPackages;
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixCs(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("C# medium images " + currentThreads.ToString() + " threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixAsm(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("Asm medium images " + currentThreads.ToString() + " threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }

            //big image
            try
            {
                arrayA = bitmapToIntArray(new Bitmap(@"sampleImages\big1.bmp"));
                arrayB = bitmapToIntArray(new Bitmap(@"sampleImages\big2.bmp"));
            }
            catch (Exception e)
            {
                strings.Add("Nie można załadować przykładowych obrazów");
                strings.Add(e.Message);
                File.WriteAllLinesAsync("TestResults.txt", strings.ToArray());
                return;
            }
            pixels = arrayA.Length;
            resultPixels = new int[pixels];
            step = pixels / numberOfPixelPackages;
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixCs(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("C# big images " + currentThreads.ToString() + " threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }
            for (int t = 0; t <= 6; t++)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                int currentThreads = (int)Math.Pow(2.0, t);
                for (int i = 0; i < numberOfTests; ++i)
                {
                    int pixelCounter = 0;
                    Parallel.For(0, pixels / step, new ParallelOptions() { MaxDegreeOfParallelism = currentThreads }, x =>
                    {
                        int startPixel = Thread.VolatileRead(ref pixelCounter);
                        System.Threading.Interlocked.Add(ref pixelCounter, step);
                        for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                        {
                            resultPixels[currentPixel] = mixAsm(arrayA[currentPixel], arrayB[currentPixel], u);
                        }
                    });
                }
                stopwatch.Stop();
                long milis = stopwatch.ElapsedMilliseconds;
                strings.Add("Asm big images " + currentThreads.ToString() + " threads [ms]");
                strings.Add((milis / numberOfTests).ToString());
            }

            File.WriteAllLinesAsync("TestResults.txt", strings.ToArray());
        }
        /// <summary>
        /// Sets visibility of UI elemets
        /// Runs algorithm in fromm choosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runButton_Click(object sender, EventArgs e)
        {
            runButton.Visible = false;
            Bitmap resultBitmap = new Bitmap(imageA.Width, imageA.Height);

            pixels = imageA.Width * imageA.Height;
            resultPixels = new int[pixels];

            u = (int)(userU * 255);
            if (u == 0) u++;

            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Semaphore sem = new Semaphore(1,1);

            if (radioCpp.Checked == true)
            {
                int pixelCounter = 0;
                int step = pixels / numberOfPixelPackages;
                Parallel.For(0, numberOfPixelPackages, new ParallelOptions() { MaxDegreeOfParallelism = threads }, i =>
                {
                    sem.WaitOne();
                    int startPixel = pixelCounter;
                    pixelCounter += step;
                    sem.Release();
                    for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                    {
                        resultPixels[currentPixel] = mixCs(pixelValuesA[currentPixel], pixelValuesB[currentPixel], u);
                    }
                });

            }
            else
            {
                int pixelCounter = 0;
                int step = pixels / numberOfPixelPackages;
                
                Parallel.For(0, numberOfPixelPackages, new ParallelOptions() { MaxDegreeOfParallelism = threads }, i =>
                {
                    sem.WaitOne();
                    int startPixel = pixelCounter;
                    pixelCounter += step;
                    sem.Release();
                    for (int currentPixel = startPixel; currentPixel < step + startPixel; currentPixel++)
                    {
                        resultPixels[currentPixel] = mixAsm(pixelValuesA[currentPixel], pixelValuesB[currentPixel], u);
                    }
                });

            }
            stopwatch.Stop();
            long milis = stopwatch.ElapsedMilliseconds;
            timeLabel.Text = "Czas wykonania:" + milis+ " ms";
            int counter = 0;

            for (int x = 0; x < resultBitmap.Width; x++)
                for (int y = 0; y < resultBitmap.Height; y++)
                {
                    resultBitmap.SetPixel(x, y, Color.FromArgb(red: (resultPixels[counter] & 0x00FF0000) >> 16, green: (resultPixels[counter] & 0x0000FF00) >> 8, blue: (resultPixels[counter] & 0x000000FF)));
                    counter++;
                }

            
            timeLabel.Visible = true;
            pictureBox1.Image = resultBitmap;
            pictureBox1.Visible = true;
            deleteResult.Visible = true;
            resultBitmap.Save(@"result.bmp");
        }

        private void deleteResult_Click(object sender, EventArgs e)
        {
            deleteResult.Visible = false;
            runButton.Visible = true;
            pictureBox1.Visible = false;
            timeLabel.Visible = false;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            test();
        }

    }
}
