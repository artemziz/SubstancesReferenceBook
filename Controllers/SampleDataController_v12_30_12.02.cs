using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

/*
 * MashaConnection
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True"
 * NUZHEN Aj-PI chtob mozhno bylo podklyuchat'sya k servernomu prilozheniyu, a ne k sserveru
 * */
namespace SubstancesReferenceBook.Controllers
{
    //[Route("[controller]")]
    public class SampleDataController : Controller
    {
        SqlConnection sqlConnection;
        public string Conn = "Data Source=MARIA;Initial Catalog=SubstancesReferenceBook;Integrated Security=True";
        //public string Conn = "Data Source=DESKTOP-KK85Q69;Initial Catalog=SubstancesReferenceBook;Integrated Security=True";
        public SampleDataController()
        {
            //SqlConnection sqlConnection;
            sqlConnection = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnection.Open();
        }


        //POLNYJ SPISOK

        //Spisok materialov
        [HttpGet("substances")]
        public List<Sub> listOfSubstances()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Substances]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Sub> data = new List<Sub>();

            while (reader.Read())
            {
                data.Add(new Sub()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString(),
                    Category = catSub(4/*Int32.Parse(reader[3].ToString())*/)
                }
                );
            }

            reader.Close();
            bool i = reader.IsClosed;
            return data;
        }

        //Spisok kategoriy
        [HttpGet("categories")]
        public List<Category> listOfCategories()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[SubstCategories]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<Category> data = new List<Category>();

            while (reader.Read())
            {
                data.Add(new Category()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    ParentId = Int32.Parse(reader[1].ToString()),
                    Name = reader[2].ToString(),
                    Descr = reader[3].ToString()
                }
                );
            }

            reader.Close();
            return data;
        }

        /*
        //Tipy istochnikov - DONT WORK
        //[HttpGet("types")]
        //public List<SourceType> LlistOfSourceTypes()
        //{
        //    string queryTable = "SELECT * FROM " + " [dbo].[SourceType]";
        //    SqlCommand command = new SqlCommand(queryTable, sqlConnection);
        //    SqlDataReader reader = command.ExecuteReader();
        //    List<SourceType> data = new List<SourceType>();

        //    while (reader.Read())
        //    {
        //        data.Add(new SourceType()
        //        {
        //            Id = Int32.Parse(reader[0].ToString()),
        //            Name = reader[1].ToString(),
        //            Descr = reader[2].ToString()   
                    
        //        }
        //        );
        //    }

        //    reader.Close();
        //    return data;
        //}
        */
        
        //Vse istochniki
        //RETURN spisok masiivov(string), tam gde CALC - pishem RASCHET
        [HttpGet ("AllSources")]
        public List<string[]> ListOfAllSources()
        {
            List<string[]> data = new List<string[]>();
            List<string[]> s1 = RefSourceStr();
            List<string[]> s2 = WebSourceStr();
            List<string[]> s3 = CalcSourceStr();
            List<string[]> s4 = MeasureSourceStr();
            data.AddRange(s1);
            data.AddRange(s2);
            data.AddRange(s3);
            data.AddRange(s4);
            return data;
        }

        //Zapros istochnika
        [HttpGet("RefSourceAll")]
        public List<RefSources> lisOfAllRefSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[RefSources] ";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<RefSources> data = new List<RefSources>();

            while (reader.Read())
            {
                data.Add(new RefSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("WebSourceAll")]
        public List<WebSources> lisOfAllWebSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[WebSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<WebSources> data = new List<WebSources>();

            while (reader.Read())
            {
                data.Add(new WebSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("MeasureSourcesAll")]
        public List<MeasureSources> lisOfaLLMeasureSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[MeasureSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<MeasureSources> data = new List<MeasureSources>();

            while (reader.Read())
            {
                data.Add(new MeasureSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("CalcSourcesAll")]
        public List<CalcSources> lisOfAllCalcSource()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[CalcSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<CalcSources> data = new List<CalcSources>();

            while (reader.Read())
            {
                data.Add(new CalcSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = Int32.Parse(reader[1].ToString())
                }
                );
            }
            reader.Close();
            return data;
        }

        [HttpGet("AllProps")]
        public List<Props> listOfAllProps()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Properties]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            List<Props> data = new List<Props>();
            while (reader.Read())
            {
                data.Add(new Props()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString(),
                    PropUnits = reader[3].ToString(),
                    Type = Int32.Parse(reader[4].ToString()),
                    HtmlName = reader[5].ToString(),
                });
            }; 
            reader.Close();
            
            return data;
        }


        //PO ID MATERIALA (SUBSTANCE)
        //Svyazy svoistv dannogo materiala
        [HttpGet("properties")]
        public List<PropSubstLinks> listOfOneSub(int subId)
        {
            string queryTable = "SELECT Id, MinValue, MaxValue, DefaultValue, PropId FROM " 
                                + " [dbo].[PropSubstLinks] WHERE SubstId = " + subId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<PropSubstLinks> data = new List<PropSubstLinks>();

            while (reader.Read())
            {
                data.Add(new PropSubstLinks()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    //PropId = Int32.Parse(reader[1].ToString()),
                    SubstId = subId,
                    MinValue = Convert.ToDouble(reader[1].ToString()),
                    MaxValue = Convert.ToDouble(reader[2].ToString()),
                    DefaultValue = Convert.ToDouble(reader[3].ToString()),
                    Prop = listProps(Int32.Parse(reader[4].ToString()))
                }
                );
            }

            reader.Close();
            return data;
        }



    //PO ID svyazi SVOJSTVA i MATERIALA (berem ego iz listOfOneSub)
            //NADO by SDELAT' EDINUYU FUNKCIYU I UZHE ZDES', a ne u klienta, RESHAT' GDE ISKTA' ZNACHENIYA
            //HZ kak mozhno
        //Massiv
        [HttpGet("Array")]
        public List<Array1DPropValues> listOf1DArray(int propSubID)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Array1DPropValues] WHERE PropSubID = " + propSubID;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<Array1DPropValues> data = new List<Array1DPropValues>();

            while (reader.Read())
            {
                data.Add(new Array1DPropValues()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    //StateVarId = Int32.Parse(reader[2].ToString()),
                    Values = new List<double> { Convert.ToDouble(reader[3].ToString()), Convert.ToDouble(reader[4].ToString()) },
                    VersionDate = Convert.ToDateTime(reader[5].ToString()),
                    StateVar = StateVar(Int32.Parse(reader[2].ToString())),
                }
                );
                
            }
            reader.Close();
            return data;
        }
        //Edinichnye znachenia
        [HttpGet("scalar")]
        public List<ScalarPropValues> listOfScalar(int propSubID)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[ScalarPropValues] WHERE PropSubID = " + propSubID;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<ScalarPropValues> data = new List<ScalarPropValues>();

            while (reader.Read())
            {
                data.Add(new ScalarPropValues()
                {   
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    Value = Convert.ToDouble(reader[2].ToString()),
                    VersionDate = Convert.ToDateTime(reader[3].ToString())
                }
                ) ;
            }

            reader.Close();
            return data;
        }
        //Associativnyy massiv
        [HttpGet("assoc")]
        public List<AssocPropValues> listOfAssoc(int propSubID)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[AssocPropValues] WHERE PropSubID = " + propSubID;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<AssocPropValues> data = new List<AssocPropValues>();

            while (reader.Read())
            {
                data.Add(new AssocPropValues()
                { 
                    Id = Int32.Parse(reader[0].ToString()),
                    PropSubId = Int32.Parse(reader[1].ToString()),
                    Key = reader[2].ToString(),
                    Value = Convert.ToDouble(reader[3].ToString()),
                    VersionDate = Convert.ToDateTime(reader[4].ToString())
                }
                );
            }

            reader.Close();
            return data;
        }
    
    //Po ID Sv-va i MAt I id tipa value(assoc, array, scalar)
        [HttpGet("SourcesOfValues")]
        public List<string[]> sourcesList(int propValueID, int valueType)
        {
            propValueID = 2;
            valueType = 1;
            {//SqlConnection sqlConnection1 = new SqlConnection(Conn);
            //sqlConnection1.Open();
            //string queryTable = "SELECT * FROM " + " [dbo].[PropValueSourceLinks] WHERE PropValueID = " + propValueID + ", ValueType = " + valueType;
            //SqlCommand command = new SqlCommand(queryTable, sqlConnection1);
            //SqlDataReader reader1 = command.ExecuteReader();
            //List<PropValueSourceLinks> dataSourceList = new List<PropValueSourceLinks>();

            //while (reader1.Read())
            //{
            //    dataSourceList.Add(new PropValueSourceLinks()
            //    {
            //        Id = Int32.Parse(reader1[0].ToString()),
            //        PropValueId = propValueID,
            //        SourceTypeId = Int32.Parse(reader1[2].ToString()),
            //        SourceId = Int32.Parse(reader1[3].ToString()),
            //        ValueType = valueType
            //    });
            //}
            //reader1.Close();
            }
            
            List<PropValueSourceLinks> dataSourceList = listOfSource(propValueID, valueType);
            List<string[]> data = new List<string[]>();

            foreach (PropValueSourceLinks sourceInfo in dataSourceList)
            {               
                switch (sourceInfo.SourceTypeId)
                {
                    case 1:
                        data.AddRange(RefSourceStr(sourceInfo.SourceId));
                        break;
                    case 2:
                        data.AddRange(WebSourceStr(sourceInfo.SourceId));
                        break;
                    case 3:
                        data.AddRange(CalcSourceStr(sourceInfo.SourceId));
                        break;
                    case 4:
                        data.AddRange(MeasureSourceStr(sourceInfo.SourceId));
                        break;
                }                
            }
            //reader1.Close();
            //sqlConnection1.Close();
            return data;
        }
        
    
        
        //Zapros istochnika
        [HttpGet("RefSource")]
        public List<RefSources> lisOfRefSource(int propValueID, int type)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[RefSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<RefSources> data = new List<RefSources>();

            while (reader.Read())
            {
                data.Add(new RefSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("WebSource")]
        public List<WebSources> lisOfWebSource(int propValueID, int type)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[WebSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<WebSources> data = new List<WebSources>();

            while (reader.Read())
            {
                data.Add(new WebSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("MeasureSources")]
        public List<MeasureSources> lisOfMeasureSource(int propValueID, int type)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[MeasureSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<MeasureSources> data = new List<MeasureSources>();

            while (reader.Read())
            {
                data.Add(new MeasureSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = reader[1].ToString()
                }
                );
            }
            reader.Close();
            return data;
        }
        [HttpGet("CalcSources")]
        public List<CalcSources> lisOfCalcSource(int propValueID, int type)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[CalcSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<CalcSources> data = new List<CalcSources>();

            while (reader.Read())
            {
                data.Add(new CalcSources()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    sourse = Int32.Parse(reader[1].ToString())
                }
                );
            }
            reader.Close();
            return data;
        }
       


    //UDALENIE ZAPISI
        [HttpGet("DelProp")]
        public List<PropSubstLinks> Delete(int Id, int subID)
        {    
            string queryTable = "DELETE [dbo].[Properties] WHERE ID =" + Id;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            command.ExecuteNonQuery();
            return listOfOneSub(subID);
        }
        [HttpGet("DelSubst")]
        public List<Sub> DeleteSub(int Id)
        {
            //int Id = 3;
            string queryTable = "DELETE [dbo].[Substances] WHERE ID =" + Id;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            command.ExecuteNonQuery();
            return listOfSubstances();
        }
        [HttpGet("DelSource")]
        public string DelSource(int IdSources, int IdTypeSource)
        {
            //int IdSources = 1;
            //int IdTypeSource = 1;
            string succes = "������ ��������"; //Oshibka udaleniya
            //if (DelFlag == 0)
            //{
            if (IdTypeSource == 1)
            {
                Source1(IdSources);
                succes = "�������� ������ ������"; //Istochnik uspesho udalen
            }
            if (IdTypeSource == 2)
            {
                Source2(IdSources);
                succes = "�������� ������ ������"; //Istochnik uspesho udalen
            }
            if (IdTypeSource == 3)
            {
                Source3(IdSources);
                succes = "�������� ������ ������"; //Istochnik uspesho udalen
            }
            if (IdTypeSource == 4)
            { 
                Source4(IdSources);
                succes = "�������� ������ ������"; //Istochnik uspesho udalen
            }
            //}
            return succes;
        }
        [HttpGet("DelValue")] 
        public string DelValue(int valueId, int valueTypeId)
        {
            string tableName = "";
            switch (valueTypeId)
            {
                case 1:
                    tableName = "[dbo].[Array1DPropValues]";
                    break;
                case 2:
                    tableName = "[dbo].[AssocPropValues]";
                    break;
                case 3:
                    tableName = "[dbo].[ScalarPropValues]";
                    break;
            }
            if (tableName != "")
            {
                string queryTable = "DELETE " + tableName + " WHERE ID =" + valueId;
                SqlCommand command = new SqlCommand(queryTable, sqlConnection);
                command.ExecuteNonQuery();
                return "�������� ������ �������"; //Znachenie uspesho udaleno
            }
            return "������ ��������"; //Oshibka udaleniya
        }


    //OBNOVLENIE ZAPISI
        [HttpGet("UpdProp")]
        public List<PropSubstLinks> UpdProp(int Id, string nameUpd, string descrUpd, string propUnitsUpd, int typeUpd, int subID)
        {
            string queryTable = "UPDATE [dbo].[Properties] SET Name = '" + nameUpd + "', Descr = '" + descrUpd + "', PropUnits = '" + propUnitsUpd + "', ValueType = " + typeUpd + " WHERE ID =" + Id;

            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
            return listOfOneSub(subID);
        }
        [HttpGet()]
        public void UpdSub(int Id, string nameUpd, string descrUpd, int categoryId, string htmlName)
        {
            string queryTable = "UPDATE [dbo].[Properties] SET Name = '" + nameUpd + "', Descr = '" + descrUpd + "', HtmlName = '" 
                + htmlName + "', CategoryID = " + categoryId + " WHERE ID =" + Id;
            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
        }
        [HttpGet("UpdSource")]
        public void UpdSource(int typeS, string source)
        {
            string queryTabel = "";
            switch (typeS)
            {
                case 1:
                    queryTabel = "UPDATE [dbo].[MeasureSources] SET Conditions = '" + source + "')";
                    break;
                case 2:
                    queryTabel = "UPDATE [dbo].[WebSources] SET [URL] = '" + source + "'";
                    break;
                case 3:
                    queryTabel = "UPDATE [dbo].[RefSources] SET Reference = '" + source + "')";
                    break;
                case 4:
                    queryTabel = "UPDATE [dbo].[CalcSources] SET VariantID = '" + Int32.Parse(source) + "')";
                    break;
            }
            //source = "The best Ref";
            //queryTabel = "INSERT INTO[dbo].[RefSources] (Reference) VALUES('" + source + "')";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }
        [HttpGet("UpdArray")]
        public void UpdValueArray(int probSubID, int stateVarID, float value, float valueStateVar, DateTime dateTime)
        {

            string queryTabel = "UPDATE [dbo].[Array1DPropValues] (ProbSubID, StateVarID, StateVar, Value, VersionDate) " +
                                "VALUES(" + probSubID + ", " + stateVarID + ", " + value + ", " + valueStateVar + ", " + dateTime + ")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }
        [HttpGet("UpdAssoc")]
        public void UpdValueAssoc(int probSubID, string key, float value, DateTime dateTime)
        {
            string queryTabel = "UPDATE [dbo].[AssocPropValues] (PropSubID, [Key], Value, VersionDatte) " +
                                "VALUES(" + probSubID + ", '" + key + ", " + value + ", " + dateTime + ")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }
        [HttpGet("UpdScalar")]
        public void UpdValueScalar(int probSubID, float value, DateTime dateTime)
        {
            string queryTabel = "UPDATE [dbo].[ScalarPropValues] (PropSubID, Value, VersionDate) " +
                                "VALUES(" + probSubID + ", " + value + ", " + dateTime + ")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }

        //DOBAVLENIE ZAPISI
        [HttpGet("AddProp")]
        public List<PropSubstLinks> AddProp(string namePropAdd, string htmlName, string propUnitsPropAdd, int typePropAdd, int subID, string descrPropAdd = "")
        {
            //string namePropAdd = "New Prop";
            //string descrPropAdd = "Descr New Prop";
            //string propUnitsPropAdd = "Kto ero znaet";
            //int typePropAdd = 2;

            string queryTablel = "INSERT INTO [dbo].[Properties] (Name, Descr, PropUnits, ValueType, HtmlName) VALUES ('" + namePropAdd + "', '" + descrPropAdd + "', '" + propUnitsPropAdd + "', " + typePropAdd + ", '" + htmlName + "')";

            SqlCommand command1 = new SqlCommand(queryTablel, sqlConnection);
            command1.ExecuteNonQuery();
            return listOfOneSub(subID);
        }
        [HttpGet("AddSub")]
        public void AddSub(string htmlNameSubAdd, int categoryIdSubAdd, string nameSubAdd, string descrSubAdd = "")
        {
            
            string queryTablel = "INSERT INTO [dbo].[Substances] (Name, Descr, CategoryID, HtmlName) VALUES ('" + nameSubAdd + "', '" + descrSubAdd + "', " + Int32.Parse(categoryIdSubAdd.ToString()) + ", '" + htmlNameSubAdd + "')";
            //queryTablel = "INSERT INTO [dbo].[Substances] (Name, Descr, CategoryID, HtmlName) VALUES ('SubExample', 'DescrSubEx', 4, 'SubBlaBla')";
            SqlCommand command1 = new SqlCommand(queryTablel, sqlConnection);
            command1.ExecuteNonQuery();
           
        }
        [HttpGet("AddSource")]
        public void AddSource(int typeS, string source)
        {
            string queryTabel = "";
            switch (typeS)
            {
                case 1:
                    queryTabel = "INSERT INTO[dbo].[MeasureSources] (Conditions) VALUES('" + source + "')";
                    break;
                case 2:
                    queryTabel = "INSERT INTO[dbo].[WebSources] ([URL]) VALUES('" + source + "')";
                    break;
                case 3:
                    queryTabel = "INSERT INTO[dbo].[RefSources] (Reference) VALUES('" + source + "')";
                    break;
                case 4:
                    queryTabel = "INSERT INTO[dbo].[CalcSources] (VariantID) VALUES('" + Int32.Parse(source) + "')";
                    break;
            }
            //source = "The best Ref";
            //queryTabel = "INSERT INTO[dbo].[RefSources] (Reference) VALUES('" + source + "')";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
            //return queryTabel;
        }
        
        [HttpGet("AddArray")]
        public void AddValueArray(int probSubID, int stateVarID, float value, float valueStateVar, DateTime dateTime)
        {
            
            string queryTabel = "INSERT INTO [dbo].[Array1DPropValues] (ProbSubID, StateVarID, StateVar, Value, VersionDate) " +
                                "VALUES("+ probSubID +", "+ stateVarID + ", " + value + ", " + valueStateVar + ", " + dateTime +")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }
        [HttpGet("AddAssoc")]
        public void AddValueAssoc(int probSubID, string key, float value, DateTime dateTime)
        {
            string queryTabel = "INSERT INTO [dbo].[AssocPropValues] (PropSubID, [Key], Value, VersionDatte) " +
                                "VALUES(" + probSubID + ", '" + key + ", " + value + ", " + dateTime + ")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }
        [HttpGet("AddScalar")]
        public void AddValueScalar(int probSubID, float value, DateTime dateTime)
        {
            string queryTabel = "INSERT INTO [dbo].[ScalarPropValues] (PropSubID, Value, VersionDate) " +
                                "VALUES(" + probSubID + ", " + value + ", " + dateTime + ")";
            SqlCommand command = new SqlCommand(queryTabel, sqlConnection);
            command.ExecuteNonQuery();
        }



        //PRIVATE 
        //Infa o categorii materiala
        private Category catSub(int catID)
        {
            SqlConnection sqlConnection1;
            sqlConnection1 = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnection1.Open();

            string queryTable1 = "SELECT * FROM " + " [dbo].[SubstCategories] WHERE ID = " + catID;
            SqlCommand command1 = new SqlCommand(queryTable1, sqlConnection1);
            SqlDataReader reader1 = command1.ExecuteReader();
            reader1.Read();
            Category dataCat = new Category()
            {
                Id = catID,
                ParentId = Int32.Parse(reader1[1].ToString()),
                Name = reader1[2].ToString(),
                Descr = reader1[3].ToString()
            };

            reader1.Close();
            sqlConnection1.Close();
            return dataCat;
        }
        //Infa o svoistve
        private Props listProps(int propId)
        {
            SqlConnection sqlConnection2;
            sqlConnection2 = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnection2.Open();

            string queryTable = "SELECT * FROM " + " [dbo].[Properties] WHERE ID = " + propId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection2);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Props data = new Props()
            {
                Id = Int32.Parse(reader[0].ToString()),
                Name = reader[1].ToString(),
                Descr = reader[2].ToString(),
                PropUnits = reader[3].ToString(),
                Type = Int32.Parse(reader[4].ToString()),
                HtmlName = reader[5].ToString(),
            };
            reader.Close();
            sqlConnection2.Close();
            return data;
        }
        //Infa o statichnyh peremennyh dlya massiva
        private StateVariables StateVar(int stateVarId)
        {
            SqlConnection sqlConnectionStateVar;
            sqlConnectionStateVar = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionStateVar.Open();

            string queryTable = "SELECT * FROM " + " [dbo].[StateVariables]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionStateVar);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            StateVariables data = new StateVariables()
            {
                Id = Int32.Parse(reader[0].ToString()),
                Name = reader[1].ToString(),
                Descr = reader[2].ToString(),
                StateVarUnit = reader[3].ToString()
            };
            reader.Close();
            sqlConnectionStateVar.Close();
            return data;
        }
        //Izmenenie znachenia DELETED u istochnika
        private void Source1(int IdSources)
        {
            string queryTable = "UPDATE [dbo].[RefSources] SET Deleted = 1 WHERE ID =" + IdSources;
            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
        }
        private void Source2(int IdSources)
        {
            string queryTable = "UPDATE [dbo].[WebSources] SET Deleted = 1 WHERE ID =" + IdSources;
            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
        }
        private void Source3(int IdSources)
        {
            string queryTable = "UPDATE [dbo].[MeazureSources] SET Deleted = 1 WHERE ID =" + IdSources;
            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
        }
        private void Source4(int IdSources)
        {
            string queryTable = "UPDATE [dbo].[CalcSources] SET Deleted = 1 WHERE ID =" + IdSources;
            SqlCommand command1 = new SqlCommand(queryTable, sqlConnection);
            command1.ExecuteNonQuery();
        }
        //Soursec dlya obsego spiska
        private List<string[]> RefSourceStr(int sourceId = 0)
        {
            SqlConnection sqlConnectionRefSourceStr;
            sqlConnectionRefSourceStr = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionRefSourceStr.Open();
            List<string[]> data = new List<string[]>();
            /*REF*/
            string queryTable = "SELECT * FROM " + " [dbo].[RefSources]";
            if (sourceId != 0) queryTable += "WHERE ID = " + sourceId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionRefSourceStr);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();
            sqlConnectionRefSourceStr.Close();
            return data;
        }
        private List<string[]> CalcSourceStr(int sourceId = 0)
        {
            SqlConnection sqlConnectionCalcSourceStr;
            sqlConnectionCalcSourceStr = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionCalcSourceStr.Open();
            List<string[]> data = new List<string[]>();
            /*Calc*/
            string queryTable = "SELECT * FROM " + " [dbo].[CalcSources]";
            if (sourceId != 0) queryTable += "WHERE ID = " + sourceId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionCalcSourceStr);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = "Raschet";
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();
            sqlConnectionCalcSourceStr.Close();
            return data;
        }
        private List<string[]> WebSourceStr(int sourceId = 0)
        {
            SqlConnection sqlConnectionWebSourceStr;
            sqlConnectionWebSourceStr = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionWebSourceStr.Open();
            List<string[]> data = new List<string[]>();
            /*Web*/
            string queryTable = "SELECT * FROM " + " [dbo].[WebSources]";
            if (sourceId != 0) queryTable += "WHERE ID = " + sourceId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionWebSourceStr);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();
            sqlConnectionWebSourceStr.Close();
            return data;
        }
        private List<string[]> MeasureSourceStr(int sourceId = 0)
        {
            SqlConnection sqlConnectionMeasureSourceStr;
            sqlConnectionMeasureSourceStr = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionMeasureSourceStr.Open();

            List<string[]> data = new List<string[]>();
            /*Measure*/
            string queryTable = "SELECT * FROM " + " [dbo].[MeasureSources]";
            if (sourceId != 0) queryTable += "WHERE ID = " + sourceId;
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionMeasureSourceStr);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();
            sqlConnectionMeasureSourceStr.Close();
            return data;
        }

        //Svayzy znacheniy i istochnikov
        private List<PropValueSourceLinks> listOfSource(int propValueID, int type)
        {
            SqlConnection sqlConnectionMeasureSourceLinks;
            sqlConnectionMeasureSourceLinks = new SqlConnection(Conn);
            //sqlConnection = new SqlConnection(ArtemConnection);
            sqlConnectionMeasureSourceLinks.Open();

            string queryTable = "SELECT * FROM " + " [dbo].[PropValueSourceLinks] WHERE PropValueID = " + propValueID + "AND ValueType = " + type;
            SqlCommand command = new SqlCommand(queryTable, sqlConnectionMeasureSourceLinks);
            SqlDataReader reader = command.ExecuteReader();
            List<PropValueSourceLinks> data = new List<PropValueSourceLinks>();

            while (reader.Read())
            {
                data.Add(new PropValueSourceLinks()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    PropValueId = propValueID,
                    SourceTypeId = Int32.Parse(reader[2].ToString()),
                    SourceId = Int32.Parse(reader[3].ToString()),
                    ValueType = type
                }
                ); 
            }

            reader.Close();
            return data;
        }


        /*
         * CHto eshche nuzhno
         * perepisat' vse zaprosy tak chtoby bylo minimum dejstvij u klienta, maksimum tut
         * napisat' apdejt del i dobavl dlya mater, kategorij, znachenij
         * izmenit' klassy soglasno izmenennoj bd (plyus tablica 'tipy dannyh - svyaz' s svojstva i , stolbec Udalen - istochniki, stolbec TipDannyh - tablica svyazi s istochnikami
         * 
         */

    }
}