using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusineesLogic.Interface;
using System.Data.SqlClient;
using System.Configuration;
using BusineesLogic.factories;
using System.Data;
using BusineesLogic.domain;


namespace BusineesLogic.services
{
    public class PromotionDAO:IPromotion
    {
        private SqlConnection con;
        public PromotionDAO()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }


        public PromotionDTO getTimeSheet(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool ifExis(string id)
        {
            throw new System.NotImplementedException();
        }

        public int getId(System.DateTime date)
        {
            throw new System.NotImplementedException();
        }

        public bool add(PromotionDTO model)
        {
            try
            {
                var Datetime = DateTime.Now;

                con.Open();
                string insertQuery = "INSERT INTO Promotion (DiscountPercent,StartDate,EndDate,DateCreated) VALUES ('" + model.promotionDetails.discountPercent + "','" + model.promotionDetails.startDate + "','" + model.promotionDetails.endDate + "','" + model.dateCreated + "')";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(PromotionDTO model)
        {
            throw new System.NotImplementedException();
        }

        public PromotionDTO getLastReocrd()
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
