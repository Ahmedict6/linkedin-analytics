using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BLL
{
    public class PdfData
    {
        DatabaseClass db = new DatabaseClass("PDFSProject");

        public DataTable getAllPdf(String supplier)
        {
            try
            {
                String Qury = "";
                if (!string.IsNullOrEmpty(supplier))
                    Qury = String.Format(" and  PdfFileId IN (select PdfFileNo from vwPDF where SupplierQA ='{0}'  )", supplier);
                string sql = string.Format("Select PdfFileId,[FileName],[UplodeTime] from PdfFile  where  PdfFileId IN (select distinct PdfFileNo from vwPDF) {0} order by UplodeTime desc", Qury);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetPdfDataById(int PdfFileNo)
        {
            try
            {
                string sql = "Select * from vwPDF where  PdfFileNo=  " + PdfFileNo;
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public void DeletePdfDataById(int PdfFileNo)
        {

            SqlTransaction trans;
            db.OpenConnection();
            trans = db.cn.BeginTransaction();
            try
            {
                string sql = "delete from PDFData where  PdfFileNo=  " + PdfFileNo;
                new SqlCommand(sql, db.cn, trans).ExecuteNonQuery();
                sql = "delete from PdfFile where  PdfFileId=  " + PdfFileNo;
                new SqlCommand(sql, db.cn, trans).ExecuteNonQuery();
                trans.Commit();
                db.CloseConnection();

            }
            catch (Exception ex)
            {
                trans.Rollback();
                db.CloseConnection();
            }
        }

        public DataTable GetPdfHCPCSAllSuplier()
        {
            try
            {
                string sql = string.Format("select top 50 SupplierQA, (	select top 1    [Supplier_Name]  FROM [dbo].[vwPDF] where SupplierQA = o.SupplierQA group by SupplierQA,Supplier_Name order by Count([Supplier_Name]) + LEN([Supplier_Name])  desc ) as Supplier_Name,Count(SupplierQA)   as HCPCS_Count FROM [dbo].[vwPDF] as o  group by SupplierQA  order by Count(SupplierQA) Desc");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }

        public DataTable GetPdfHCPCSColumnPerPDFById(int PdfFileNo)
        {
            try
            {
                string sql = string.Format("select (	select top 1    [Supplier_Name]  FROM [dbo].vwPDF where SupplierQA = o.SupplierQA group by SupplierQA,[Supplier_Name] order by Count([Supplier_Name]) + LEN([Supplier_Name])  desc )  as [Supplier_Name], Count(SupplierQA)as HCPCS_Count,o.SupplierQA FROM [dbo].vwPDF o where [PdfFileNo] = {0}  group by SupplierQA", PdfFileNo);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public int GetPdfHCPCSColumnPerPDFSublierName(String Supplier_Name, int PdfFileNo)
        {
            try
            {
                string sql = string.Format("select  count(SupplierQA)  as Supplier_Name_PerPDF FROM [dbo].vwPDF where SupplierQA = '{0}' and [PdfFileNo] = {1}  group by SupplierQA", Supplier_Name, PdfFileNo);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int GetPdfHCPCSColumnAllPDFSublierName(String Supplier_Name)
        {
            try
            {
                string sql = string.Format(" select  count(SupplierQA)  as Supplier_Name_PerPDF FROM [dbo].vwPDF where SupplierQA = '{0}'  group by SupplierQA", Supplier_Name);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int GetAllPdfCount()
        {
            try
            {
                string sql = string.Format("  select  count( distinct [PdfFileId])  as AllCount FROM [dbo].[vwPDF] ");
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetAllHCPCSCount()
        {
            try
            {
                string sql = string.Format("  select sum(AllCount) as allCount from (select HCPCS_Code ,  count(HCPCS_Code) as AllCount FROM [dbo].vwPDF group by HCPCS_Code ) a  ");
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public int GetAllPdfNewCount()
        {
            try
            {
                string sql = string.Format("  select  count([PdfFileId])  as AllCount FROM [dbo].[PdfFile] " +
               "   WHERE UplodeTime >= dateadd(day,datediff(day,1,GETDATE()),0)" +
                " AND UplodeTime < dateadd(day,datediff(day,0,GETDATE()),0)");
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetPdfHCPCSDuplicatedColumnPerPDFSublierName(string Supplier_Name, int pdfId)
        {
            try
            {
                string sql = string.Format("   select count([PdfFileNo]) as counter  from  vwDuplicateHcpcsCodes where [SupplierQA] like '%{0}%' and [PdfFileNo]={1}", Supplier_Name, pdfId);
                return double.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public List<String> GetPdfHCPCSDuplicatedColumnListPerPDFSublierName(string Supplier_Name, int pdfId)
        {
            try
            {
                string sql = string.Format("   select HCPCS_Code   from  vwDuplicateHcpcsCodes where [SupplierQA] like '%{0}%' and [PdfFileNo]={1}", Supplier_Name, pdfId);
                  List<String> lst = new List<string>();
                foreach (DataRow item in db.ExecuteQuery(sql).Rows)
                {
                    lst.Add(item["HCPCS_Code"].ToString());           
                }
                return lst;
            
            }
            catch (Exception ex)
            {
                return new List<string>(); ;
            }

        }
        public object GetPdfHCPCSDuplicatedColumnALLPDFSublierName(string Supplier_Name)
        {
            try
            {
                string sql = string.Format(" select count(PdfFileNo) as counter from  vwDuplicateHcpcsCodes where [SupplierQA] like '%{0}%' ", Supplier_Name);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public DataTable GetSuppliersReoprt()
        {
            try
            {
                string sql = string.Format("select  SupplierQA, (	select top 1    [Supplier_Name]  FROM [dbo].vwPDF where SupplierQA = o.SupplierQA group by SupplierQA,Supplier_Name order by Count([Supplier_Name]) + LEN([Supplier_Name])  desc ) as Supplier_Name,(select top 1    [Supplier_Phone_number]  FROM [dbo].vwPDF where SupplierQA = o.SupplierQA group by SupplierQA,[Supplier_Phone_number] order by Count([Supplier_Phone_number])   desc ) as [Supplier_Phone_number] FROM [dbo].vwPDF as o  group by SupplierQA  order by Count(SupplierQA) Desc");
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }


        public int GetAllPdfCountbyCountry(string country ,string Year)
        {
            try
            {
                   String Qury = "";
                bool Firest = true;
                if (country != "")
                {
                    if(Firest)
                    {
                        Qury += "where Country = '" + country + "'"; ;
                        Firest = false;
                    }
                    
                }


                if (Year != "")
                {
                    if(Firest)
                    {
                        Qury += "where Year = '" + Year + "'"; ;
                        Firest = false;
                    }
                    else
                    {
                        Qury += " and  Year = '" + Year + "'"; ;
                        Firest = false;
                         
                    }
                    
                }

                string sql = string.Format("  select  count(distinct [PdfFileId])  as AllCount FROM [dbo].[vwPDF] {0}", Qury);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public DataTable GetPdfHCPCSAllSuplierCountry(string country, String Year)
        {
            try
            {
                String Qury = "";
                bool Firest = true;
                if (country != "")
                {
                    if (Firest)
                    {
                        Qury += "where Country = '" + country + "'"; ;
                        Firest = false;
                    }

                }


                if (Year != "")
                {
                    if (Firest)
                    {
                        Qury += "where Year = '" + Year + "'"; ;
                        Firest = false;
                    }
                    else
                    {
                        Qury += " and  Year = '" + Year + "'"; ;
                        Firest = false;

                    }

                }
                string sql = string.Format("select top 50  SupplierQA, (	select top 1    [Supplier_Name]  FROM [dbo].[vwPDF] where SupplierQA = o.SupplierQA group by SupplierQA,Supplier_Name order by Count([Supplier_Name]) + LEN([Supplier_Name])  desc ) as Supplier_Name,Count(SupplierQA)   as HCPCS_Count FROM [dbo].[vwPDF] as o {0} group by SupplierQA  order by Count(SupplierQA) Desc", Qury);
                return db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                return new DataTable();
            }
        }
        public int GetPdfHCPCSColumnAllPDFSublierNameandCountry(String Supplier_Name, String country, String Year)
        {
            try
            {

                String Qury = "";

                if (country != "")
                {
                    Qury += " and Country = '" + country + "'"; 
                }


                if (Year != "")
                {
                    Qury += " and  Year = '" + Year + "'";
                }


                string sql = string.Format(" select  count(SupplierQA)  as Supplier_Name_PerPDF FROM [dbo].[vwPDF] where SupplierQA = '{0}' {1} group by SupplierQA", Supplier_Name, Qury);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetPdfHCPCSDuplicatedColumnALLPDFSublierNamebyCountry(string Supplier_Name, string country , string Year)
        {
            try
            {

                String Qury = "";

                if (country != "")
                {
                    Qury += " and Country = '" + country + "'";
                }


                if (Year != "")
                {
                    Qury += " and  Year = '" + Year + "'";
                }

                string sql = string.Format("  select count(PdfFileNo) as counter from  vwDuplicateHcpcsCodes where [SupplierQA] like '{0}'   {1} group by HCPCS_Code having  Count([HCPCS_Code]) > 1 ", Supplier_Name, Qury);
                return int.Parse(db.ExecuteQuery(sql).Rows[0][1].ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }




        public int GetAllHCPCSCountCountry(string country, string Year)
        {
            try
            {
                String Qury = "";
                bool Firest = true;
                if (country != "")
                {
                    if (Firest)
                    {
                        Qury += "where Country = '" + country + "'"; ;
                        Firest = false;
                    }

                }


                if (Year != "")
                {
                    if (Firest)
                    {
                        Qury += "where Year = '" + Year + "'"; ;
                        Firest = false;
                    }
                    else
                    {
                        Qury += " and  Year = '" + Year + "'"; ;
                        Firest = false;

                    }

                }
                string sql = string.Format("  select sum(AllCount) as allCount from (select HCPCS_Code ,  count(HCPCS_Code) as AllCount FROM [dbo].[vwPDF] {0} group by HCPCS_Code ) a  ", Qury);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetAllPdfCountCountry(string country, String Year)
        {

            try
            {


                String Qury = "";
                bool Firest = true;
                if (country != "")
                {
                    if (Firest)
                    {
                        Qury += "where Country = '" + country + "'"; ;
                        Firest = false;
                    }

                }


                if (Year != "")
                {
                    if (Firest)
                    {
                        Qury += "where Year = '" + Year + "'"; ;
                        Firest = false;
                    }
                    else
                    {
                        Qury += " and  Year = '" + Year + "'"; ;


                    }

                }
                string sql = string.Format("  select  count(Distinct [PdfFileId])  as AllCount FROM [dbo].[vwPDF] {0}   ", Qury);
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public int GetAllPdfNewCountCountry(string country, string Year)
        {
            try
            {

                String Qury = "where ";
                bool Firest = true;
                if (country != "")
                {
                    if (Firest)
                    {
                        Qury += "  Country = '" + country + "'"; ;
                        Firest = false;
                    }

                }


                if (Year != "")
                {
                    if (Firest)
                    {
                        Qury += "  Year = '" + Year + "'"; ;
                        Firest = false;
                    }
                    else
                    {
                        Qury += " and  Year = '" + Year + "'"; ;
                        Firest = false;

                    }

                }

                string sql = string.Format("  select  count([PdfFileId])  as AllCount FROM [dbo].[vwPDF]  " + Qury + " " +
               "     and  UplodeTime >= dateadd(day,datediff(day,1,GETDATE()),0)" +
                " AND UplodeTime < dateadd(day,datediff(day,0,GETDATE()),0)");
                return int.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        public double GetPdfHCPCSColumnaverageByPDFSublierName(string SupplierQA)
        {
            try
            {
                string sql = string.Format("select average  FROM [dbo].[vwAverage] where SupplierQA = '{0}'", SupplierQA);
                return  Double.Parse(db.ExecuteScalar(sql).ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
