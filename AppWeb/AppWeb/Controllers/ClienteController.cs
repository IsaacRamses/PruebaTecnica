using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using AppWeb.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace AppWeb.Controllers
{
    public class ClienteController : Controller
    {
        static HttpClient client = new HttpClient();

        // GET: ClienteController
        public ActionResult Clientes()
        {
            var url = "https://localhost:44310/api/Cliente/Cunsulta_Cliente";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            string result1;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { result1 = streamReader.ReadToEnd(); }
            var outObjectRequest = JsonConvert.DeserializeObject<List<Cliente>>(result1);

            var url_1 = "https://localhost:44310/api/Cliente/Cunsulta_TDoc";
            var httpWebRequest_1 = (HttpWebRequest)WebRequest.Create(url_1);
            httpWebRequest_1.ContentType = "application/json";
            httpWebRequest_1.Method = "GET";
            string result2;
            var httpResponse_1 = (HttpWebResponse)httpWebRequest_1.GetResponse();
            using (var streamReader = new StreamReader(httpResponse_1.GetResponseStream())) { result2 = streamReader.ReadToEnd(); }
            var outObjectRequest_1 = JsonConvert.DeserializeObject<List<MTDocumento>>(result2);

            outObjectRequest_1.Insert(0, new MTDocumento { DesDocumento = "Seleccione...", IdDocumento = 0 });
            ViewBag.TDocumento = new SelectList(outObjectRequest_1, "IdDocumento", "DesDocumento");

            var url_2 = "https://localhost:44310/api/Cliente/Cunsulta_TEmail";
            var httpWebRequest_2 = (HttpWebRequest)WebRequest.Create(url_2);
            httpWebRequest_2.ContentType = "application/json";
            httpWebRequest_2.Method = "GET";
            string result3;
            var httpResponse_2 = (HttpWebResponse)httpWebRequest_2.GetResponse();
            using (var streamReader = new StreamReader(httpResponse_2.GetResponseStream())) { result3 = streamReader.ReadToEnd(); }
            var outObjectRequest_2 = JsonConvert.DeserializeObject<List<MTEmail>>(result3);

            outObjectRequest_2.Insert(0, new MTEmail { DescTipo = "Seleccione...", IdTipo = 0 });
            ViewBag.TEmail = new SelectList(outObjectRequest_2, "IdTipo", "DescTipo");


            return View(outObjectRequest);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // POST: ClienteController/Create
        [HttpPost]
        public ActionResult SaveChanges(Cliente Model , Email Modelemail)
        {
           
            try
            {
                var url = "https://localhost:44310/api/Cliente/Insertar_Cliente";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var json = JsonConvert.SerializeObject(Model);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write(json); }

                string result1;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { result1 = streamReader.ReadToEnd(); }
                var outObjectRequest = JsonConvert.DeserializeObject<int>(result1);

                if (outObjectRequest != 0)
                {
                    Modelemail.IdFkcliente = outObjectRequest;
                    var url_1 = "https://localhost:44310/api/Cliente/Insertar_Email";
                    var httpWebRequest_1 = (HttpWebRequest)WebRequest.Create(url_1);
                    httpWebRequest_1.ContentType = "application/json";
                    httpWebRequest_1.Method = "POST";
                    var json_1 = JsonConvert.SerializeObject(Modelemail);
                    using (var streamWriter = new StreamWriter(httpWebRequest_1.GetRequestStream())) { streamWriter.Write(json_1); }

                    string result2;
                    var httpResponse_1 = (HttpWebResponse)httpWebRequest_1.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse_1.GetResponseStream())) { result2 = streamReader.ReadToEnd(); }
                    var outObjectRequest_1 = JsonConvert.DeserializeObject<int>(result2);

                    if (outObjectRequest_1 != 0)
                    {
                        return Json(new { Result = true });
                    }
                    else
                    {
                        return Json(new { Result = false });
                    }

                    
                }
                else
                {
                    return Json(new { Result = false });
                }
                
            }
            catch
            {
                return View();
            }
        }

     

        // POST: ClienteController/Edit/5
        [HttpPost]
        public ActionResult UpdateCliente(Cliente Model , Email Modelemail)
        {
             try
            {
                var url = "https://localhost:44310/api/Cliente/Update_Cliente";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var json = JsonConvert.SerializeObject(Model);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write(json); }

                string result1;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { result1 = streamReader.ReadToEnd(); }
                var outObjectRequest = JsonConvert.DeserializeObject<int>(result1);

                if (outObjectRequest != 0)
                {

                    Modelemail.IdFkcliente = outObjectRequest;
                    var url_1 = "https://localhost:44310/api/Cliente/Update_Email";
                    var httpWebRequest_1 = (HttpWebRequest)WebRequest.Create(url_1);
                    httpWebRequest_1.ContentType = "application/json";
                    httpWebRequest_1.Method = "POST";
                    var json_1 = JsonConvert.SerializeObject(Modelemail);
                    using (var streamWriter = new StreamWriter(httpWebRequest_1.GetRequestStream())) { streamWriter.Write(json_1); }

                    string result2;
                    var httpResponse_1 = (HttpWebResponse)httpWebRequest_1.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse_1.GetResponseStream())) { result2 = streamReader.ReadToEnd(); }
                    var outObjectRequest_1 = JsonConvert.DeserializeObject<int>(result2);

                    if (outObjectRequest_1 != 0)
                    {
                        return Json(new { Result = true });
                    }
                    else
                    {
                        return Json(new { Result = false });
                    }


                }
                else
                {
                    return Json(new { Result = false });
                }

            }
            catch
            {
                return View();
            }
        }



        // POST: ClienteController/Delete/5
        [HttpPost]
        public ActionResult DeleteCliente (Cliente Modelcliente)
        {
            try
            {
                var url = "https://localhost:44310/api/Cliente/Delete_Cliente";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                var json = JsonConvert.SerializeObject(Modelcliente);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream())) { streamWriter.Write(json); }

                string result1;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream())) { result1 = streamReader.ReadToEnd(); }
                var outObjectRequest = JsonConvert.DeserializeObject<int>(result1);

                if (outObjectRequest != 0)
                {
                    return Json(new { Result = true });
                }
                else
                {
                    return Json(new { Result = false });
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
