using BusineesLogic.domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusineesLogic.repositories.Impl
{
    public class PromotionRepositoryImpl : PromotionRepository
    {
        private SqlConnection con;
        public PromotionRepositoryImpl()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["AdminBookingConnectionString"].ConnectionString);
        }
        public void save(domain.PromotionDTO entity)
        {
            throw new NotImplementedException();
        }

        public void update(domain.PromotionDTO entity)
        {
            throw new NotImplementedException();
        }

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public System.Data.DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public domain.PromotionDTO findByID(int id)
        {
            throw new NotImplementedException();
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

        public bool updatePromotion(PromotionDTO model)
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

        public bool deletePromotion(int id)
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
