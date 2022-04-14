using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using DownloadImageFromWeb;

namespace DownloadImageFromWeb
{
    public class Image
    {
        public string URL { get; private set; }
        public string Filename { get; private set; }

        public void DownloadNewImage()
        {
            GetUrlFromUser();
            NewImage();
        }

        private void GetUrlFromUser()
        {
            Console.WriteLine("Enter url: ");
            this.URL = Console.ReadLine();
            Console.WriteLine("Enter filename(without filetype): ");
            this.Filename = Console.ReadLine();
        }

        private void NewImage()
        {
            try
            {
                SaveImage();
            }
            catch (System.Net.WebException)
            {
                Console.WriteLine("Invalid url.");
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                Console.WriteLine("Invalid url.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SaveImage()
        {
            Bitmap image = LoadImageFromWeb(@URL);
            image.Save($@"C:\Users\Public\Pictures\{Filename}.png", ImageFormat.Png);
            Console.WriteLine($@"Image saved at C:\Users\Public\Pictures\{Filename}.png");
        }

        static Bitmap LoadImageFromWeb(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            Bitmap image = new Bitmap(stream);

            stream.Flush();
            stream.Close();
            client.Dispose();

            return image;
        }
    }

}
