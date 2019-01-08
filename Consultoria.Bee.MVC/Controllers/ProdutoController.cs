using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Consultoria.Bee.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Consultoria.Bee.MVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public ProdutoController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        
        // GET: Produto
        public async Task<ActionResult> Index()
        {
            IEnumerable<Produto> rtn = new List<Produto>();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Consultoria.Bee.Api/api/produto");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                rtn = await response.Content
                    .ReadAsAsync<IEnumerable<Produto>>();
            }
            
            return View(rtn);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produto/Create
        public async Task<ActionResult> Create()
        {
            var lista = await GetCategorias();
            ViewBag.ListOfCategorias = new SelectList(lista, "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Produto produto)
        {
            try
            {
                var client = _clientFactory.CreateClient();
                var uri = "http://localhost/Consultoria.Bee.Api/api/produto";
                var jsonInString = JsonConvert.SerializeObject(produto);

                var response = await client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode) { }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region PRIVATE METHODS
        private async Task<IEnumerable<ProdutoCategoria>> GetCategorias()
        {
            IEnumerable<ProdutoCategoria> rtn = new List<ProdutoCategoria>();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/Consultoria.Bee.Api/api/ProdutoCategoria");
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                rtn = await response.Content
                    .ReadAsAsync<IEnumerable<ProdutoCategoria>>();
            }

            return rtn;
        }
        #endregion
    }
}