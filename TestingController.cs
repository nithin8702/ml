using RNDSystems.API.SQLHelper;
using RNDSystems.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace RNDSystems.API.Controllers
{
    public class TestingController : UnSecuredController
    {
        public HttpResponseMessage Get(int recID)
        {
            _logger.Debug("Testing Get Called");
            SqlDataReader reader = null;
            RNDTesting TM = null;
            try
            {
                CurrentUser user = ApiUser;
                TM = new RNDTesting();
                AdoHelper ado = new AdoHelper();

                TM.ddTestType = new List<SelectListItem>() { GetInitialSelectItem() };
                TM.ddLotID = new List<SelectListItem>() { GetInitialSelectItem() };
             //   TM.ddSubTestType = new List<SelectListItem>() { GetInitialSelectItem() };

                if (recID > 0)
                {
                    SqlParameter param1 = new SqlParameter("@TestingNo", recID);
                    using (reader = ado.ExecDataReaderProc("RNDTestingMaterial_ReadByTestingNo", "RND",new object[] { param1 }))
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                TM.TestingNo = Convert.ToInt32(reader["TestingNo"]);
                                TM.WorkStudyID = Convert.ToString(reader["WorkStudyID"]);
                                TM.LotID = Convert.ToString(reader["LotID"]);
                                TM.MillLotNo = Convert.ToInt32(reader["MillLotNo"]);
                                TM.SoNum = Convert.ToString(reader["SoNum"]);
                                TM.Hole = Convert.ToString(reader["Hole"]);
                                TM.PieceNo = Convert.ToString(reader["PieceNo"]);
                                TM.Alloy = Convert.ToString(reader["Alloy"]);
                                TM.Temper = Convert.ToString(reader["Temper"]);
                                TM.CustPart = Convert.ToString(reader["CustPart"]);
                                TM.UACPart = Convert.ToInt32(reader["UACPart"]);
                                TM.GageThickness = Convert.ToString(reader["GageThickness"]);
                                TM.Orientation = Convert.ToString(reader["Orientation"]);
                                TM.Location1 = Convert.ToString(reader["Location1"]);
                                TM.Location2 = Convert.ToString(reader["Location2"]);
                                TM.Location3 = Convert.ToString(reader["Location3"]);
                                TM.SpeciComment = Convert.ToString(reader["SpeciComment"]);
                                TM.TestType = Convert.ToString(reader["TestType"]);
                                TM.SubTestType = Convert.ToString(reader["SubTestType"]);
                                TM.Status = Convert.ToChar(reader["Status"]);
                                TM.Selected = Convert.ToChar(reader["Selected"]);
                                TM.EntryDate = (!string.IsNullOrEmpty(reader["EntryDate"].ToString())) ? Convert.ToDateTime(reader["EntryDate"]) : (DateTime?)null;
                                TM.EntryBy = Convert.ToString(reader["EntryBy"]);
                                TM.TestLab = Convert.ToString(reader["TestLab"]);
                                TM.Printed = Convert.ToChar(reader["Printed"]);
                                TM.Replica = Convert.ToString(reader["Replica"]);
                                TM.RCS = Convert.ToChar(reader["RCS"]);
                            }
                        }
                    }
                }

                using (reader = ado.ExecDataReaderProc("RNDTestType_READ", "RND"))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {                            
                            TM.ddTestType.Add(new SelectListItem
                            {
                                Value = Convert.ToString(reader["TestDesc"]),
                                Text = Convert.ToString(reader["TestDesc"]),
                                Selected = (TM.TestType == Convert.ToString(reader["TestDesc"])) ? true : false,
                            });
                        }
                    }
                }
                using (reader = ado.ExecDataReaderProc("RNDLotID_READ", "RND"))
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            TM.ddLotID.Add(new SelectListItem
                            {
                                Value = Convert.ToString(reader["RNDLotID"]),
                                Text = Convert.ToString(reader["RNDLotID"]),
                                Selected = (TM.LotID == Convert.ToString(reader["RNDLotID"])) ? true : false,
                            });
                        }
                    }
                }
                //using (reader = ado.ExecDataReaderProc("RNDSubTestType_READ", "RND"))
                //{
                //    if (reader.HasRows)
                //    {
                //        while (reader.Read())
                //        {
                //            TM.ddSubTestType.Add(new SelectListItem
                //            {
                //                Value = Convert.ToString(reader["SubTestType"]),
                //                Text = Convert.ToString(reader["SubTestType"]),
                //                Selected = (TM.SubTestType == Convert.ToString(reader["SubTestType"])) ? true : false,
                //            });
                //        }                           
                //    }
                //}
                return Serializer.ReturnContent(TM, this.Configuration.Services.GetContentNegotiator(), this.Configuration.Formatters, this.Request);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }

        /// <summary>
        /// Called from SaveTestingMaterial - page
        /// </summary>
        /// <param name="recID"></param>
        /// <param name="WorkStudyID"></param>
        /// <returns></returns>
        public HttpResponseMessage Get(int recID, string WorkStudyID)
        {
            _logger.Debug("Testing Get with WorkStudy Called");
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);

        }
        public HttpResponseMessage Post(RNDTesting TestingMaterial)
        {
            try
            {
                CurrentUser user = ApiUser;
                AdoHelper ado = new AdoHelper();
                SqlParameter param1 = new SqlParameter("WorkStudyID", TestingMaterial.WorkStudyID);
                SqlParameter param2 = new SqlParameter("LotID", TestingMaterial.LotID);
                SqlParameter param3 = new SqlParameter("MillLotNo", TestingMaterial.MillLotNo);
                SqlParameter param4 = new SqlParameter("SoNum", TestingMaterial.SoNum);
                SqlParameter param5 = new SqlParameter("Hole", TestingMaterial.Hole);
                SqlParameter param6 = new SqlParameter("PieceNo", TestingMaterial.PieceNo);
                SqlParameter param7 = new SqlParameter("Alloy", TestingMaterial.Alloy);
                SqlParameter param8 = new SqlParameter("Temper", TestingMaterial.Temper);
                SqlParameter param9 = new SqlParameter("CustPart", TestingMaterial.CustPart);
                SqlParameter param10 = new SqlParameter("UACPart", TestingMaterial.UACPart);
                SqlParameter param11 = new SqlParameter("GageThickness", TestingMaterial.GageThickness);
                SqlParameter param12 = new SqlParameter("Orientation", TestingMaterial.Orientation);
                SqlParameter param13 = new SqlParameter("Location1", TestingMaterial.Location1);
                SqlParameter param14 = new SqlParameter("Location2", TestingMaterial.Location2);
                SqlParameter param15 = new SqlParameter("Location3", TestingMaterial.Location3);
                SqlParameter param16 = new SqlParameter("SpeciComment", TestingMaterial.SpeciComment);
                SqlParameter param17 = new SqlParameter("TestType", TestingMaterial.TestType);
                SqlParameter param18 = new SqlParameter("SubTestType", TestingMaterial.SubTestType);
                SqlParameter param19 = new SqlParameter("Status", TestingMaterial.Status);
                SqlParameter param20 = new SqlParameter("Selected", TestingMaterial.Selected);
                SqlParameter param21 = new SqlParameter("EntryDate", TestingMaterial.EntryDate);
                SqlParameter param22 = new SqlParameter("EntryBy", TestingMaterial.EntryBy);
                SqlParameter param23 = new SqlParameter("TestLab", TestingMaterial.TestLab);
                SqlParameter param24 = new SqlParameter("Printed", TestingMaterial.Printed);

                if (TestingMaterial.TestingNo > 0)
                {
                    //SqlParameter param25 = new SqlParameter("TestingNo", TestingMaterial.TestingNo);
                    SqlParameter param25 = new SqlParameter("TestingNo", TestingMaterial.TestingNo);
                    ado.ExecScalarProc("RNDTestingMaterial_Update", "RND", new object[] { param1, param2, param3,
                        param4, param5, param6, param7, param8, param9, param10, param11, param12,
                        param13, param14, param15, param16, param17,param18, param19, param20,
                        param21, param22, param23, param24, param25});
                }
                else
                {
                    ado.ExecScalarProc("RNDTestingMaterial_Insert", "RND", new object[] { param1, param2, param3,
                        param4, param5, param6, param7, param8, param9, param10, param11, param12,
                        param13, param14, param15, param16, param17,param18, param19, param20,
                        param21, param22, param23, param24});
                }
            }  
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return Serializer.ReturnContent(HttpStatusCode.OK, this.Configuration.Services.GetContentNegotiator(), this.Configuration.Formatters, this.Request);
        }

        public HttpResponseMessage Delete(int id)
        {
            _logger.Debug("Testing Material Delete Called");
            try
            {
                CurrentUser user = ApiUser;
                AdoHelper ado = new AdoHelper();
                SqlParameter param1 = new SqlParameter("@RecId", id);
                ado.ExecScalarProc("RNDTesting_Delete", "RND", new object[] { param1 });
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            return Serializer.ReturnContent(HttpStatusCode.OK, this.Configuration.Services.GetContentNegotiator(), this.Configuration.Formatters, this.Request);
        }
    }
}