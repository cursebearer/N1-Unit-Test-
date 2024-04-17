namespace Dominio
{
    public class Tarefa
    {
        private int[] vetorProjetos = new int[] { 1, 2, 3, 4, 5 };
        private int[] vetorMembros = new int[] { 1, 2, 3, 4, 5 };
        
        private string nome;
        private string descricao;
        private int idProjeto;
        private int idMembro;
        private DateOnly dataInicio;
        private DateOnly dataTermino;

        public Tarefa(string nome, string descricao, int idProjeto,DateOnly dataInicio,DateOnly dataTermino, int[] projetos, int idMembro)
        {
            if (string.IsNullOrEmpty(nome)) throw new ArgumentException("Nome Obrigatorio!");
            if (string.IsNullOrEmpty(descricao)) throw new ArgumentException("Descricao Obrigatorio!");
            if (idProjeto <= 0) throw new ArgumentException("Projeto nao encontrado!");
            
            bool achou = false;
            if(idMembro>=5||idMembro<0) throw new ArgumentException("Membro invalido!");
            foreach (var projeto in projetos)
            {
                if (projeto == idProjeto)
                {
                    achou = true;
                }
            }
            if(!achou) throw new ArgumentException("Projeto nao encontrado!");
            if (idMembro <= 0) throw new ArgumentException("Membro nao encontrado!");
            foreach(var membro in vetorMembros)
            {
                if(membro == idMembro) this.idMembro = idMembro;
            }
            DateOnly hoje = DateOnly.FromDateTime(DateTime.Now);
            if (dataInicio.CompareTo(hoje)<0) throw new ArgumentException("Data de inicio invalida!");
            if (dataTermino.CompareTo(dataInicio) < 0) throw new ArgumentException("Data de inicio invalida!");
            achou = false;

            this.nome = nome;
            this.descricao = descricao;
            this.idProjeto = idProjeto;
            this.dataInicio = dataInicio;
            this.dataTermino = dataTermino;
            //this.dataTermino = dataTermino;
        }
        public string Nome { get => nome; set => nome = value; } 
        public string Descricao { get => descricao; set => descricao = value; }
        public int IdProjeto { get => this.idProjeto; set => this.idProjeto = value; }
        public DateOnly DataInicio { get => this.dataInicio; set => this.dataInicio = value;}
        public DateOnly DataTermino { get => this.dataTermino; set => this.dataTermino = value;}
        public int[] VetorProjetos { get => vetorProjetos; set => vetorProjetos= value; }
        public int[] VetorMembros { get => vetorMembros; set => vetorMembros = value; }
        public int IdMembro { get => idMembro; set => idMembro = value; }
    }
}
