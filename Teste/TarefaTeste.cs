using Bogus;
using Bogus.DataSets;
using Dominio;
using ExpectedObjects;
using System.Collections.Generic;
using System.Data;

namespace Teste
{   //FEITO POR FEITO POR FEITO POR:
    //Mateus Finder Martins, Rafael Pavesi Dos Passos;
    public class TarefaTeste
    {
        private static int[] vetorProjetos = new int[] { 1, 2, 3, 4, 5 };
        private static int[] vetorMembros = new int[] { 1, 2, 3, 4, 5 };
        private string _nome;
        private string _descricao;
        private int _idProjeto;
        private int _idMembro;
        private DateOnly _dataInicio;
        private DateOnly _dataTermino;


        public TarefaTeste()
        {
            Faker faker = new Faker();
        
            _nome = faker.Person.FullName;
            _descricao = "Descricao";
            _idProjeto = 1;
            _idMembro = 1;
            DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
            _dataInicio = hoje.AddDays(1);
            _dataTermino = _dataInicio.AddDays(1);
            
            //_dataInicio = faker.Random.Int(1,30).ToString()+"/"+ faker.Random.Int();
            //_dataTermino = "30/04/2024";
            

        }
        [Fact]
        public void CriaTarefaCorretamente()
        {
            var tarefaEsperada = new
            {
                Nome = _nome,
                Descricao = _descricao,
                IdProjeto = _idProjeto,
                DataInicio = _dataInicio,
                DataTermino = _dataTermino,
                VetorProjetos = vetorProjetos,
                VetorMembros = vetorMembros,
                IdMembro = _idMembro
            };
            Tarefa tarefa= new Tarefa(_nome,_descricao, _idProjeto,_dataInicio,_dataTermino,vetorProjetos,_idMembro);
            tarefaEsperada.ToExpectedObject().ShouldMatch(tarefa);
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void NomeObrigatorio(string nomeErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(nomeErrado, _descricao, _idProjeto,_dataInicio,_dataTermino, vetorProjetos,_idMembro)
                ); 
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void DescricaoObrigatoria(string descricaoErrada)
        {
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(descricaoErrada, _descricao, _idProjeto,_dataInicio,_dataTermino, vetorProjetos,_idMembro)
                ); 
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void IdInvalido(int idErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(_nome, _descricao, idErrado,_dataInicio,_dataTermino, vetorProjetos,_idMembro)
            );
        }
        [Fact]
        public void ProjetoInvalido()
        {
            int[] projetos = new int[] {};
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(_nome, _descricao, _idProjeto,_dataInicio,_dataTermino, projetos,_idMembro)
            ); 
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(6)]
        public void IdIMembroInvalido(int idErrado)
        {
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(_nome, _descricao, _idProjeto, _dataInicio, _dataTermino, vetorProjetos, idErrado)
            );
        }

        [Fact]
        public void DataInicioInvalida()
        {
            DateOnly dataErrada = new DateOnly(2014, 07, 25);
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(_nome, _descricao, _idProjeto, dataErrada, _dataTermino, vetorProjetos,_idMembro)
            );
        }
        [Fact]
        public void DataTerminoInvalida()
        {
            DateOnly dataErrada = new DateOnly(2014, 07, 25);
            Assert.Throws<ArgumentException>(
                () =>
                new Tarefa(_nome, _descricao, _idProjeto, _dataInicio, dataErrada, vetorProjetos,_idMembro)
            );
        }
    }
}