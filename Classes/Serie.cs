using System;
using DIO.Series.Enums;

namespace DIO.Series.Classes
{
    public class Serie : EntidadeBase
    {
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        private bool Excluido { get; set; }
        
        public Serie(int Id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = Id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;

        }

        public override string ToString()
        {
            string retorno = "";
            retorno += $"Gênero: {this.Genero} {Environment.NewLine}"; 
            retorno += $"Titulo: {this.Titulo} {Environment.NewLine}";
            retorno += $"Descrição: {this.Descricao} {Environment.NewLine}";
            retorno += $"Ano de Início: {this.Ano} {Environment.NewLine}";
            retorno += $"Excluido: {this.Excluido} {Environment.NewLine}";
            return retorno;
        }

        public void Excluir() 
        {
            this.Excluido = true;
        }

    }
}