using System;
using DownloadImageFromWeb;

namespace LoadImageFromWeb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string addImage = "y";
            while (addImage == "y" || addImage == "Y")
            {
                Image newImage = new Image();
                newImage.DownloadNewImage();

                Console.Write("Wanna save a new image (y/n): ");
                addImage = Console.ReadLine();
            }
            Console.ReadKey();
        }
    }
}