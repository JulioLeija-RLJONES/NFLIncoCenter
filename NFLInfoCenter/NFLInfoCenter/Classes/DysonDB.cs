﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace NFLInfoCenter.Classes
{
    /*
     * This class is meant to manage the data querying from:
     *      1.- Flexlink Air -  database:Flexlink_Air server:Airprodsec.database.windows.net
     *      2.- NFL          -  database:db_elptest   server: elpuatsqlserver.database.windows.net
     */
    class DysonDB : SqlHelper
    {
        private System.Windows.Forms.Form commingFrom;
        /// <summary>
        /// Object handling the querie requests to Dyson Data either on Flexlink DB or NFL DB.
        /// 
        /// Ramarks:
        /// <br/> 
        /// <list type="number">
        /// <item>receives the form that called the creation of this form in order to be able to return to commingFrom form.</item>
        /// </list>
        /// </summary>
        /// <param name="commingFrom"></param>
        public DysonDB(System.Windows.Forms.Form commingFrom)
          : base("dyson")
        {
            this.commingFrom = commingFrom;
        }
        /// <summary>
        /// Queries flexlink database searching for any pre loaded order containing given serial number.
        /// </summary>
        /// <param name="serialNmber"></param>
        /// <returns>A List containing the query result table.</returns>
        public List<string[]> getPreLoadedData(string serialNmber)
        {
            List<string[]> datalist = new List<string[]>();
            string sql = getQuery("getPreLoadedData");
            sql = string.Format(sql, serialNmber);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                    datalist.Add(new string[]{
                        data.FieldValues[0].ToString(), 
                        data.FieldValues[1].ToString()});
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "the serial number has no preloaded information.", commingFrom);
            }
            return datalist;
        }
        /// <summary>
        /// Queries flexlink database to pull data of active receipts related to given serial number.
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns>A List containing the query result table.</returns>
        public List<string[]> getReceiptedData(string serialNumber)
        {
            List<string[]> datalist = new List<string[]>();
            string sql = getQuery("getReceiptData");
            if (serialNumber.Contains(","))
            {
                string[] serialNumbers = serialNumber.Split(',');
                serialNumber = String.Join("','",serialNumbers);
            }
            sql = string.Format(sql, serialNumber);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                    datalist.Add(new string[] { data.FieldValues[0].ToString(),
                                                data.FieldValues[1].ToString(), 
                                                data.FieldValues[2].ToString(),
                                                data.FieldValues[3].ToString(),
                                                data.FieldValues[4].ToString()});
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "the serial number has no records at receiving stations.", commingFrom);
            }
            return datalist;
        }
        /// <summary>
        /// Queries flexlink database searching for any pre loaded order containing given order number.
        /// </summary>
        /// <param name="orderNumber"></param>
        /// <returns>A List containing the query result table.</returns>
        public List<string[]> getOrderPreLoadedData(string orderNumber)
        {
            List<string[]> datalist = new List<string[]>();
            string sql = getQuery("getOrderPreloadedData");
            sql = string.Format(sql, orderNumber);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                    datalist.Add(new string[] { data.FieldValues[0].ToString(),
                                                data.FieldValues[1].ToString(),
                                                data.FieldValues[2].ToString()});
                }
            }
                return datalist;
        }
        /// <summary>
        /// Queries flexlink database searching for all receipts generated by given stationName.
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns>A count of the receipt records found for the given station name.</returns>
        public int getStationReceiptsCount(string stationName)
        {
            int count = 0;
            string sql = Queries.getQuery("getStationReceiptsCount");
            sql = string.Format(sql, stationName);
            var rows = ExecuteReader(sql);
            count = rows.Count;
            return count;    
        }
        /// <summary>
        /// Queries flelink database searching for all in use workstations.
        /// </summary>
        /// <returns>An array containing the list of active workstations.</returns>
        public string[] getActiveStations()
        {
            List<string> list = new List<string>();
            string sql = Queries.getQuery("dyson_getActiveStations");
            var rows = ExecuteReader(sql);
            foreach (var data in rows)
            {
                var match = list.FirstOrDefault(stringToCheck => stringToCheck == data.FieldValues[1].ToString());
                if (match == null &&
                    (data.FieldValues[1].ToString().Contains("REC-ST") ||
                    data.FieldValues[1].ToString().Contains("PRE-REC") ||
                    data.FieldValues[1].ToString().Contains("Pre Receiving") )
                    )
                    {
                        list.Add(data.FieldValues[1].ToString());
                    }
            }
            return list.ToArray();
        }
        /// <summary>
        /// Queries flexlink database and pulls the last 30 receipts found in the Detail table.
        /// </summary>
        /// <returns>A list containing the 30 latest Receipts found in flexlink.</returns>
        public List<Receipt> getReceiptsWindow()
        {
            List<Receipt> list = new List<Receipt>();
            Receipt receipt;
            string sql = Queries.getQuery("receiptsWindow");
            var rows = ExecuteReader(sql);
            foreach(var data in rows)
            {
                receipt = new Receipt();
                receipt.Id = (int)data.FieldValues[0];
                receipt.Sku = data.FieldValues[1].ToString();
                receipt.Qty = (int)data.FieldValues[2];
                receipt.SerialNumber = data.FieldValues[3].ToString();
                receipt.RMANumber = data.FieldValues[4].ToString();
                receipt.COO = data.FieldValues[5].ToString();
                receipt.Tote = data.FieldValues[6].ToString();
                receipt.channel = data.FieldValues[7].ToString();
                receipt.disposition = data.FieldValues[8].ToString();
                receipt.employee = data.FieldValues[9].ToString();
                receipt.scanTime = data.FieldValues[10].ToString();
                receipt.station = data.FieldValues[12].ToString();
                list.Add(receipt);
            }
            return list;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls the last 30 receipts found for the 
        /// given station name.
        /// </summary>
        /// <param name="station"></param>
        /// <returns>A list containing the 30 latest Receipts found in flexlink.</returns>
        public List<Receipt> getReceiptsWindow(string station)
        {
            List<Receipt> list = new List<Receipt>();
            Receipt receipt;
            string sql = Queries.getQuery("receiptsWindowWithStation");
            sql = String.Format(sql, station);
            var rows = ExecuteReader(sql);
            foreach (var data in rows)
            {
                receipt = new Receipt();
                receipt.Id = (int)data.FieldValues[0];
                receipt.Sku = data.FieldValues[1].ToString();
                receipt.Qty = (int)data.FieldValues[2];
                receipt.SerialNumber = data.FieldValues[3].ToString();
                receipt.RMANumber = data.FieldValues[4].ToString();
                receipt.COO = data.FieldValues[5].ToString();
                receipt.Tote = data.FieldValues[6].ToString();
                receipt.channel = data.FieldValues[7].ToString();
                receipt.disposition = data.FieldValues[8].ToString();
                receipt.employee = data.FieldValues[9].ToString();
                receipt.scanTime = data.FieldValues[10].ToString();
                receipt.station = data.FieldValues[12].ToString();
                list.Add(receipt);
            }
            return list;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls the latest 30 prereceipts found in PreReceiving table.
        /// </summary>
        /// <returns>A list containing the latest 30 prerecipts.</returns>
        public List<PreReceipts> getPreReceiptsWindow()
        {
            List<PreReceipts> list = new List<PreReceipts>();
            PreReceipts prereceipt;
            string sql = Queries.getQuery("dyson_getPreReceipts");
            var rows = ExecuteReader(sql);
            foreach (var data in rows)
            {
                prereceipt = new PreReceipts();
                prereceipt.Id = Int32.Parse(data.FieldValues[0].ToString());
                prereceipt.OrderNumber = data.FieldValues[1].ToString();
                prereceipt.TrackingNumber = data.FieldValues[2].ToString();
                prereceipt.Pallets = Int32.Parse(data.FieldValues[3].ToString());
                prereceipt.Boxes = Int32.Parse(data.FieldValues[4].ToString());
                prereceipt.Employee = data.FieldValues[5].ToString();
                prereceipt.Channel = data.FieldValues[6].ToString();
                prereceipt.Item = Int32.Parse(data.FieldValues[7].ToString());
                list.Add(prereceipt);
            }
            return list;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls the latest 30 prereceipts found in PreReceiving table
        /// filtering results by the given station name.
        /// </summary>
        /// <param name="station"></param>
        /// <returns>A list containing the latest 30 prerecipts of given station.</returns>
        public List<PreReceipts> getPreReceiptsWindow(string station)
        {
            List<PreReceipts> list = new List<PreReceipts>();
            PreReceipts prereceipt;
            string sql = Queries.getQuery("dyson_getPreReceiptsWithStation");
            sql = String.Format(sql, station);
            var rows = ExecuteReader(sql);
           
            
            foreach (var data in rows)
            {
                prereceipt = new PreReceipts();
                prereceipt.Id = Int32.Parse(data.FieldValues[0].ToString());
                prereceipt.OrderNumber = data.FieldValues[1].ToString();
                prereceipt.TrackingNumber = data.FieldValues[2].ToString();
                prereceipt.Pallets = Int32.Parse(data.FieldValues[3].ToString());
                prereceipt.Boxes = Int32.Parse(data.FieldValues[4].ToString());
                prereceipt.CreatedOn = data.FieldValues[5].ToString();
                prereceipt.Employee = data.FieldValues[6].ToString();
                prereceipt.Channel = data.FieldValues[7].ToString();
                prereceipt.Item = Int32.Parse(data.FieldValues[8].ToString());
                list.Add(prereceipt);
            }
            
            return list;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all active receipts matching the given RMA Number.
        /// </summary>
        /// <param name="rma"></param>
        /// <returns>A List of string arrays containing the data of RMA receipts.</returns>
        public List<string[]> getRMAReceipts(string rma)
        {
            List<string[]> datalist = new List<string[]>();
            string sql = getQuery("dyson_getRMAReceipts");
            if (rma.Contains(","))
            {
                string[] rmas = rma.Split(',');

                rma = String.Join("','", rma);
            }
            sql = string.Format(sql, rma);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                    datalist.Add(new string[] { data.FieldValues[0].ToString(),
                                                data.FieldValues[1].ToString(),
                                                data.FieldValues[2].ToString(),
                                                data.FieldValues[3].ToString(),
                                                data.FieldValues[4].ToString(),
                                                data.FieldValues[5].ToString(),
                                                data.FieldValues[6].ToString(),
                                                data.FieldValues[7].ToString(),
                                                data.FieldValues[8].ToString(),
                                                data.FieldValues[9].ToString(),
                                                data.FieldValues[10].ToString(),
                                                data.FieldValues[11].ToString(),
                                                data.FieldValues[12].ToString()
                    });
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "the serial number has no records at receiving stations.", commingFrom);
            }
            return datalist;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all active receipts matching the given RMA Number.
        /// </summary>
        /// <param name="rma"></param>
        /// <param name="getObject"></param>
        /// <returns>A List of Receipt objects containing the data of RMA receipts.</returns>
        public List<Receipt> getRMAReceipts(string rma,bool getObject = false)
        {
            List<Receipt> datalist = new List<Receipt>();
            string sql = getQuery("dyson_getRMAReceipts");
            sql = string.Format(sql, rma);
            var rows = ExecuteReader(sql);
            if(rows.Count > 0){
                foreach(var data in rows)
                {
                    Receipt r = new Receipt();
                    r.Tote = data.FieldValues[0].ToString();
                    r.Sku = data.FieldValues[1].ToString();
                    r.Qty = Int32.Parse(data.FieldValues[2].ToString());
                    r.RMANumber = data.FieldValues[3].ToString();
                    r.channel = data.FieldValues[4].ToString();
                    r.station = data.FieldValues[5].ToString();
                    r.employee = data.FieldValues[6].ToString();
                    r.COO = data.FieldValues[7].ToString();
                    r.disposition = data.FieldValues[8].ToString();
                    r.scanTime = data.FieldValues[10].ToString();
                    r.SerialNumber = data.FieldValues[11].ToString();
                    r.Id = Int32.Parse(data.FieldValues[12].ToString());
                    datalist.Add(r);
                }
            }
            return datalist;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all active PreReceipts matching the given RMA.
        /// </summary>
        /// <param name="rma"></param>
        /// <returns>A list of string arrays containing the PreReceipts of the given RMA. </returns>
        public List<string[]> getRMAPreReceipts(string rma)
        {
            List<string[]> datalist = new List<string[]>();
            string sql = getQuery("dyson_getRMAPreReceipts");
            if (rma.Contains(","))
            {
                string[] rmas = rma.Split(',');

                rma = String.Join("','", rma);
            }
            sql = string.Format(sql, rma);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                        datalist.Add(new string[] { data.FieldValues[0].ToString(),
                                                data.FieldValues[1].ToString(),
                                                data.FieldValues[2].ToString(),
                                                data.FieldValues[3].ToString(),
                                                data.FieldValues[4].ToString(),
                                                data.FieldValues[5].ToString(),
                                                data.FieldValues[6].ToString(),
                                                data.FieldValues[7].ToString(),
                                                data.FieldValues[8].ToString()
                                           
                    });
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "the rma number has no records at prereceiving stations.", commingFrom);
            }
            return datalist;
        }
        /// <summary>
        /// Queries dyson flexlink database and pulls all active PreReceipts matching the given RMA.
        /// </summary>
        /// <param name="rma"></param>
        /// <param name="getObjet"></param>
        /// <returns>A list of PreReceipt objects containing data of Precetips of given RMA.</returns>
        public List<PreReceipts> getRMAPreReceipts(string rma, bool getObjet = false)
        {
            List<PreReceipts> datalist = new List<PreReceipts>();
            string sql = getQuery("dyson_getRMAPreReceipts");
            sql = string.Format(sql, rma);
            var rows = ExecuteReader(sql);
            if (rows.Count > 0)
            {
                foreach (var data in rows)
                {
                    PreReceipts p = new PreReceipts();
                    p.Id = Int32.Parse(data.FieldValues[0].ToString());
                    p.OrderNumber = data.FieldValues[1].ToString();
                    p.TrackingNumber = data.FieldValues[2].ToString();
                    p.Pallets = Int32.Parse(data.FieldValues[3].ToString());
                    p.Boxes = Int32.Parse(data.FieldValues[4].ToString());
                    p.CreatedOn = data.FieldValues[5].ToString();
                    p.Employee = data.FieldValues[6].ToString();
                    p.Channel = data.FieldValues[7].ToString();
                    p.Item = Int32.Parse(data.FieldValues[8].ToString());
                    datalist.Add(p);
                }
            }
            else
            {
                MsgTypes.printme(MsgTypes.msg_failure, "the serial number has no records at prereceiving stations.", commingFrom);
            }
            return datalist;
        }
        /// <summary>
        /// Queries tbl_DysonMaster_Station in db_elptest mapping the hostname to a Station name.
        /// <br/> <br/> 
        /// Ramarks:
        /// <br/> 
        /// <list type="number">
        /// <item>The hostname-stationname map is meant to trace a printing user to a Zebra printer in 
        /// PreReceiving workstaions.</item>
        /// </list>
        /// </summary>
        /// <param name="hostname"></param>
        /// <returns></returns>
        public string getStationName(string hostname)
        {
            /*Variable that will receive the mapped station name*/
            string name = "";

            /*Creating blank dataset for data dump.*/
            DataSet dataset = new DataSet();

            /*Getting query description.*/
            string sql = getQuery("dyson_getStationHostnameMap");
            sql = string.Format(sql, hostname);

            /*Calling built in data source and filling dataset*/
            SqlDataAdapter adapter =
                new SqlDataAdapter();
            adapter = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings[3].ConnectionString);

            adapter.Fill(dataset);

            /*
             * Checking every item created in tbl_DysonMaster_Statio
             * server: elpuatsqlserver.database.windows.net
             * database: db_elptest
           */
            foreach (DataRow row in dataset.Tables[0].Rows)
            {
                if (row.ItemArray[2].ToString() == hostname)
                {
                    name = row.ItemArray[1].ToString();
                }
            }
            return name;             
        }

        #region SupportFunctions
        /// <summary>
        /// Selects a SQL statement from project files located in Queries folder.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The SQL statement requested by query file name.</returns>
        private string getQuery(string name)
        {
            
            try
            {
                //string[] files = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Queries\\");
                //string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "\\Queries\\");

                string path = System.Windows.Forms.Application.ExecutablePath;
                path = path.Replace("NFLInfoCenter.exe","");
                
                
                
                string[] files = Directory.GetFiles(path + "\\Queries\\");
                string sql = "";

                foreach (string file in files)
                {
                    
                    if (file.Contains(name))
                    {
                        sql = System.IO.File.ReadAllText(file);
                    }
                }
                if (sql == "")
                {
                    Console.WriteLine("faiules >> no query obtained");
                }
                else
                {
                    
                }
                

                return sql;
            }
            catch(System.IO.DirectoryNotFoundException ex)
            {
                return null;
            }
          
        }
        #endregion
    }
}

