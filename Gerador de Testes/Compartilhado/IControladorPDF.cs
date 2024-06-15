namespace Gerador_de_Testes.Compartilhado
{
    public interface IControladorPDF
    {        
        string ToolTipGerarPDF { get; }
        void GerarPDF();
    }
}
