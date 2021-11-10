using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaNewbies
{
    class Livro
    {

        private string titulo;
        private string autor;
        private int numeroExemplaresDisponiveis;
        private int id;

        public Livro(string titulo, string autor, int numeroExemplares, int id)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.id = id;
            this.numeroExemplaresDisponiveis = numeroExemplares;
        }

        public string getTitulo()
        {
            return this.titulo;
        }

        public void setTitulo(string titulo)
        {
            this.titulo = titulo;
        }

        public string getAutor()
        {
            return this.autor;
        }


        public void setAutor(string autor)
        {
            this.autor = autor;
        }

        public int getNumeroExemplaresDisponiveis()
        {
            return this.numeroExemplaresDisponiveis;
        }

        public void setNumeroExemplaresDisponiveis(int numero)
        {
            this.numeroExemplaresDisponiveis = numero;
        }

        public int getId()
        {
            return this.id;
        }

        public override string ToString()
        {
            return "LIVRO ("+this.id+") : " + this.titulo + " - " + this.autor + " [" + this.numeroExemplaresDisponiveis + "]";
        }




    }
}
