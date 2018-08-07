using ClienteDotNet.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;

namespace ClienteDotNet.Controllers
{
    public class NotesController : Controller
    {
        //Install-Package Microsoft.AspNet.WebApi.Client

        HttpClient client = new HttpClient();

        //construtor
        public NotesController()
        {
            //endereço base
            client.BaseAddress = new Uri("http://devmedianotesapi.azurewebsites.net");
            //configura os header, no caso está excluindo todos 
            client.DefaultRequestHeaders.Accept.Clear();
            //informa que vou enviar e receber dados do tipo json
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Notes
        //Action padrão
        public ActionResult Index()
        {
            List<Note> notes = new List<Note>();
            //Mensagem de retorno
            HttpResponseMessage responde = client.GetAsync("api/notes").Result;
            if(responde.IsSuccessStatusCode)
            {
                notes = responde.Content.ReadAsAsync<List<Note>>().Result;
            }
            return View(notes);
        }

        // GET: Notes/Details/5
        public ActionResult Details(int id)
        {
            //vai até o serviço buscar o objeto
            HttpResponseMessage response = client.GetAsync($"/api/notes/{id}").Result;
            //Pega de fato o objeto que retornou do serviço
            Note note = response.Content.ReadAsAsync<Note>().Result;
            if (note != null)
                return View(note);
            else
                return HttpNotFound();
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                //vai até o serviço buscar o objeto
                HttpResponseMessage response = client.PostAsJsonAsync<Note>("api/notes", note).Result;
                if(response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error while creating note";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Edit/5
        public ActionResult Edit(int id)
        {
            //vai até o serviço buscar o objeto
            HttpResponseMessage response = client.GetAsync($"/api/notes/{id}").Result;
            Note note = response.Content.ReadAsAsync<Note>().Result;
            if (note != null)
                return View(note);
            else
                return HttpNotFound();
        }

        // POST: Notes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Note note)
        {
            try
            {
                //vai até o serviço buscar o objeto
                HttpResponseMessage response = client.PutAsJsonAsync<Note>($"api/notes/{id}", note).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error while creating note";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Notes/Delete/5
        public ActionResult Delete(int id)
        {
            //vai no serviço e busca 1 objeto
            HttpResponseMessage response = client.GetAsync($"/api/notes/{id}").Result;
            //Pega de fato o objeto que retornou do serviço
            Note note = response.Content.ReadAsAsync<Note>().Result;
            if (note != null)
                return View(note);
            else
                return HttpNotFound();
        }

        // POST: Notes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                //vai até o serviço buscar o objeto
                HttpResponseMessage response = client.DeleteAsync($"api/notes/{id}").Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Error = "Error while creating note";
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
