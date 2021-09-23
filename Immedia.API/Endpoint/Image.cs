using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using DatabaseRepo;
using System.Data.SqlClient;

namespace Immedia.API.Endpoint
{
    public class Image : Location
    {
        public string[] ImageItems { get; set; }
        public string ImageExtensions { get; set; }
        public List<string> ImageListItems { get; set; }
        public string ImageFileName { get; set; }

        public void InitialiseImage()
        {
            ImageExtensions = "jpg,jpeg";
            GetImageDestinationPath(ImageFileName);
        }

        public List<string> GetImageDestinationPath(string fileName)
        {
            var dr = new DirectoryInfo(fileName);
            ImageItems = ImageExtensions.Split(',');
            ImageListItems = new List<string>();

            foreach (var item in ImageItems)
            {
                if (!string.IsNullOrEmpty(item.Trim()))
                {
                    LoadLocation(dr, "*." + item.Trim());
                    // ImageListItems.Add = LoadLocation(dr, "*." + item.Trim());
                    SaveImage();
                }
            }
            return ImageListItems;
        }


        // Here we save image detail into a database
        public void SaveImage()
        {
            var dc = new DataContext();
            SqlConnection con = new SqlConnection(dc.ConnectionString);

            foreach (var item in ImageListItems)
            {
                SqlCommand cmd = new SqlCommand("Image_Upsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("ImageName", item.Trim());
                dc.OpenConnection();
                // We add createdDate on the stored proc 

                cmd.ExecuteNonQuery();
                dc.CloseConnection();
            }
        }
    }
}
