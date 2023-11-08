using Newtonsoft.Json;
using DTO.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Logic
{
    public class AdminRegulation
    {
        private const string SERVICE_BASE_URL = "https://conferenceregulatory.azurewebsites.net";

        public UsuarioRegulationInfo GetUsuarioGeneratedInfo()
        {
            //Se crean los parametros que se deben enviar al URL
            string urlMethod = "/api/ArticleRegulatory/GenerateArticleInformation";
            //Se obtienen
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();

            string parameters = string.Format("?year={0}&month={1}", year, month);

            string finalURI = SERVICE_BASE_URL + urlMethod + parameters;

            //Se hace el llamado del API
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(finalURI);

            var invocationResult = client.GetAsync(finalURI).Result;

            if (invocationResult.IsSuccessStatusCode)
            {
                //Convertir el resultado (JSON) en el objeto que tenemos modelado en los DTO
                var patito = invocationResult.Content.ReadAsStringAsync().Result;

                var dtoObject = JsonConvert.DeserializeObject<UsuarioRegulationInfo>(patito);

                return dtoObject;
            }

            return null;
        }

        
    }
}
