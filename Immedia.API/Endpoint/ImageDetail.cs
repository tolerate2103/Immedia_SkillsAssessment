using Immedia.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using DatabaseRepo;

namespace Immedia.API.Endpoint
{
    public class ImageDetail
    {
        public List<ImageModel> ImageDetails { get; set; }
        public ImageModel ImageDetailItem { get; set; }

        public void LoadItems()
        {
            var dc = new DataContext();
            try
            {
                using (SqlConnection conn = new SqlConnection(dc.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"dbo.[Image_Items]", conn);

                    dc.OpenConnection();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {

                        while (dr.Read())
                        {
                            ImageDetailItem = new ImageModel();

                            ImageDetailItem.ImageId = Convert.ToInt32(dr["ImageId"]);
                            ImageDetailItem.ImageName = dr["ImageName"].ToString();
                            ImageDetailItem.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());

                            ImageDetails.Add(ImageDetailItem);
                        }
                    }
                    dr.Close();
                    dc.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                var message = ex.StackTrace;
            }
        }


        public void LoadImageDetail(int imageId)
        {
            var dc = new DataContext();
            try
            {
                using (SqlConnection conn = new SqlConnection(dc.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand(@"dbo.[Image_Item]", conn);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = imageId.ToString();
                    param.SqlDbType = System.Data.SqlDbType.Int;

                    cmd.Parameters.Add(param);

                    dc.OpenConnection();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            ImageDetailItem.ImageId = dr.GetInt32(0);
                            ImageDetailItem.ImageName = dr.GetString(1);
                            ImageDetailItem.CreatedDate = dr.GetDateTime(2);
                        }
                    }
                    dr.Close();
                    dc.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                var message = ex.StackTrace;
            }
        }
    }
}
