using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

/*
 * NUZHEN Aj-PI chtob mozhno bylo podklyuchat'sya k servernomu prilozheniyu, a ne k sserveru
 * */
namespace SubstancesReferenceBook.Controllers
{
    //[Route("[controller]")]
    public class SampleDataController : Controller
    {  
        SqlConnection sqlConnection;
        public string ArtemConnection = "Data Source=DESKTOP-KK85Q69;Initial Catalog=SubstancesReferenceBook;Integrated Security=True";
        public SampleDataController()
        {

            sqlConnection = new SqlConnection("Data Source=MARIA;" +
                "Initial Catalog=SubstancesReferenceBook;" +
                "Integrated Security=True");
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
                    Category = catSub(Int32.Parse(reader[3].ToString()))
                }
                ) ;
            }
                        
            reader.Close();
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

        //Tipy istochnikov
        [HttpGet("types")]
        public List<SourceType> LlistOfSourceTypes()
        {
            string queryTable = "SELECT * FROM " + " [dbo].[SourceType]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            List<SourceType> data = new List<SourceType>();

            while (reader.Read())
            {
                data.Add(new SourceType()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    Name = reader[1].ToString(),
                    Descr = reader[2].ToString()                    
                }
                );
            }

            reader.Close();
            return data;
        }

        //Vse istochniki
        //RETURN spisok masiivov(string), tam gde CALC - pishem RASCHET
        [HttpGet ("AllSources")]
        public List<string[]> ListOfAllSources()
        {
            List<string[]> data = new List<string[]>(); 

            /*REF*/
            string queryTable = "SELECT * FROM " + " [dbo].[RefSources]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();

            /*Calc*/
            queryTable = "SELECT * FROM " + " [dbo].[CalcfSources]";
            command = new SqlCommand(queryTable, sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = "������";
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();

            /*Web*/
            queryTable = "SELECT * FROM " + " [dbo].[WebfSources]";
            command = new SqlCommand(queryTable, sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();

            /*Measure*/
            queryTable = "SELECT * FROM " + " [dbo].[MeasurefSources]";
            command = new SqlCommand(queryTable, sqlConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new string[3]);
                data[data.Count() - 1][0] = reader[0].ToString();
                data[data.Count() - 1][1] = reader[1].ToString();
                data[data.Count() - 1][2] = reader[2].ToString();
            }
            reader.Close();

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
    

        //Svayzy znacheniy i istochnikov
        [HttpGet("SourceLinks")]
        public List<PropValueSourceLinks> listOfSource(int propValueID, int type)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[PropValueSourceLinks] WHERE PropValueID = " + propValueID + ", ValueType = " + type;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
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
                }
                );
            }

            reader.Close();
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
        public void UpdSub()
        {
           
        }
        [HttpGet()]
        public void UpdSource()
        {
            
        }
        [HttpGet()]
        public void UpdValue()
        {
            
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
        [HttpGet()]
        public void AddSub(string htmlNameSubAdd, int categoryIdSubAdd, string nameSubAdd, string descrSubAdd = "")
        {
            string queryTablel = "INSERT INTO [dbo].[Substances] (Name, Descr, CategoryID, HtmlName) VALUES ('" + nameSubAdd + "', '" + descrSubAdd + "', " + categoryIdSubAdd + ", '" + htmlNameSubAdd + "')";

            SqlCommand command1 = new SqlCommand(queryTablel, sqlConnection);
            command1.ExecuteNonQuery();
        }
        [HttpGet()]
        public void AddSource()
        {

        }
        [HttpGet()]
        public void AddValue()
        {

        }




    //PRIVATE 
        //Infa o categorii materiala
        private Category catSub(int catID)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[SubstCategories] WHERE ID = " + catID;
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            Category data = new Category()
            {
                Id = catID,
                ParentId = Int32.Parse(reader[1].ToString()),
                Name = reader[2].ToString(),
                Descr = reader[3].ToString()
            };

            reader.Close();
            return data;
        }
        //Infa o svoistve
        private Props listProps(int propId)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[Properties]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
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
            return data;
        }
        //Infa o statichnyh peremennyh dlya massiva
        private StateVariables StateVar(int stateVarId)
        {
            string queryTable = "SELECT * FROM " + " [dbo].[StateVariables]";
            SqlCommand command = new SqlCommand(queryTable, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            StateVariables data = new StateVariables()
            {
                Id = Int32.Parse(reader[0].ToString()),
                Name = reader[1].ToString(),
                Descr = reader[2].ToString(),
                StateVarUnit = reader[3].ToString()
            };
            reader.Close();
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

        //



/*
 * CHto eshche nuzhno
 * perepisat' vse zaprosy tak chtoby bylo minimum dejstvij u klienta, maksimum tut
 * napisat' apdejt del i dobavl dlya mater, kategorij, znachenij
 * izmenit' klassy soglasno izmenennoj bd (plyus tablica 'tipy dannyh - svyaz' s svojstva i , stolbec Udalen - istochniki, stolbec TipDannyh - tablica svyazi s istochnikami
 * 
 */
 
    }
}