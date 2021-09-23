using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Immedia.API.Model;
using DatabaseRepo;
using System.Data.SqlClient;

namespace Immedia.API.Endpoint
{
    public class Location
    {
        public AllCriteria Criteria { get; set; }
        public string location { get; set; }
        public string ParentFolder { get; set; }
        public string FileName { get; set; }
        public List<DirectoryInfo> Directories { get; set; }
        FileInfo[] files;

        public void Initialise()
        {
            location = @"\Images";
            var dr = new DirectoryInfo(location);
            LoadLocation(dr, Criteria.Search);
        }

        public void LoadLocation(DirectoryInfo dr, string search)
        {
            var allFiles = new List<FileInfo>();
            Directories = new List<DirectoryInfo>();
            files = null;
            try
            {
                files = dr.GetFiles(search);
            }
            catch (Exception ex)
            {
                var message = ex.StackTrace;
            }

            if (files != null)
            {
                try
                {
                    foreach (FileInfo item in files)
                    {
                        allFiles.Add(item);
                        FileName = item.DirectoryName + "\\" + item.Name;
                        ParentFolder = FileName;
                    }
                    var dir = dr.GetDirectories();

                    foreach (DirectoryInfo item in dir)
                    {
                        Directories.Add(item);
                        LoadLocation(item, search);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    var message = ex.StackTrace;
                }
            }

            if (Directories != null)
            {
                SaveLocation();
            }
        }

        public void SaveLocation()
        {
            var dc = new DataContext();
            SqlConnection con = new SqlConnection(dc.ConnectionString);

            foreach (var item in Directories)
            {
                // I handle all the Duplication in SQL 
                SqlCommand cmd = new SqlCommand("Location_Upsert", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Location", item.FullName);
                dc.OpenConnection();

                cmd.ExecuteNonQuery();
                dc.CloseConnection();
            }
        }

    }
}
