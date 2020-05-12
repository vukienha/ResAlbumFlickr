using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResAlbumFlickr
{
    class Program
    {
        static void Main(string[] args)
        {
            string root = @"G:\Flickr Data\";
            string albumMeta = root + "000albums.json";
            string outputFolder = root + @"_____output\";
            //
            DirectoryInfo diRoot = new DirectoryInfo(root);

            using (StreamReader r = new StreamReader(albumMeta))
            {
                string json = r.ReadToEnd();
                AlbumList albums = JsonConvert.DeserializeObject<AlbumList>(json);
                //
                foreach (var ab in albums.albums)
                {

                    if (ab.photos.Where(x => x != "0").Count() == 0)
                    {
                        continue;
                    }
                    //
                    Console.WriteLine(ab.title + " || " + ab.description + " ("+ ab.photos.Where(x => x != "0").Count() + "/" + ab.photo_count + ")");
                }

                Console.ReadLine();

            }

        }

        static void _Main2(string[] args)
        {
            string root = @"G:\Flickr Data\";
            string albumMeta = root + "000albums.json";
            string outputFolder = root + @"_____output\";
            //
            DirectoryInfo diRoot = new DirectoryInfo(root);

            using (StreamReader r = new StreamReader(albumMeta))
            {
                string json = r.ReadToEnd();
                AlbumList albums = JsonConvert.DeserializeObject<AlbumList>(json);
                //
                foreach (var ab in albums.albums)
                {
                    if (ab.photos.Where(x => x != "0").Count() == 0)
                    {
                        continue;
                    }
                    //
                    Console.WriteLine(ab.title + " : " + ab.photos.Where(x => x != "0").Count() + "/" + ab.photo_count);
                    //
                    // Determine whether the directory exists.
                    if (!Directory.Exists(outputFolder + ab.title))
                    {
                        Directory.CreateDirectory(outputFolder + ab.title);
                    }

                    //
                    foreach (string photoID in ab.photos)
                    {
                        if (photoID == "0")
                        {
                            continue;
                        }

                        Console.WriteLine("Photo ID : {0}", photoID);
                        // Only get files that contain "ID".
                        FileInfo[] fis = diRoot.GetFiles("*" + photoID + "*");
                        Console.WriteLine("The number of files is {0}.", fis.Length);
                        //Console.ReadLine();
                        foreach (var fi in fis)
                        {
                            fi.MoveTo(outputFolder + ab.title + @"\" + fi.Name);
                            Console.WriteLine("Moved: " + fi.FullName);
                        }
                        
                    }

                    Console.WriteLine();
                    Console.WriteLine("======");
                    Console.WriteLine();
                }

                Console.ReadLine();

            }

        }
    }
}
