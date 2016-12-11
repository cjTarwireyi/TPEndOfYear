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
            try
            {
                con.Open();
                string updateQuery = "Update Promotion Set DiscountPercent= '" + model.promotionDetails.discountPercent + "',StartDate='" + model.promotionDetails.startDate + "',EndDate='" + model.promotionDetails.endDate + "',DateCreated='" + model.dateCreated + "' Where Id ='" + model.id + "'";
                SqlCommand cmd = new SqlCommand(updateQuery, con);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public PromotionDTO getLastReocrd()
        {
            try
            {
                if (con.State.ToString() == "Open")
                    con.Close();
                PromotionDTO promotion;
                PromotionDetailsDTO promotionDetails;
                con.Open();
                String selectTimeSheet = "SELECT TOP 1 * FROM  Promotion Order by Id DESC ";
                SqlCommand myComm = new SqlCommand(selectTimeSheet, con);
                SqlDataReader reader;
                reader = myComm.ExecuteReader();
                if (!reader.Read())
                {
                    promotion = null;
                }
                else
                {
                    promotionDetails = new PromotionDetailsDTO.PromotionDetailsBuilder()
                                            .buildDiscountPercent(reader.GetDecimal(1))
                                            .buildStartDate(reader.GetDateTime(2))
                                            .buildEndDate(reader.GetDateTime(3))
                                            .build();
                    promotion = new PromotionDTO.PromotionBuilder()
                                       .buildId(reader.GetInt32(0))
                                       .buildPromotionDetails(promotionDetails)   
                                       .buildDateCreated(reader.GetDateTime(4))                                       
                                       .build();

                }
                con.Close();
                return promotion;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                con.Open();
                string deleteQuery = "DELETE FROM Promotion WHERE  Id ='" + id + "'";
                SqlCommand cmd = new SqlCommand(deleteQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
