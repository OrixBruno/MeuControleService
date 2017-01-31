using Newtonsoft.Json;
using Orix.MeuControle.UI.Web.Areas.ControleMapas.ViewModels;
using Orix.MeuControle.UI.Web.ViewModels;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web;

namespace Orix.MeuControle.UI.Web
{
    public static class Token
    { 
        public static void setToken(String token)
        {
            HttpContext.Current.Session["Token"] = token;
        }
        public static String getToken()
        {
            return HttpContext.Current.Session["Token"].ToString();
        }
    }

    public class RestApi<TClasse>
    {
        private RestClient _cliente;
        private const String API_BASE = "http://localhost:81/";
        private const String URL = "http://localhost:81/api/v1/";
        private const String URL_LOCAL = "http://localhost:4644/api/v1/";

        //METODOS DE REQUEST
        //GET --------------->>>>>>
        public TClasse GetObjeto(String controller, String action)
        {
            _cliente = new RestClient(URL + controller + "/" + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization",Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<TClasse>(response.Content);

            throw new Exception(response.Content);
        }
        public List<TClasse> GetLista(String controller = "", String action = "")
        {
            _cliente = new RestClient(URL + controller + "/" + action);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<List<TClasse>>(response.Content);

            throw new Exception(JsonConvert.DeserializeObject<dynamic>(response.Content).ExceptionMessage);
        }
        //POST, PUT, DELETE
        public virtual IRestResponse Request(TClasse objeto, Method metodo, String controller, String action)
        {
            _cliente = new RestClient(URL + controller + "/" + action);
            var request = new RestRequest(metodo);
            request.AddJsonBody(objeto);
            request.AddHeader("Authorization", Token.getToken());
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "NoContent" || response.StatusCode.ToString() == "OK")
                return response;
            var except = JsonConvert.DeserializeObject<dynamic>(response.Content);
            throw new Exception(except.ExceptionMessage.Value);
        }
        public virtual AuthorizationViewModel RequestToken(AuthorizationViewModel objeto, Method metodo, String action)
        {
            _cliente = new RestClient(API_BASE + action);
            var request = new RestRequest(metodo);
            request.AddParameter("grant_type", objeto.grant_type);
            request.AddParameter("username", objeto.username);
            request.AddParameter("password", objeto.password);
            var response = _cliente.Execute(request);

            if (response.StatusCode.ToString() == "OK")
                return JsonConvert.DeserializeObject<AuthorizationViewModel>(response.Content);

            throw new Exception(response.Content);
        }
    }
}