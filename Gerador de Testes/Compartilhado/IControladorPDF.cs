namespace Gerador_de_Testes.Compartilhado
{
    public interface IControladorPDF
    {        
        string ToolTipGerarPDF { get; }
        string ToolTipGerarPdfGabarito { get; }
        void GerarPDF();
        void GerarPdfGabarito();
    }
}
