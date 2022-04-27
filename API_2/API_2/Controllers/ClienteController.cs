using Microsoft.AspNetCore.Mvc;
using API_2.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_2.Controllers
{
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly PruebaTecnicaContext _DbContext = new PruebaTecnicaContext();

        #region CONSULTAS DE REGISTROS

        /// <summary>
        /// Realiza la busqueda del(los) cliente(s).
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Cliente/Cunsulta_Cliente")]
        public  IEnumerable<Cliente> Cunsulta_Cliente (int? IdCliente)
        {
            List<Cliente> ClienteList = new List<Cliente>();
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();

            try
            {
                string Proceso = "SELECT";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand("Clientes_CRUD", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proceso", Proceso);
                cmd.Parameters.AddWithValue("@Idcliente", IdCliente);

                SqlDataReader _Reader = cmd.ExecuteReader();

                while (_Reader.Read())
                {
                    Cliente cliente = new Cliente();
                    MTDocumento mTDocumento = new MTDocumento();
                    mTDocumento.IdDocumento = Convert.ToInt32(_Reader["Id_FKDocumento"]);
                    mTDocumento.DesDocumento = _Reader["Des_documento"].ToString();

                    cliente.IdCliente = Convert.ToInt32(_Reader["IdCliente"]);
                    cliente.Nombre_1 = _Reader["Nombre_1"].ToString();
                    cliente.Nombre_2 = _Reader["Nombre_2"].ToString();
                    cliente.Apellido_1 = _Reader["Apellido_1"].ToString();
                    cliente.Apellido_2 = _Reader["Apellido_2"].ToString();
                    cliente.Nom_Compl = _Reader["Nom_Compl"].ToString();
                    cliente.Id_Fkdocumento = Convert.ToInt32(_Reader["Id_FKDocumento"]);
                    cliente.Nacionalidad = _Reader["Nacionalidad"].ToString();
                    cliente.Nro_Documento = Convert.ToInt32(_Reader["Nro_documento"]);
                    cliente.Fecha_Reg = Convert.ToDateTime(_Reader["Fecha_Reg"]);
                    cliente.Fecha_Act = Convert.ToDateTime(_Reader["Fecha_Act"]);
                    cliente.Estatus = Convert.ToBoolean(_Reader["Estatus"]);
                    cliente.Email = _Reader["Email"].ToString();
                    cliente.IdEmail = Convert.ToInt32(_Reader["IdEmail"]);
                    cliente.TipoEmail = Convert.ToInt32(_Reader["TipoEmail"]);
                    cliente.IdFkdocumentoNavigation = mTDocumento;
                    ClienteList.Add(cliente);

                }



                return ClienteList;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Realiza la busqueda de todos los email relacionados con un cliente
        /// </summary>
        /// <param name="IdCliente"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Cliente/Cunsulta_Email")]
        public IEnumerable<Email> Cunsulta_Email(int? IdCliente)
        {
            List<Email> EmailList = new List<Email>();
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();

            try
            {
                string Proceso = "SELECT";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand("Email_CRUD", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proceso", Proceso);
                cmd.Parameters.AddWithValue("@IdFKcliente", IdCliente);
                SqlDataReader _Reader = cmd.ExecuteReader();

                while (_Reader.Read())
                {
                    Email email = new Email();
                    MTEmail mTEmail = new MTEmail();

                    mTEmail.IdTipo = Convert.ToInt32(_Reader["Id_FKTipo"]);
                    mTEmail.DescTipo = _Reader["Desc_Tipo"].ToString();

                    email.IdEmail = Convert.ToInt32(_Reader["IdEmail"]);
                    email.IdFkcliente = Convert.ToInt32(_Reader["Id_FKCliente"]);
                    email.IdFktipo = Convert.ToInt32(_Reader["Id_FKTipo"]);
                    email.Email1 = _Reader["Email_"].ToString();
                    email.FechReg = Convert.ToDateTime(_Reader["Fech_Reg"]);
                    email.FechAct = Convert.ToDateTime(_Reader["Fech_Act"]);
                    email.Estatus = Convert.ToBoolean(_Reader["Estatus"]);                  
                    email.IdFktipoNavigation = mTEmail;

                    EmailList.Add(email);

                }

                return EmailList;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        [HttpGet]
        [Route("api/Cliente/Cunsulta_TDoc")]
        public List<MTDocumento> Cunsulta_TDoc()
        {
            List<MTDocumento> TDocList = new List<MTDocumento>();
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();

            try
            {
                string Proceso = "M_DOC";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand("M_Consultas_Gen", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proceso", Proceso);
                SqlDataReader _Reader = cmd.ExecuteReader();

                while (_Reader.Read())
                {
                    MTDocumento mTDocumento = new MTDocumento();
                    mTDocumento.IdDocumento = Convert.ToInt32(_Reader["IdDocumento"]);
                    mTDocumento.DesDocumento = _Reader["Des_documento"].ToString();

                    TDocList.Add(mTDocumento);

                }

                return TDocList;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        [HttpGet]
        [Route("api/Cliente/Cunsulta_TEmail")]
        public List<MTEmail> Cunsulta_TEmail()
        {
            List<MTEmail> MTEmailList = new List<MTEmail>();
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();

            try
            {
                string Proceso = "M_TEMAIL";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();
                SqlCommand cmd = new SqlCommand("M_Consultas_Gen", Conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Proceso", Proceso);
                SqlDataReader _Reader = cmd.ExecuteReader();

                while (_Reader.Read())
                {
                    MTEmail mTEmail = new MTEmail();
                    mTEmail.IdTipo = Convert.ToInt32(_Reader["IdTipo"]);
                    mTEmail.DescTipo = _Reader["Desc_Tipo"].ToString();

                    MTEmailList.Add(mTEmail);

                }

                return MTEmailList;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        #endregion

        #region GUARDAR REGISTROS 
        /// <summary>
        /// Realiza el guardado de un nuevo cliente para ser registrado en BDD
        /// </summary>
        /// <param name="Modelcliente"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Cliente/Insertar_Cliente")]
        public int Insertar_Cliente(Cliente Modelcliente)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "INSERT";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Clientes_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@Nombre_1", Modelcliente.Nombre_1);
                objCommand.Parameters.AddWithValue("@Nombre_2", Modelcliente.Nombre_2);
                objCommand.Parameters.AddWithValue("@Apellido_1", Modelcliente.Apellido_1);
                objCommand.Parameters.AddWithValue("@Apellido_2", Modelcliente.Apellido_2);
                objCommand.Parameters.AddWithValue("@Id_FKdocument", Modelcliente.Id_Fkdocumento);
                objCommand.Parameters.AddWithValue("@Nacionalidad", Modelcliente.Nacionalidad);
                objCommand.Parameters.AddWithValue("@Nro_document", Modelcliente.Nro_Documento);
                objCommand.Parameters.AddWithValue("@Estatus", Modelcliente.Estatus);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Realiza el guardado de un nuevo email del cliente
        /// </summary>
        /// <param name="Modelemail"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Cliente/Insertar_Email")]
        public int Insertar_Email(Email Modelemail)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "INSERT";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Email_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@IdEmail", Modelemail.IdEmail);
                objCommand.Parameters.AddWithValue("@IdFKcliente", Modelemail.IdFkcliente);
                objCommand.Parameters.AddWithValue("@Id_FKtipo", Modelemail.IdFktipo);
                objCommand.Parameters.AddWithValue("@Email", Modelemail.Email1);
                objCommand.Parameters.AddWithValue("@Estatus", Modelemail.Estatus);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }

        }

        #endregion

        #region ACTUALIZAR REGISTROS
        [HttpPost]
        [Route("api/Cliente/Update_Cliente")]
        public int Update_Cliente(Cliente Modelcliente)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "UPDATE";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Clientes_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@Idcliente", Modelcliente.IdCliente);
                objCommand.Parameters.AddWithValue("@Nombre_1", Modelcliente.Nombre_1);
                objCommand.Parameters.AddWithValue("@Nombre_2", Modelcliente.Nombre_2);
                objCommand.Parameters.AddWithValue("@Apellido_1", Modelcliente.Apellido_1);
                objCommand.Parameters.AddWithValue("@Apellido_2", Modelcliente.Apellido_2);
                objCommand.Parameters.AddWithValue("@Id_FKdocument", Modelcliente.Id_Fkdocumento);
                objCommand.Parameters.AddWithValue("@Nacionalidad", Modelcliente.Nacionalidad);
                objCommand.Parameters.AddWithValue("@Nro_document", Modelcliente.Nro_Documento);
                objCommand.Parameters.AddWithValue("@Estatus", Modelcliente.Estatus);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/Cliente/Update_Email")]
        public int Update_Email(Email Modelemail)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "UPDATE";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Email_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@IdEmail", Modelemail.IdEmail);
                objCommand.Parameters.AddWithValue("@IdFKcliente", Modelemail.IdFkcliente);
                objCommand.Parameters.AddWithValue("@Id_FKtipo", Modelemail.IdFktipo);
                objCommand.Parameters.AddWithValue("@Email", Modelemail.Email1);
                objCommand.Parameters.AddWithValue("@Estatus", Modelemail.Estatus);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region ELIMINAR REGISTROS
        [HttpPost]
        [Route("api/Cliente/Delete_Cliente")]
        public int Delete_Cliente(Cliente Modelcliente)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "DELETE";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Clientes_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@Idcliente", Modelcliente.IdCliente);


                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/Cliente/Delete_Email")]
        public int Delete_Email(Email Modelemail)
        {
            SqlConnection Conn = (SqlConnection)_DbContext.Database.GetDbConnection();
            Conn.Open();
            int result = 0;

            try
            {
                string Proceso = "DELETE";
                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("Email_CRUD", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Proceso", Proceso);
                objCommand.Parameters.AddWithValue("@Idemail", Modelemail.IdEmail);
                objCommand.Parameters.AddWithValue("@IdFKcliente", Modelemail.IdFkcliente);


                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

    }
}
