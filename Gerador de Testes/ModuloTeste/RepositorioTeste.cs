﻿using Gerador_de_Testes.Compartilhado;
namespace Gerador_de_Testes.ModuloTeste
{
    internal class RepositorioTeste : RepositorioBase<Teste>, IRepositorioTeste
    {
        public RepositorioTeste(ContextoDados contexto) : base(contexto) { }

        protected override List<Teste> ObterRegistros() => contexto.Testes;
    }

}
