﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Xml;

namespace EDIX12Parser.core
{
    public class extendsql : IDisposable
    {
        #region delegates
        public delegate string DelegateInvokeService();
        #endregion
        #region public properties
        public dbTypes dbType { get; set; }
        public enum dbTypes
        {
            SQLServer = 0
        }
        public string sqltxt { get; set; }
        public CommandTypes cmdType { get; set; }
        public enum CommandTypes
        {
            TXT = 0,
            SP = 1
        }
        public ConnectionNames cnnName { get; set; }
        public enum ConnectionNames
        {
            labels = 0,
            RECO = 1
        }
        public IList<SqlParameter> TargetPrms { get; set; }
        private IList<rspt> sqlparameters;
        public IList<rspt> RequestParameters
        {
            get
            {
                if (sqlparameters == null) { sqlparameters = new List<rspt>(); }
                return sqlparameters;
            }
            set { sqlparameters = value; }
        }
        #endregion
        #region public methods
        public XmlDocument GetAsyncXMLMethod()
        {
            XmlDocument xmldoc = new XmlDocument();
            using (SqlConnection cnn = new SqlConnection(cnnstr()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    SetText(cmd);
                    SetType(cmd);
                    SetParameters(cmd);
                    cnn.Open();
                    using (XmlReader Reader = cmd.ExecuteXmlReader())
                    {
                        xmldoc.Load(Reader);
                    }
                }
            }
            return xmldoc;
        }
        public DataTable GetDataTableMethod()
        {
            DataTable dt = new DataTable();
            {
                using (SqlConnection cnn = new SqlConnection(cnnstr()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        SetText(cmd);
                        SetType(cmd);
                        SetParameters(cmd);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            return dt;
        }
        public DataSet GetDataSetMethod()
        {
            DataSet dt = new DataSet();
            using (SqlConnection cnn = new SqlConnection(cnnstr()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    SetText(cmd);
                    SetType(cmd);
                    SetParameters(cmd);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }
        public void ExecuteNonQuery()
        {
            using (SqlConnection cnn = new SqlConnection(cnnstr()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    SetText(cmd);
                    SetType(cmd);
                    SetParameters(cmd);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public object ExecuteScalar()
        {
            using (SqlConnection cnn = new SqlConnection(cnnstr()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = cnn;
                    SetText(cmd);
                    SetType(cmd);
                    SetParameters(cmd);
                    cnn.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        #endregion
        #region private methods
        private string cnnstr()
        {
            string cnnname = "";
            switch (cnnName)
            {
                case ConnectionNames.labels:
                    cnnname = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                    break;
                case ConnectionNames.RECO:
                    cnnname = ConfigurationManager.ConnectionStrings["SIR"].ConnectionString;
                    break;
                default:
                    cnnname = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
                    break;
            }
            return cnnname;
        }

        private SqlConnection NewConnection()
        {
            return new SqlConnection(cnnstr());
        }
        private SqlCommand netCommand()
        {
            SqlCommand cmd = new SqlCommand();
            if (cmdType == CommandTypes.SP)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
            return cmd;
        }
        private void SetText(SqlCommand cmd)
        {
            cmd.CommandText = sqltxt;
        }
        private void SetType(SqlCommand cmd)
        {
            if (cmdType == CommandTypes.SP)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd.CommandType = CommandType.Text;
            }
        }
        private void SetParameters(SqlCommand cmd)
        {
            if (RequestParameters != null)
            {
                foreach (rspt prm in RequestParameters)
                {
                    cmd.Parameters.AddWithValue(prm.txt, prm.val);
                }
            }
        }
        #endregion
        #region destructors
        private bool disposed = false; // to detect redundant calls
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {//TODO: Implements IDisposing
                } disposed = true;
            }
        }
        public void Dispose() { Dispose(true); GC.SuppressFinalize(this); }
        #endregion
        public class rspt
        {
            public string txt { get; set; }
            public object val { get; set; }
            public rspt(string texto, object valor)
            {
                txt = texto;
                val = valor;
            }
            public rspt add(string texto, object valor)
            {
                return new rspt(texto, valor);
            }
        }
    }

}