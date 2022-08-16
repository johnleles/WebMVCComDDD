using Microsoft.AspNetCore.Mvc;
using WebMVCComDDD.Application.ViewModels;
using WebMVCComDDD.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using WebMVCComDDD.Application.Helpers;
using WebMVCComDDD.Data;

namespace WebMVCComDDD.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IProdutoApplication _produtoApplication;
        private readonly IEmailApplication _emailApplication;

        public ProdutosController(IProdutoApplication produtoApplication, IEmailApplication emailApplication, ApplicationDbContext context)
        {
            _context = context;
            _produtoApplication = produtoApplication;
            _emailApplication = emailApplication;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            return View(viewName: _produtoApplication.GetAll());
        }

        //GET: Produtos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        // GET: Produtos/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Produtos/Create
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            _produtoApplication.Insert(produtoViewModel);

            string body = "<h1> Novo produto cadastrado " + produtoViewModel.Nome + " </h1>";
            var emailRequest = new EmailRequest
            {
                Body = body,
                Subject = "Cadastro de produto",
                ToEmail = "joaowictorleles@gmail.com"
            };
            await _emailApplication.SendEmailAsync(emailRequest);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        //POST: Produtos/Edit/5
        //To protect from overposting attacks, enable the specific properties you want to bind to.
        //For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProdutoViewModel produtoViewModel)
        {
            _produtoApplication.Update(produtoViewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View(_produtoApplication.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _produtoApplication.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProdutoExists(int id)
        //{
        //  return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
