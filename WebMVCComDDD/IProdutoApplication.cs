using WebMVCComDDD.Application.ViewModels;

internal interface IProdutoApplication
{
    void Insert(ProdutoViewModel produtoViewModel);
    void Update(ProdutoViewModel produtoViewModel);
    void Delete(int id);
    string? GetAll();
    string? GetById(int id);
}